USE [master]
GO
--if exists (select * from sys.databases where name = N'CarDealership')
--begin
--	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CarDealership';
--	ALTER DATABASE CarDealership SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--	DROP DATABASE CarDealership;
--end

IF EXISTS(
   SELECT *
   FROM sys.server_principals
   WHERE [Name] = 'CarApp')
BEGIN
   DROP LOGIN CarApp
END
GO

CREATE LOGIN CarApp WITH PASSWORD='Testing123'

--CREATE DATABASE [CarDealership]
--GO
USE [CarDealership]
GO

ALTER TABLE Cars DROP CONSTRAINT IF EXISTS fk_Cars_Makes;
ALTER TABLE Cars DROP CONSTRAINT IF EXISTS fk_Cars_Models;
GO
ALTER TABLE	Purchases DROP CONSTRAINT IF EXISTS fk_Purchases_AspNetUsers;
ALTER TABLE Purchases DROP CONSTRAINT IF EXISTS fk_Purchases_Cars;
GO


DROP USER IF EXISTS CarApp
GO
CREATE USER CarApp FOR LOGIN CarApp
GO
ALTER ROLE db_backupoperator ADD MEMBER CarApp
ALTER ROLE db_ddladmin ADD MEMBER CarApp
ALTER ROLE db_datareader ADD MEMBER CarApp
ALTER ROLE db_datawriter ADD MEMBER CarApp
GO


DROP TABLE IF EXISTS Specials
GO
CREATE TABLE Specials (
SpecialID INT PRIMARY KEY IDENTITY(0,1),
SpecialName varchar(50) NOT NULL,
SpecialDescription varchar(MAX) NOT NULL
)
ALTER TABLE Models DROP CONSTRAINT IF EXISTS fk_Models_Makes
GO
DROP TABLE IF EXISTS Models
DROP TABLE IF EXISTS Makes
GO
CREATE TABLE Makes (
MakeID INT PRIMARY KEY IDENTITY(0,1),
MakeName nvarchar(20) NOT NULL,
DateAdded date NULL,
UserAdded nvarchar(50) NULL
)


CREATE TABLE Models (
ModelID INT PRIMARY KEY IDENTITY(0,1),
ModelName nvarchar(40) NOT NULL,
DateAdded date NOT NULL,
UserAdded nvarchar(50) NOT NULL,
MakeID INT NOT NULL,
CONSTRAINT fk_Models_Makes FOREIGN KEY (MakeID) REFERENCES Makes(MakeID)
)

DROP TABLE IF EXISTS Cars
GO
CREATE TABLE Cars (
CarID INT PRIMARY KEY IDENTITY(0,1),
VIN char(17) NOT NULL,
BodyStyle varchar(20) NOT NULL,
Transmission varchar(20) NOT NULL,
Interior varchar(20) NOT NULL,
MSRP money NOT NULL,
SalePrice money NOT NULL,
Mileage int NOT NULL,
Color varchar(30) NOT NULL,
CarYear int NOT NULL,
MakeID int NOT NULL,
ModelID int NOT NULL,
CarDescription varchar(MAX) NOT NULL,
IsNew bit NOT NULL,
IsFeatured bit NOT NULL,
ImgExtension varchar(4) NULL,
CONSTRAINT fk_Cars_Makes FOREIGN KEY (MakeID) REFERENCES Makes(MakeID),
CONSTRAINT fk_Cars_Models FOREIGN KEY (ModelID) REFERENCES Models(ModelID)
)

DROP TABLE IF EXISTS Purchases
GO
CREATE TABLE Purchases (
PurchaseID int PRIMARY KEY IDENTITY(0,1),
CarID INT NOT NULL UNIQUE,
[CustomerName] varchar(40) Not Null,
Phone varchar(15) NULL,
Email varchar(40) NULL CHECK (Email IS NULL OR Email LIKE '%@%'),
Street1 varchar(50) NOT NULL,
Street2 varchar(50) NULL,
City varchar(40) NOT NULL,
PurchaseState char(2) NOT NULL,
Zipcode varchar(10) NOT NULL,
Price money NOT NULL,
PurchaseType varchar(20) NOT NULL,
PurchaseDate date NOT NULL,
SellerID nvarchar(128) NOT NULL,
CONSTRAINT fk_Purchases_Cars FOREIGN KEY (CarID) REFERENCES Cars(CarID),
Constraint chk_Purchases_Contactable CHECK (Phone IS NOT NULL OR Email IS NOT NULL)
)

DROP TABLE IF EXISTS Contacts
GO
CREATE TABLE Contacts (
ContactID int PRIMARY KEY Identity(0,1),
ContactName varchar(30) NOT NULL,
Phone varchar(15) NULL,
Email varchar(40) NULL CHECK (Email IS NULL OR Email LIKE '%@%'),
ContactMessage nvarchar(250) NOT NULL,
Constraint chk_Contacts_Contactable CHECK (Phone IS NOT NULL OR Email IS NOT NULL)
)

