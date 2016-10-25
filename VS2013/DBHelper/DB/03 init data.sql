/* merge example
merge into InternalMethod a 
using (
	select 0 MethodID, 2 DatabaseID, 3 ClassifyID, 'abc' MethodName, 'abc' MethodDesc, 
		   'SQLStatement' MethodType, 'Select_Paging' FunctionType, '' SuccessMsg, '' FailMsg, 
		   'Admin' CreateUser, getdate() CreateDate, 'Admin' UpdateUser, getdate() UpdateDate, '' UpdateReson 
) b
on a.MethodID = b.MethodID
when matched then 
	update set 
	  a.MethodName	=b.MethodName,
	  a.MethodDesc	=b.MethodDesc, 
	  a.MethodType	=b.MethodType, 
	  a.FunctionType=b.FunctionType, 
	  a.SuccessMsg	=b.SuccessMsg, 
	  a.FailMsg		=b.FailMsg, 
	  a.UpdateUser	=b.UpdateUser, 
	  a.UpdateDate	=b.UpdateDate, 
	  a.UpdateReson	=b.UpdateReson
when not matched then
	insert (a.DatabaseID, a.ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, SuccessMsg, FailMsg, CreateUser, CreateDate)
	values (b.DatabaseID, b.ClassifyID, b.MethodName, b.MethodDesc, b.MethodType, b.FunctionType, b.SuccessMsg, b.FailMsg, b.CreateUser, b.CreateDate);
*/

--insert Admin user into UserInfo table
if not exists (select 1 from UserInfo WHERE Usercode='Admin')
BEGIN
	INSERT INTO dbo.UserInfo (Usercode, UserName, Pwd, IsAddSelf, IsEditSelf, IsDeleteSelf, IsEditOther, IsDeleteOther)
	VALUES ('Admin', '超级管理员', 'quanysq123', 1, 1, 1, 1, 1)
END
GO

--insert 2 test user
if not exists (select 1 from UserInfo WHERE Usercode LIKE 'Tester%')
BEGIN
	INSERT INTO dbo.UserInfo (Usercode, UserName, Pwd) VALUES ('Tester01', '测试者01', '123456');
	INSERT INTO dbo.UserInfo (Usercode, UserName, Pwd) VALUES ('Tester02', '测试者02', '123456');
END
GO

--insert 6 test InternalMethod record
/*
if not exists (select 1 from InternalMethod)
BEGIN
	INSERT INTO dbo.InternalMethod (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, CreateUser)
	VALUES (2, 3, 'Test', 'Test', 'SQLStatement', 'Select_View', 'Admin')
	
	INSERT INTO dbo.InternalMethod (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, CreateUser)
	VALUES (2, 3, 'Test', 'Test', 'SQLStatement', 'Select_Paging', 'Admin')
	
	INSERT INTO dbo.InternalMethod (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, CreateUser)
	VALUES (2, 3, 'Test', 'Test', 'SQLStatement', 'Select_Rows', 'Admin')
	
	INSERT INTO dbo.InternalMethod (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, CreateUser)
	VALUES (2, 3, 'Test', 'Test', 'SQLStatement', 'Insert', 'Admin')
	
	INSERT INTO dbo.InternalMethod (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, CreateUser)
	VALUES (2, 3, 'Test', 'Test', 'SQLStatement', 'Update', 'Admin')
	
	INSERT INTO dbo.InternalMethod (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, CreateUser)
	VALUES (2, 3, 'Test', 'Test', 'StoredProcedure', 'Delete', 'Admin')
END
GO
*/