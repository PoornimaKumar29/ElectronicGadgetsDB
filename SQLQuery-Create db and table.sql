create database TechShop
use TechShop
-----------------------------------Creating Tables under schema---------------------------
--Table 1.create Customertable--
create table Customers(
Customer_id int,
constraint pk_customerid primary key(Customer_id),
Customer_FirstName varchar(100) not null,
Customer_LastName varchar(100) ,
Customer_Email varchar(100) unique check (Customer_Email like '_%@_%._%'),
--big int doesn't support len property--
--Customer_Phone bigint unique check(Customer_Phone like '[0-9][0-9]%' and len(Customer_Phone) between 10 and 12),
Customer_Phone bigint unique check(Customer_Phone between 6000000000 and 9999999999),
Address varchar(300) not null
)

--Table 2. Create ProductTable--
create table Products(
Product_id int,
constraint pk_productid primary key(Product_id),
Product_Name varchar(100) not null,
Product_description  text,
Product_Price int not null check(Product_Price>=0)
)

--Table 3. Create OrdersTable--
create table Orders(
Order_id int,
constraint pk_orderid primary key(Order_id),
Customer_id int not null,
constraint fk_customerid foreign key(Customer_id) references Customers(Customer_id),
Order_Date date default getdate(),
Total_Amount int not null default 0
)

--Table 4.Create OrderDetailsTable--
create table Orders(
Order_id int,
constraint pk_orderid primary key(Order_id),
Customer_id int not null,
constraint fk_customerid foreign key(Customer_id) references Customers(Customer_id),
Order_Date date default getdate(),
Total_Amount int not null default 0
)

--Table 5. Create InventoryTable--
create table Inventory(
Inventory_id int
constraint pk_inventoryid primary key(Inventory_id),
Product_id int not null
constraint fk_inventoryproductid foreign key(Product_id) references Products(Product_id) on delete cascade,
Quantity_InStock int not null,
LastStock_Update date 
)
