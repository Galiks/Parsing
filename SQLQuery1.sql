USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Parsing') 
BEGIN 
DROP DATABASE Parsing
END 
GO 

CREATE DATABASE Parsing
GO 

USE Parsing
GO

Create Table Discount(
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Discount] primary key,
	[Description] varchar(200),
	[Data_begin] datetime,
	[Data_end] datetime,
	[Data_add] datetime NOT NULL,
	Discount_percent float NOT NULL,
	Discount_del bit NOT NULL,
	id_shop int
)
go

Create Table Shop(
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Shop] primary key,
	Shop_name varchar(200) NOT NULL,
)
go

ALTER TABLE [Discount] ADD CONSTRAINT [FK_Disscount_Shop]
FOREIGN KEY ([id_shop]) references [Shop]([id])
on delete cascade
on update cascade
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE AddShop --1
	@Name varchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Shop]
           ([Shop_name])
     VALUES
           (@Name)

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE AddDiscount --1
	@Description varchar(200),
	@Data_begin datetime = null,
	@Data_end datetime = null,
	@Data_add datetime,
	@Discount_persent float,
	@Discount_del bit = 0,
	@id_shop int
AS
BEGIN
	INSERT INTO [dbo].[Discount]
           ([Description],
		   [Data_begin],
		   [Data_end],
		   [Data_add],
		   [Discount_percent],
		   [Discount_del],
		   [id_shop])
     VALUES
           (@Description, @Data_begin, @Data_end, @Data_add, @Discount_persent, @Discount_del, @id_shop)

	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE ShowAllDiscounts
AS
BEGIN
	SELECT *
	FROM Discount
END
GO