IF (NOT (SELECT Count(*) FROM Cars) >= 4)
begin
DELETE FROM Cars
DELETE FROM Models
DELETE FROM Makes
SET IDENTITY_INSERT Makes ON
Insert Into Makes(MakeID, MakeName,UserAdded,DateAdded) VALUES 
(0, 'Toyota', 'dbAdmin',GETDATE()),
(1, 'Honda', 'dbAdmin',GETDATE()),
(2, 'Ford', 'dbAdmin',GETDATE())
SET IDENTITY_INSERT Makes OFF
SET IDENTITY_INSERT Models ON
Insert Into Models(ModelID, ModelName, MakeID, UserAdded, DateAdded) VALUES 
(0, 'Corolla', 0, 'dbAdmin',GETDATE()),
(1, 'Accord', 1, 'dbAdmin',GETDATE()),
(2, 'F-150', 2, 'dbAdmin',GETDATE()),
(3, 'Mustang', 2, 'dbAdmin',GETDATE()),
(4, 'Fiesta', 2, 'dbAdmin',GETDATE()),
(5, 'Odyssey', 1, 'dbAdmin',GETDATE()),
(6, 'Camry', 0, 'dbAdmin',GETDATE())
SET IDENTITY_INSERT Models OFF
SET IDENTITY_INSERT Cars ON
Insert Into Cars (CarID, VIN, BodyStyle, Transmission, Interior, MSRP, SalePrice, Mileage, Color, MakeID, ModelID, CarDescription, IsNew, IsFeatured, CarYear) Values
(0, 'thisisnotarealvin', 'Car', 'Automatic', 'Black', 14875, 12875, 100, 'Silver', 1, 1, 'hi there', 1, 0, 2015),
(1, 'thisisnowarealvin', 'Truck', 'Manual', 'Silver', 34875, 32875, 10000, 'Black', 2, 2, 'hi there', 0, 1, 2018)
SET IDENTITY_INSERT Cars OFF

end

DROP PROCEDURE IF EXISTS DeleteByID
GO
CREATE PROCEDURE DeleteByID (
@ID int
) AS
DELETE FROM Cars 
WHERE @ID = CarID
GO
GRANT EXECUTE ON DeleteByID TO CarApp

DROP PROCEDURE IF EXISTS GetByID
GO
CREATE PROCEDURE GetByID (
@ID int
) AS
SELECT 
*
FROM Cars c
WHERE @ID = c.CarID
GO
GRANT EXECUTE ON GetByID TO CarApp


DROP PROCEDURE IF EXISTS GetUsers
GO
CREATE PROCEDURE GetUsers
--(@UserID nvarchar(128))
AS
SELECT 
anu.Id as UserID,
anu.Email,
anr.[Name] AS [Role],
claimFirst.ClaimValue as FirstName,
claimLast.ClaimValue as LastName
FROM AspNetUsers anu
INNER JOIN AspNetUserClaims claimFirst on anu.Id = claimFirst.UserId AND claimFirst.ClaimType = 'FirstName'
INNER JOIN AspNetUserClaims claimLast on anu.Id = claimLast.UserId AND claimLast.ClaimType = 'LastName'
INNER JOIN AspNetUserRoles anur on anu.Id = anur.UserId
INNER JOIN AspNetRoles anr on anur.RoleId = anr.Id
-- WHERE anu.Id = @UserID
GO
GRANT EXECUTE ON GetUsers TO CarApp

DROP PROCEDURE IF EXISTS GetUsersByRole
GO
CREATE PROCEDURE GetUsersByRole
(@Role nvarchar(256))
AS
SELECT 
anu.Id as UserID,
anu.Email,
anr.[Name] AS [Role],
claimFirst.ClaimValue as FirstName,
claimLast.ClaimValue as LastName
FROM AspNetUsers anu
INNER JOIN AspNetUserClaims claimFirst on anu.Id = claimFirst.UserId AND claimFirst.ClaimType = 'FirstName'
INNER JOIN AspNetUserClaims claimLast on anu.Id = claimLast.UserId AND claimLast.ClaimType = 'LastName'
INNER JOIN AspNetUserRoles anur on anu.Id = anur.UserId
INNER JOIN AspNetRoles anr on anur.RoleId = anr.Id
WHERE anr.[Name] = @Role
GO
GRANT EXECUTE ON GetUsersByRole TO CarApp


DROP PROCEDURE IF EXISTS GetUser
GO
CREATE PROCEDURE GetUser
(@UserID nvarchar(128))
AS
SELECT 
anu.Id as UserID,
anu.Email,
anr.[Name] AS [Role],
claimFirst.ClaimValue as FirstName,
claimLast.ClaimValue as LastName
FROM AspNetUsers anu
INNER JOIN AspNetUserClaims claimFirst on anu.Id = claimFirst.UserId AND claimFirst.ClaimType = 'FirstName'
INNER JOIN AspNetUserClaims claimLast on anu.Id = claimLast.UserId AND claimLast.ClaimType = 'LastName'
INNER JOIN AspNetUserRoles anur on anu.Id = anur.UserId
INNER JOIN AspNetRoles anr on anur.RoleId = anr.Id
WHERE anu.Id = @UserID
GO
GRANT EXECUTE ON GetUser TO CarApp
