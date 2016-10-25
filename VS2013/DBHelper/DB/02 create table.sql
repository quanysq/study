--add UserInfo table
if not exists (select 1 from sysobjects where id = object_id('UserInfo') and type = 'U')
begin
create table UserInfo (
   	UserID				int					identity,
   	Usercode	 		varchar(50)			not null,
   	UserName	 		varchar(50)			not null,
   	Pwd					varchar(50)			not null,
   	IsAddSelf			int					not NULL DEFAULT 1,
   	IsEditSelf			int					not NULL DEFAULT 1,
   	IsDeleteSelf		int					not NULL DEFAULT 1,
   	IsEditOther			int					not NULL DEFAULT 0,
   	IsDeleteOther		int					not NULL DEFAULT 0,
   	HasDeleted			int					NOT NULL DEFAULT 0,
   	constraint PK_UserInfo primary key (UserID),
   	constraint UK_UserInfo unique(Usercode)
)
end
GO

--add DatabaseInfo table
if not exists (select 1 from sysobjects where id = object_id('DatabaseInfo') and type = 'U')
begin
create table DatabaseInfo (
   	DatabaseID			int					IDENTITY,	
   	UserID				int					NOT NULL,	
   	DBType				varchar(20)			NOT NULL,	
   	ConnectionName		varchar(100)		NOT NULL,	
   	ConnectionStr		varchar(200)		NOT NULL,
   	IsDefault			int					NOT NULL DEFAULT 0,
   	constraint PK_DatabaseInfo primary key (DatabaseID),
   	constraint FK_DatabaseInfo_UserInfo foreign key(UserID) references UserInfo(UserID),
   	constraint UK_DatabaseInfo unique(UserID, ConnectionName)
)
end
GO

--add DatabaseDetailInfo table
if not exists (select 1 from sysobjects where id = object_id('DatabaseDetailInfo') and type = 'U')
begin
create table DatabaseDetailInfo (
   	DatabaseID			int					NOT NULL,
	DBHost				varchar(50)			NOT NULL,
	DBUser				varchar(50)			NOT NULL,
	DBPwd				varchar(50)			NOT NULL,
	Pooling				varchar(50)					,
	MinPoolSize			varchar(50)					,
	MaxPoolSize			varchar(50)					,
	ConnectionLifetime	varchar(50)					,
	Catalog				varchar(50)					,
	Port				varchar(50)					,
	Service_Name		varchar(50)					,
	constraint PK_DatabaseDetailInfo primary key (DatabaseID),
   	constraint FK_DatabaseDetailInfo_DatabaseInfo foreign key(DatabaseID) references DatabaseInfo(DatabaseID)
)
end
GO

--add MethodClassify table
if not exists (select 1 from sysobjects where id = object_id('MethodClassify') and type = 'U')
begin
create table MethodClassify (
   	ClassifyID			int					IDENTITY,	
   	DatabaseID			int					NOT NULL,
	ClassifyName		varchar(40)			NOT NULL,
	ClassifyType		int					NOT NULL,
   	constraint PK_MethodClassify primary key (ClassifyID),
   	constraint FK_MethodClassify_DatabaseInfo foreign key(DatabaseID) references DatabaseInfo(DatabaseID),
   	constraint UK_MethodClassify unique(DatabaseID, ClassifyName, ClassifyType)
)
end
GO

--add InternalMethod table
if not exists (select 1 from sysobjects where id = object_id('InternalMethod') and type = 'U')
begin
create table InternalMethod (
	MethodID			int					IDENTITY,	
	DatabaseID			int					NOT NULL,
	ClassifyID			int					NOT NULL,
	MethodName			varchar(100)		NOT NULL,	
	MethodDesc			varchar(1000)		NOT NULL,	
	MethodType			varchar(50)			NOT NULL,
	FunctionType		varchar(50)			NOT NULL,	
	SuccessMsg			varchar(200)				,
	FailMsg				varchar(200)				,
	CreateUser			varchar(50)			NOT NULL,	
	CreateDate			datetime			NOT null DEFAULT getdate(),
	UpdateUser			varchar(50)					,	
	UpdateDate			datetime					,
	UpdateReson			varchar(2000)				,
   	constraint PK_InternalMethod primary key (MethodID),
   	constraint FK_InternalMethod_DatabaseInfo foreign key(DatabaseID) references DatabaseInfo(DatabaseID),
   	constraint FK_InternalMethod_MethodClassify foreign key(ClassifyID) references MethodClassify(ClassifyID)
)
end
GO

--add MethodStatement table
if not exists (select 1 from sysobjects where id = object_id('MethodStatement') and type = 'U')
begin
create table MethodStatement (
	StatementID			int					IDENTITY,	
	MethodID			int					NOT NULL,
	OrderID				int					NOT NULL,
	Tag					varchar(100)		NOT NULL,	
	Statement			varchar(max)		NOT NULL,	
	IsOrderby			int					NOT NULL DEFAULT 0,
	HasConditional		int					NOT NULL DEFAULT 0,
   	constraint PK_MethodStatement primary key (StatementID),
   	constraint FK_MethodStatement_InternalMethod foreign key(MethodID) references InternalMethod(MethodID) ON DELETE CASCADE
)
end
GO

