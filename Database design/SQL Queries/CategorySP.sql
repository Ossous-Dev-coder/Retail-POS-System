CREATE PROCEDURE SP_addNewCategory (
	@name VARCHAR(50), 
	@description VARCHAR(200), 
	@imagePath VARCHAR(300))

AS
	BEGIN
		SET NOCOUNT ON;
		
		INSERT INTO Categories (name, description, createdAt, imagePath)
		VALUES (@name, @description, GETDATE(), @imagePath)

		SELECT SCOPE_IDENTITY();
	END
GO
--====================================================
CREATE PROCEDURE SP_isCategoryExists(@category_id INT) AS 

BEGIN
	SELECT 1 FROM Categories WHERE id = @category_id;
END
--=====================================================
GO 

CREATE PROCEDURE SP_updateCategory (
	@id INT,
	@name VARCHAR(50), 
	@description VARCHAR(200), 
	@imagePath VARCHAR(300))

AS
	BEGIN
		
		UPDATE Categories SET name = @name, description = @description, imagePath = @imagePath
		WHERE id = @id;
	
	END
--=========================================================================
GO

CREATE PROCEDURE SP_getAllCategories
AS 
	BEGIN
		SET NOCOUNT ON;

		SELECT 
				id,
				name,
				description,
				imagePath,
				createdAt,
				updatedAt
		FROM	Categories
		ORDER BY createdAt;

	END
--================================================================
GO

CREATE PROCEDURE SP_deleteCategory @category_id INT -- Later
AS
	BEGIN
		
		UPDATE Products SET isDeleted = 1, deletedAt = GETDATE() WHERE category_id = @category_id
		DELETE FROM Categories WHERE id = @category_id

	END
