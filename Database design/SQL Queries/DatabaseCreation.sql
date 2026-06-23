--CREATE DATABASE GroceryPosDb

CREATE Database GroceryPosDb

GO 

USE GroceryPosDb;

GO

CREATE TABLE Categories (
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL CHECK (name <> ''),
	description VARCHAR(200) NULL,
	createdAt DATETIME2 DEFAULT GETDATE(),
	updatedAt DATETIME2 NULL,
	imagePath VARCHAR(300) NULL) -- Done


CREATE TABLE PricingTypes (
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL CHECK (name <> '')) -- Done

CREATE TABLE Products(
	id INT IDENTITY(1,1) PRIMARY KEY,
	barcode VARCHAR(50) UNIQUE NULL,
	name VARCHAR(50) NOT NULL CHECK (name <> ''),
	description VARCHAR(200) NULL,
	createdAt DATETIME2 DEFAULT GETDATE(),
	updatedAt DATETIME2 NULL,
	unitPrice DECIMAL(11,2) NOT NULL CHECK (unitPrice > 0),
	quantity DECIMAL(11,2) NOT NULL CHECK (quantity >= 0),
	imagePath VARCHAR(300) NULL CHECK (name <> ''),
	category_id INT NOT NULL,
	pricingType_id INT  NOT NULL,

	CONSTRAINT FK_ProductCategory
	FOREIGN KEY (category_id) 
	REFERENCES Categories(id),

	CONSTRAINT FK_PricingType
	FOREIGN KEY (pricingType_id)
	REFERENCES PricingTypes(id)
	) -- Done

CREATE TABLE MovementTypes (
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL) -- Done

CREATE TABLE StockMovements (
	id INT IDENTITY(1,1) PRIMARY KEY,
	createdAt DATETIME2 DEFAULT GETDATE(),
	product_id INT NOT NULL,
	movementType_id INT NOT NULL,
	quantity DECIMAL(11,2) CHECK (quantity >= 0) NOT NULL,

	CONSTRAINT FK_Product
	FOREIGN KEY (product_id)
	REFERENCES Products(id),
	
	CONSTRAINT FK_MovementType
	FOREIGN KEY (movementType_id)
	REFERENCES MovementTypes(id))


CREATE TABLE BillStatuses(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL)

CREATE TABLE PaymentMethods(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL)

CREATE TABLE Bills(
	id INT IDENTITY(1,1) PRIMARY KEY,
	createdAt DATETIME2 DEFAULT GETDATE(),
	updatedAt DATETIME2 NULL,
	totalPrice DECIMAL(11,2) NOT NULL,
	paymentMethod_id INT NOT NULL,
	billStatus_id INT NOT NULL,
	
	CONSTRAINT FK_PaymentMethod
	FOREIGN KEY (paymentMethod_id)
	REFERENCES PaymentMethods(id),
	
	CONSTRAINT FK_BillStatus
	FOREIGN KEY (billStatus_id)
	REFERENCES BillStatuses(id))



CREATE TABLE BillItems(
	id INT IDENTITY(1,1) PRIMARY KEY,
	product_Id INT NULL,
	productName VARCHAR(50) NOT NULL,
	quantity DECIMAL(11,2) NOT NULL,
	unitPrice DECIMAL(11,2) NOT NULL CHECK (unitPrice > 0),
	totalPrice DECIMAL(11,2) NOT NULL,
	bill_id INT NOT NULL,
	
	CONSTRAINT FK_ItemBill
	FOREIGN KEY (bill_id)
	REFERENCES Bills(id),
	
	CONSTRAINT FK_BillItemProduct
	FOREIGN KEY (product_Id)
	REFERENCES Products(id))





CREATE INDEX IX_Products_BarCode
ON Products(barCode)

GO 

CREATE INDEX IX_Products_Name ON Products(name)

GO

CREATE INDEX IX_BillItems_BillId
ON BillItems(bill_id);

GO

CREATE INDEX IX_StockMovements_ProductId
ON StockMovements(product_id);
	
CREATE INDEX IX_StockMovements_MovementTypeId
ON StockMovements(MovementType_id);

CREATE INDEX IX_StockMovements_Filter
ON StockMovements (createdAt, product_id, movementType_id);