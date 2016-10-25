/* 
============Example==============
if exists (select 1 from sysobjects where name = 'updatemaxid' and type = 'p')
   drop procedure updatemaxid
go
create procedure [dbo].[updatemaxid] 
	@seq_table varchar(30),
	@out_maxno varchar(50) output
as
begin
	set xact_abort on
	begin transaction
	   
	declare @seq_maxid int,@seq_date varchar(8)
	   
	select @seq_date=convert(varchar(8),getdate(),112)
	     
	select @seq_maxid=isnull(max(seq_maxid),0)+1 from sys_mseq(tablockx) where seq_table=@seq_table and seq_date=@seq_date
	if (@seq_maxid=1)
		insert into sys_mseq(seq_maxid,seq_date,seq_table) values(@seq_maxid,@seq_date,@seq_table)
	else
		update sys_mseq set seq_maxid=@seq_maxid where seq_table=@seq_table and seq_date=@seq_date

	select @out_maxno=@seq_date+right('00000'+cast(@seq_maxid as varchar(10)),5)

	if @@error != 0
	begin
		rollback transaction
	end	
	else
	begin
		commit transaction
	end
end
go
*/
if exists (select 1 from sysobjects where name = 'DeleteMethodClassify' and type = 'p')
   drop procedure DeleteMethodClassify
go
create procedure [dbo].[DeleteMethodClassify] 
	@ClassifyID int 
as
begin
	set xact_abort on
	begin transaction
	   
	declare @DefaultID int,@ClassifyType INT,@ClassifyName VARCHAR(40)
	   
	SELECT @ClassifyType=ClassifyType, @ClassifyName=ClassifyName FROM MethodClassify WHERE ClassifyID=@ClassifyID
	
	IF @ClassifyName='Default'
	BEGIN
		RAISERROR('默认分类不能被删除！',16,1);
		rollback transaction
		return
	END
	
	SELECT @DefaultID=ClassifyID FROM MethodClassify WHERE ClassifyName='Default' AND ClassifyType=@ClassifyType
	
	IF @ClassifyType=1
	BEGIN
		UPDATE InternalMethod SET ClassifyID=@DefaultID WHERE ClassifyID=@ClassifyID
	END
	ELSE
	BEGIN
		UPDATE BusinessMethod SET ClassifyID=@DefaultID WHERE ClassifyID=@ClassifyID
	END
	
	DELETE FROM MethodClassify WHERE ClassifyID=@ClassifyID

	if @@error != 0
	begin
		rollback transaction
	end	
	else
	begin
		commit transaction
	end
end
go

if exists (select 1 from sysobjects where name = 'SaveMethodStatementMainInfo' and type = 'p')
   drop procedure SaveMethodStatementMainInfo
go
create procedure [dbo].[SaveMethodStatementMainInfo] 
	@StatementID INT,
	@MethodID INT,
	@Tag VARCHAR(100)
as
begin
	DECLARE @OrderID INT
	
	SELECT @OrderID=isnull(max(a.OrderID),0)+1 FROM MethodStatement a WHERE MethodID=@MethodID
	
	merge into MethodStatement a 
	using (
		select @StatementID StatementID, @MethodID MethodID, @OrderID OrderID, @Tag Tag
	) b
	on a.StatementID = b.StatementID
	when matched then 
		update set a.Tag=b.Tag
	when not matched then
		insert (MethodID, OrderID, Tag, Statement)
		values (b.MethodID, b.OrderID, b.Tag, ' ');
	
	if (@StatementID=0)
	begin
		SELECT @@IDENTITY AS StatementID
	end
	else
	begin
		SELECT @StatementID AS StatementID
	end
end
go

if exists (select 1 from sysobjects where name = 'MoveMethodStatementOrder' and type = 'p')
   drop procedure MoveMethodStatementOrder
go
create procedure [dbo].[MoveMethodStatementOrder] 
	@StatementID INT,
	@IsMoveUp INT
