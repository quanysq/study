--add MemberInfo table
if not exists (select 1 from sysobjects where id = object_id('MemberInfo') and type = 'U')
begin
create table MemberInfo (
   	MemberID			int					IDENTITY,
	Usercode			varchar(50)			NOT NULL,
	UserName			varchar(50)			NOT NULL,
	Pwd					varchar(50)			NOT NULL,
	Sex					varchar(10)			NOT NULL,
	Phone				varchar(50)			NOT NULL,
	BirthDate			datetime			NOT NULL,
	constraint PK_MemberInfo primary key (MemberID),
   	constraint UK_MemberInfo unique(Usercode)
)
end
GO

--add MemberAddress table
if not exists (select 1 from sysobjects where id = object_id('MemberAddress') and type = 'U')
begin
create table MemberAddress (
   	MemberID			int					IDENTITY,	
	Address				varchar(50)			NOT NULL,
	IsDault				int					NOT NULL DEFAULT 0,
   	constraint UK_MemberAddress unique(MemberID, Address),
   	constraint FK_MemberAddress_MemberInfo foreign key(MemberID) references MemberInfo(MemberID)
)
end
GO

--add ProductType table
if not exists (select 1 from sysobjects where id = object_id('ProductType') and type = 'U')
begin
create table ProductType (					
   	ProductTypeID		int					IDENTITY,
	TypeName			varchar(50)			NOT NULL,
	TypeDesc			varchar(200)				,
   	constraint PK_ProductType primary key(ProductTypeID)
)
end
GO

--add Product table
if not exists (select 1 from sysobjects where id = object_id('Product') and type = 'U')
begin
create table Product (					
   	ProductID			int					IDENTITY,	
	ProductTypeID		int					NOT NULL,
	ProductName			varchar(50)			NOT NULL,	
	ProductCode			varchar(50)			NOT NULL,
	ProductCorp			varchar(50)					,
	ProductBrand		varchar(50)					,
	ProductAcea			varchar(50)					,
	ProductPack			varchar(50)					,
	ProductWeight		varchar(50)					,
	ProductSize			varchar(50)					,
	ProductMPrice		money				NOT NULL,
	ProductQPrice		money				NOT NULL,
	ProductImage1		varchar(50)					,
	ProductImage2		varchar(50)					,
	ProductImage3		varchar(50)					,
	ProductImage4		varchar(50)					,
	ProductRemark		varchar(50)					,
	UploadDate			datetime			NOT NULL DEFAULT getdate(),
	VeiwNum				int					NOT NULL DEFAULT 0,
   	constraint PK_Product primary key(ProductID),
   	constraint FK_Product_ProductType foreign key(ProductTypeID) references ProductType(ProductTypeID),
   	constraint UK_Product_ProductCode unique(ProductCode),
   	constraint UK_Product_ProductName unique(ProductName)
)
end
GO

--add OrderMain table
if not exists (select 1 from sysobjects where id = object_id('OrderMain') and type = 'U')
begin
create table OrderMain (					
   	OrderNo				varchar(50)			NOT NULL,
	MemberID			int					NOT NULL,
	OrderNum			int					NOT NULL,
	OrderMoney			money				NOT NULL,
	OrderFreight		money				NOT NULL DEFAULT 0,
	Receiver			varchar(50)			NOT NULL,
	ReceiveAddress		varchar(50)			NOT NULL,
	ReceiverPhone		varchar(50)			NOT NULL,
	OrderStatus			varchar(50)			NOT NULL DEFAULT 0,
	OrderDate			datetime			NOT NULL DEFAULT getdate(),
   	constraint PK_OrderMain primary key(OrderNo),
   	constraint FK_OrderMain_MemberInfo foreign key(MemberID) references MemberInfo(MemberID)
)
end
GO

--add OrderDetail table
if not exists (select 1 from sysobjects where id = object_id('OrderDetail') and type = 'U')
begin
create table OrderDetail (					
   	OrderDetailID		int					IDENTITY,
	OrderNo				varchar(50)			NOT NULL,
	ProductID			int					NOT NULL,
	ProductNum			int					NOT NULL,
	ProductPrice		money				NOT NULL,
	OrderMoney			money				NOT NULL,
	OrderFreight		money				NOT NULL DEFAULT 0,
   	constraint PK_OrderDetail primary key(OrderNo),
   	constraint FK_OrderDetail_OrderMain foreign key(OrderNo) references OrderMain(OrderNo)
)
end
GO

