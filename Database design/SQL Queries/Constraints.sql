ALTER TABLE Categories
ADD CONSTRAINT CK_Categories_Name_NotEmpty
CHECK (name <> '');

ALTER TABLE Products
ADD CONSTRAINT CK_Products_ImagePath_NotEmpty
CHECK (imagePath <> '');

UPDATE Products SET imagePath = '   ' 

DELETE FROM Products WHERE barcode = '';

SELECT * FROM Products