as
begin
	DECLARE @OrderID INT, @NextOrderID INT, @MaxOrderID INT, @MinOrderID INT, @MethodID INT
	
	SELECT @MethodID=a.MethodID, @OrderID=a.OrderID FROM MethodStatement a WHERE StatementID=@StatementID
	SELECT @MaxOrderID=max(a.OrderID), @MinOrderID=min(a.OrderID) FROM MethodStatement a WHERE MethodID=@MethodID
	IF (@IsMoveUp=1)
	BEGIN
		SET @NextOrderID=@OrderID-1;
		IF (@NextOrderID<@MinOrderID)
		BEGIN
			RETURN
		END
	END
	ELSE
	BEGIN
		SET @NextOrderID=@OrderID+1;
		IF (@NextOrderID>@MaxOrderID)
		BEGIN
			RETURN
		END
	END
	
	UPDATE MethodStatement SET OrderID=@NextOrderID WHERE StatementID=@StatementID
	IF (@IsMoveUp=1)
	BEGIN
		UPDATE MethodStatement SET OrderID=OrderID+1 WHERE OrderID=@NextOrderID AND StatementID != @StatementID
	END 
	ELSE
	BEGIN
		UPDATE MethodStatement SET OrderID=OrderID-1 WHERE OrderID=@NextOrderID AND StatementID != @StatementID
	END
end
go

if exists (select 1 from sysobjects where name = 'GenterateBusinessMethodCode' and type = 'p')
   drop procedure GenterateBusinessMethodCode
go
create procedure [dbo].[GenterateBusinessMethodCode] 
	@out_maxno varchar(6) output
as
begin
	set xact_abort on
	begin transaction
	   
	declare @currentcode varchar(6)
	   
	select @currentcode=isnull(max(bmcode),'A00000') from businessmethod_code(tablockx)
	     
	select @out_maxno=case when right(@currentcode,5)='99999' then char(ascii(left(@currentcode,1))+1)+'00001'
            			   else left(@currentcode,1) + right(replicate('0',5) + rtrim(cast(stuff(@currentcode,1,1,'') as int)+1),5) 
       				  end
       
	insert into businessmethod_code values(@out_maxno)

	if @@error != 0
	begin
		rollback transaction
	end	
	else
	begin
		commit transaction
	end
end
GO

if exists (select 1 from sysobjects where name = 'SaveBusinessMethod' and type = 'p')
   drop procedure SaveBusinessMethod
go
create procedure [dbo].[SaveBusinessMethod] 
	@BMCode varchar(6),
	@DatabaseID int, 
	@ClassifyID int, 
	@BMDesc VARCHAR(1000), 
	@FunctionType VARCHAR(50), 
	@CreateUser VARCHAR(50),
	@UpdateReson VARCHAR(50)
as
begin
	set xact_abort on
	begin transaction
	   
	declare @CurrentCode varchar(6)
	IF (@BMCode IS NULL OR len(ltrim(rtrim(@BMCode))) = 0)
	BEGIN
		EXEC GenterateBusinessMethodCode @CurrentCode OUTPUT
	END
	ELSE 
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM BusinessMethod_Code WHERE BMCode=@BMCode)
		BEGIN
			EXEC GenterateBusinessMethodCode @CurrentCode OUTPUT
		END
		ELSE 
		BEGIN
			SET @CurrentCode=@BMCode
		END
	END
	
	merge into BusinessMethod a 
	using (
		select @CurrentCode BMCode, @DatabaseID DatabaseID, @ClassifyID ClassifyID, @BMDesc BMDesc, @FunctionType FunctionType, 
			   @CreateUser CreateUser, getdate() CreateDate, @CreateUser UpdateUser, getdate() UpdateDate, @UpdateReson UpdateReson 
	) b
	on a.BMCode = b.BMCode
	when matched then 
		update set 
		  a.BMDesc		=b.BMDesc,
		  a.FunctionType=b.FunctionType, 
		  a.UpdateUser	=b.UpdateUser, 
		  a.UpdateDate	=b.UpdateDate, 
		  a.UpdateReson	=b.UpdateReson
	when not matched then
		insert (BMCode, DatabaseID, ClassifyID, BMDesc, FunctionType, CreateUser, CreateDate)
		values (b.BMCode, b.DatabaseID, b.ClassifyID, b.BMDesc, b.FunctionType, b.CreateUser, b.CreateDate);
	
	SELECT @CurrentCode AS BMCode

	if @@error != 0
	begin
		rollback transaction
	end	
	else
	begin
		commit transaction
	end
