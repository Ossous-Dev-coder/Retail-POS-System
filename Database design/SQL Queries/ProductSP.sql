ALTER PROCEDURE SP_addNewProduct 
	@productBarcode VARCHAR(50), 
	@productName VARCHAR(50), 
	@description VARCHAR(200), 
	@unitPrice DECIMAL(11,2),
	@quantity DECIMAL(11,2),
	@imagePath VARCHAR(300), 
	@category_id INT, 
	@pricingType_id INT

AS
	BEGIN
		SET NOCOUNT ON;
		
		INSERT INTO Products (barcode, name, description, createdAt, unitPrice, quantity, imagePath, category_id, pricingType_id)
		VALUES (@productBarcode, @productName, @description, GETDATE(), @unitPrice, @quantity, @imagePath, @category_id, @pricingType_id)

		SELECT SCOPE_IDENTITY() AS NewProductId;
	END

GO
--===================================================

ALTER PROCEDURE SP_updateProduct
	@product_id INT,
	@productBarcode VARCHAR(50), 
	@productName VARCHAR(50), 
	@description VARCHAR(200), 
	@unitPrice DECIMAL(11,2),
	@quantity DECIMAL(11,2),
	@imagePath VARCHAR(300), 
	@category_id INT, 
	@pricingType_id INT
AS
	BEGIN

		
		UPDATE Products SET 
		barcode = @productBarcode,
		name = @productName,
		description = @description,
		updatedAt = GETDATE(),
		unitPrice = @unitPrice,
		quantity = @quantity,
		imagePath = @imagePath,
		category_id = @category_id,
		pricingType_id = @pricingType_id

		WHERE id = @product_id;

	END


GO 
--============================================================

ALTER PROCEDURE SP_getAllProducts 
(
    @category_id INT
)
AS 
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.id,
        p.barcode,
        p.name,
        p.description,
        p.unitPrice,
        p.quantity,
        p.imagePath,

        p.category_id,
        c.name AS categoryName,

        p.pricingType_id,
        pt.name AS pricingTypeName,

        p.createdAt,
        p.updatedAt
    FROM Products p
    INNER JOIN Categories c ON c.id = p.category_id
    INNER JOIN PricingTypes pt ON pt.id = p.pricingType_id
    WHERE 
        p.category_id = @category_id 
        AND p.isDeleted = 0
    ORDER BY p.createdAt DESC;
END
GO
--===================================================================

ALTER PROCEDURE SP_getDeletedProducts
AS 
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.id,
        p.barcode,
        p.name,
        p.description,
        p.unitPrice,
        p.quantity,
        p.imagePath,

        p.category_id,
        c.name AS categoryName,

        p.pricingType_id,
        pt.name AS pricingTypeName,

        p.createdAt,
        p.updatedAt,
        p.deletedAt

    FROM Products p
    INNER JOIN Categories c 
        ON c.id = p.category_id
    INNER JOIN PricingTypes pt 
        ON pt.id = p.pricingType_id

    WHERE p.isDeleted = 1
    ORDER BY p.deletedAt DESC;
END

GO
--===============================================

ALTER PROCEDURE SP_deleteProduct @product_id INT
AS
	BEGIN

		UPDATE Products SET isDeleted = 1, deletedAt = GETDATE()
		WHERE id = @product_id AND isDeleted = 0;

	END

GO
--============================================================

ALTER PROCEDURE SP_restoreProduct @product_id INT
AS
	BEGIN

		UPDATE Products SET isDeleted = 0, deletedAt = NULL
		WHERE id = @product_id AND isDeleted = 1;


	END

GO
--==========================================================

ALTER PROCEDURE SP_getProduct 
    @product_id INT
AS 
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.id,
        p.barcode,
        p.name,
        p.description,
        p.unitPrice,
        p.quantity,
        p.imagePath,
        p.category_id,
        c.name AS categoryName,
        p.pricingType_id,
        pt.name AS pricingTypeName,
        p.createdAt,
        p.updatedAt
    FROM Products p
    INNER JOIN Categories c 
        ON c.id = p.category_id
    INNER JOIN PricingTypes pt 
        ON pt.id = p.pricingType_id
    WHERE 
        p.id = @product_id
        AND p.isDeleted = 0;
END
GO 
--=====================================================================

ALTER PROCEDURE SP_getProductByBarcode @barcode VARCHAR(50)
AS 
BEGIN
	SET NOCOUNT ON;

    SELECT 
        p.id,
        p.barcode,
        p.name,
        p.description,
        p.unitPrice,
        p.quantity,
        p.imagePath,
        p.category_id,
        c.name AS categoryName,
        p.pricingType_id,
        pt.name AS pricingTypeName,
        p.createdAt,
        p.updatedAt
    FROM Products p
    INNER JOIN Categories c 
        ON c.id = p.category_id
    INNER JOIN PricingTypes pt 
        ON pt.id = p.pricingType_id
    WHERE 
        p.barcode = @barcode
        AND p.isDeleted = 0;

	END

GO 
--==============================================================

ALTER PROCEDURE SP_getProductByName @productName VARCHAR(50)
AS 
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.id,
        p.barcode,
        p.name,
        p.description,
        p.unitPrice,
        p.quantity,
        p.imagePath,
        p.category_id,
        c.name AS categoryName,
        p.pricingType_id,
        pt.name AS pricingTypeName,
        p.createdAt,
        p.updatedAt
    FROM Products p
    INNER JOIN Categories c 
        ON c.id = p.category_id
    INNER JOIN PricingTypes pt 
        ON pt.id = p.pricingType_id
    WHERE 
        p.name = @productName
        AND p.isDeleted = 0;
	END

GO 