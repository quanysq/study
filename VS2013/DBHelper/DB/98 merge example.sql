BEGIN	
	merge into InternalMethod a 
	using (
		select 13 MethodID, 2 DatabaseID, 3 ClassifyID, 'abc' MethodName, 'abc' MethodDesc, 
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
		insert (DatabaseID, ClassifyID, MethodName, MethodDesc, MethodType, FunctionType, SuccessMsg, FailMsg, CreateUser, CreateDate)
		values (b.DatabaseID, b.ClassifyID, b.MethodName, b.MethodDesc, b.MethodType, b.FunctionType, b.SuccessMsg, b.FailMsg, b.CreateUser, b.CreateDate);

	SELECT @@IDENTITY AS MethodID
END
	


