IF NOT EXISTS (select 1 From master.dbo.sysdatabases where name='DBHelper')
BEGIN
	CREATE DATABASE DBHelper 
	ON PRIMARY
	(
		name = 'DBHelper_data',
		filename = 'D:\sqldb\Sql2008\DBHelper_data.mdf',
		size = 5mb,
		maxsize = 100mb,
		filegrowth = 15%
	)
	LOG ON 
	(
		name = 'DBHelper_log',
		filename = 'D:\sqldb\Sql2008\DBHelper_data.ldf',
		size = 2mb,
		filegrowth = 1mb
	)
END
GO

IF NOT EXISTS (select 1 From master.dbo.sysdatabases where name='DBHelperTest')
BEGIN
	CREATE DATABASE DBHelperTest 
	ON PRIMARY
	(
		name = 'DBHelperTest_data',
		filename = 'D:\sqldb\Sql2008\DBHelperTest_data.mdf',
		size = 5mb,
		maxsize = 100mb,
		filegrowth = 15%
	)
	LOG ON 
	(
		name = 'DBHelperTest_log',
		filename = 'D:\sqldb\Sql2008\DBHelperTest_data.ldf',
		size = 2mb,
		filegrowth = 1mb
	)
END