end
GO

if exists (select 1 from sysobjects where name = 'SaveBusinessMethodIM' and type = 'p')
   drop procedure SaveBusinessMethodIM
go
create procedure [dbo].[SaveBusinessMethodIM] 
	@BMCode VARCHAR(6),
	@MethodID INT
as
begin
	DECLARE @MethodOrder INT
	
	SELECT @MethodOrder=isnull(max(a.MethodOrder),0)+1 FROM BusinessMethod_InternalMethods a WHERE BMCode=@BMCode
	
	merge into BusinessMethod_InternalMethods a 
	using (
		select @BMCode BMCode, @MethodID MethodID, @MethodOrder MethodOrder
	) b
	on (a.BMCode = b.BMCode AND a.MethodID = b.MethodID)
	when not matched then
		insert (BMCode, MethodID, MethodOrder)
		values (b.BMCode, b.MethodID, b.MethodOrder);
end
GO

if exists (select 1 from sysobjects where name = 'MoveBusinessMethodIMOrder' and type = 'p')
   drop procedure MoveBusinessMethodIMOrder
go
create procedure [dbo].[MoveBusinessMethodIMOrder] 
	@BMCode VARCHAR(6),
	@MethodID INT,
	@IsMoveUp INT
as
begin
	DECLARE @OrderID INT, @NextOrderID INT, @MaxOrderID INT, @MinOrderID INT
	
	SELECT @OrderID=a.MethodOrder FROM BusinessMethod_InternalMethods a WHERE BMCode=@BMCode AND MethodID=@MethodID
	SELECT @MaxOrderID=max(a.MethodOrder), @MinOrderID=min(a.MethodOrder) FROM BusinessMethod_InternalMethods a WHERE BMCode=@BMCode
	IF (@IsMoveUp=1)
	BEGIN
		SET @NextOrderID=@OrderID-1;
		IF (@NextOrderID<@MinOrderID)
		BEGIN
			RETURN
		END
	END
	ELSE
	BEGIN
		SET @NextOrderID=@OrderID+1;
		IF (@NextOrderID>@MaxOrderID)
		BEGIN
			RETURN
		END
	END
	
	UPDATE BusinessMethod_InternalMethods SET MethodOrder=@NextOrderID WHERE BMCode=@BMCode AND MethodID=@MethodID
	IF (@IsMoveUp=1)
	BEGIN
		UPDATE BusinessMethod_InternalMethods SET MethodOrder=MethodOrder+1 WHERE MethodOrder=@NextOrderID AND BMCode=@BMCode AND MethodID!=@MethodID
	END 
	ELSE
	BEGIN
		UPDATE BusinessMethod_InternalMethods SET MethodOrder=MethodOrder-1 WHERE MethodOrder=@NextOrderID AND BMCode=@BMCode AND MethodID!=@MethodID
	END
end
GO

if exists (select 1 from sysobjects where name = 'SaveBusinessMethodParameterRelations' and type = 'p')
   drop procedure SaveBusinessMethodParameterRelations
go
create procedure [dbo].[SaveBusinessMethodParameterRelations] 
	@BMCode VARCHAR(6),
	@MethodID INT