--add MethodStatementConditional table
if not exists (select 1 from sysobjects where id = object_id('MethodStatementConditional') and type = 'U')
begin
create table MethodStatementConditional (
	ConditionalID		int					IDENTITY,	
	StatementID			int					NOT NULL,
	MethodID			int					NOT NULL,
	ConditionType		varchar(20)					,
	ParameterName		varchar(100)		NOT NULL,	
	ExpectBehavior		varchar(50)			NOT NULL,
	CompareValue		varchar(50)					,
   	constraint PK_MethodStatementConditional primary key (ConditionalID),
   	constraint FK_MethodStatementConditional_MethodStatement foreign key(StatementID) references MethodStatement(StatementID) ON DELETE CASCADE,
   	constraint FK_MethodStatementConditional_InternalMethod foreign key(MethodID) references InternalMethod(MethodID)
)
end
GO

--add MethodParameter table
if not exists (select 1 from sysobjects where id = object_id('MethodParameter') and type = 'U')
begin
create table MethodParameter (
	ParameterID				int				IDENTITY,	
	MethodID				int				NOT NULL,
	ParameterName			varchar(100)	NOT NULL,
	ParameterDesc			varchar(500)			,
	ParameterDataType		varchar(50)		NOT NULL,
	ParameterDirection		varchar(50)		NOT NULL,
	ParameterValidateType	varchar(50)		NOT NULL,
	ValidateValue			varchar(50)				,
   	constraint PK_MethodParameter primary key (ParameterID),
   	constraint FK_MethodParameter_InternalMethod foreign key(MethodID) references InternalMethod(MethodID) ON DELETE CASCADE,
   	constraint UK_MethodParameter unique(MethodID, ParameterName)
)
end
GO

--add BusinessMethod table
if not exists (select 1 from sysobjects where id = object_id('BusinessMethod') and type = 'U')
begin
create table BusinessMethod (
	BMCode				varchar(6)			NOT NULL,
	DatabaseID			int					NOT NULL,
	ClassifyID			int					NOT NULL,
	BMDesc				varchar(1000)		NOT NULL,
	FunctionType		varchar(50)			NOT NULL,
	CreateUser			varchar(50)			NOT NULL,
	CreateDate			datetime			NOT NULL DEFAULT getdate(),
	UpdateUser			varchar(50)					,
	UpdateDate			datetime					,
	UpdateReson			varchar(2000)				,
   	constraint PK_BusinessMethod primary key (BMCode),
   	constraint FK_BusinessMethod_DatabaseInfo foreign key(DatabaseID) references DatabaseInfo(DatabaseID),
   	constraint FK_BusinessMethod_MethodClassify foreign key(ClassifyID) references MethodClassify(ClassifyID)
)
end
GO

--add BusinessMethod_InternalMethods table
if not exists (select 1 from sysobjects where id = object_id('BusinessMethod_InternalMethods') and type = 'U')
begin
create table BusinessMethod_InternalMethods (
	BMCode				varchar(6)			NOT NULL,
	MethodID			int					NOT NULL,
	MethodOrder			int					NOT NULL,
   	constraint PK_BusinessMethod_InternalMethods primary key (BMCode, MethodID),
   	constraint FK_BusinessMethod_InternalMethods_BusinessMethod foreign key(BMCode) references BusinessMethod(BMCode) ON DELETE CASCADE,
   	constraint FK_BusinessMethod_InternalMethods_InternalMethod foreign key(MethodID) references InternalMethod(MethodID) ON DELETE CASCADE
)
end
GO

--add BusinessMethod_Parameter table
if not exists (select 1 from sysobjects where id = object_id('BusinessMethod_Parameter') and type = 'U')
begin
create table BusinessMethod_Parameter (
	ParameterID				int				IDENTITY,
	BMCode					varchar(6)		NOT NULL,
	ParameterName			varchar(100)	NOT NULL,
	ParameterDesc			varchar(500)			,
	ParameterDataType		varchar(50)		NOT NULL,
	ParameterDirection		varchar(50)		NOT NULL,
	ParameterValidateType	varchar(50)		NOT NULL,
	ConstValue				varchar(50)				,
	DefaultValue			varchar(50)				,
   	constraint PK_BusinessMethod_Parameter primary key (ParameterID),
   	constraint FK_BusinessMethod_Parameter_BusinessMethod foreign key(BMCode) references BusinessMethod(BMCode) ON DELETE CASCADE
)
end
GO

--add BusinessMethod_ParameterRelations table
if not exists (select 1 from sysobjects where id = object_id('BusinessMethod_ParameterRelations') and type = 'U')
begin
create table BusinessMethod_ParameterRelations (
	BMCode					varchar(6)		NOT NULL,
	MethodID				int				NOT NULL,
	BMParameterName			varchar(100)	NOT NULL,
	MethodParameterName		varchar(100)	NOT NULL,
	ParameterDesc			varchar(500)			,
	ParameterDataType		varchar(50)		NOT NULL,
	ParameterDirection		varchar(50)		NOT NULL,
	ParameterValidateType	varchar(50)		NOT NULL,
   	constraint PK_BusinessMethod_ParameterRelations primary key (BMCode, MethodID, MethodParameterName),
   	constraint FK_BusinessMethod_ParameterRelations_BusinessMethod foreign key(BMCode) references BusinessMethod(BMCode) ON DELETE CASCADE,
   	constraint FK_BusinessMethod_ParameterRelations_InternalMethod foreign key(MethodID) references InternalMethod(MethodID)
)
end
GO

--add BusinessMethod_Code table
if not exists (select 1 from sysobjects where id = object_id('BusinessMethod_Code') and type = 'U')
begin
create table BusinessMethod_Code (
	BMCode					varchar(6),
   	constraint PK_BusinessMethod_Code primary key (BMCode)
)
end
GO