as
begin
	merge into BusinessMethod_ParameterRelations a 
	using (
		SELECT @BMCode BMCode, MethodID, ParameterName BMParameterName, ParameterName MethodParameterName,
			   ParameterDesc, ParameterDataType, ParameterDirection, ParameterValidateType
		FROM MethodParameter 
		WHERE MethodID=@MethodID
	) b
	on (a.BMCode = b.BMCode AND a.MethodID = b.MethodID AND a.MethodParameterName=b.MethodParameterName)
	when not matched then
		insert (BMCode, MethodID, BMParameterName, MethodParameterName, ParameterDesc, ParameterDataType, ParameterDirection, ParameterValidateType)
		values (b.BMCode, b.MethodID, b.BMParameterName, b.MethodParameterName, b.ParameterDesc, b.ParameterDataType, b.ParameterDirection, b.ParameterValidateType);
		
	SELECT BMCode, MethodID, BMParameterName, MethodParameterName 
	FROM BusinessMethod_ParameterRelations
	WHERE BMCode=@BMCode AND MethodID=@MethodID
end
GO

if exists (select 1 from sysobjects where name = 'UpdateBusinessMethodParameterRelations' and type = 'p')
   drop procedure UpdateBusinessMethodParameterRelations
go
create procedure [dbo].[UpdateBusinessMethodParameterRelations] 
	@BMCode VARCHAR(6),
	@MethodID INT,
	@MethodParameterName VARCHAR(100),
	@BMParameterName VARCHAR(100)
as
begin
	set xact_abort on
	begin transaction
	   
	declare @CurrentBMParameterName varchar(100)
	   
	SELECT @CurrentBMParameterName=BMParameterName 
	FROM BusinessMethod_ParameterRelations
	WHERE BMCode=@BMCode
		  AND MethodID=@MethodID
		  AND MethodParameterName=@MethodParameterName 
	--PRINT @CurrentBMParameterName
	
	UPDATE BusinessMethod_ParameterRelations SET 
		BMParameterName=@BMParameterName 
	WHERE BMCode=@BMCode
		  AND MethodID=@MethodID
		  AND MethodParameterName=@MethodParameterName	  
		  
    IF EXISTS (select 1 from BusinessMethod_Parameter WHERE BMCode=@BMCode AND ParameterName=@CurrentBMParameterName)
    BEGIN
    	--PRINT @BMParameterName
    	UPDATE BusinessMethod_Parameter SET
    		ParameterName=@BMParameterName
    	WHERE BMCode=@BMCode 
    		  AND ParameterName=@CurrentBMParameterName
    END
	
	if @@error != 0
	begin
		rollback transaction
	end	
	else
	begin
		commit transaction
	end
end
GO

if exists (select 1 from sysobjects where name = 'SaveBusinessMethodParameter' and type = 'p')
   drop procedure SaveBusinessMethodParameter
go
create procedure [dbo].[SaveBusinessMethodParameter] 
	@BMCode VARCHAR(6)
as
begin
	merge into BusinessMethod_Parameter a 
	using (
		SELECT max(BMCode) BMCode, BMParameterName ParameterName, max(ParameterDesc) ParameterDesc, 
			   max(ParameterDataType) ParameterDataType, max(ParameterDirection) ParameterDirection, 
			   max(ParameterValidateType) ParameterValidateType
		FROM BusinessMethod_ParameterRelations 
		WHERE BMCode=@BMCode 
		GROUP BY BMParameterName
	) b
	on (a.BMCode = b.BMCode AND a.ParameterName = b.ParameterName)
	when not matched then
		insert (BMCode, ParameterName, ParameterDesc, ParameterDataType, ParameterDirection, ParameterValidateType)
		values (b.BMCode, b.ParameterName, b.ParameterDesc, b.ParameterDataType, b.ParameterDirection, b.ParameterValidateType);
		
	SELECT ParameterID, ParameterName, ParameterDesc, ParameterDataType, ParameterDirection, 
		   ParameterValidateType, ConstValue, DefaultValue
	FROM BusinessMethod_Parameter
	WHERE BMCode=@BMCode
	ORDER BY ParameterName
end
GO