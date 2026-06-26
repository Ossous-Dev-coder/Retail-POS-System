
-- Categories

INSERT INTO Categories (name, description, imagePath)
VALUES
('Bakery', 'Bread and bakery products', NULL),
('Dairy', 'Milk, cheese and dairy products', NULL),
('Meat', 'Chicken, beef and protein products', NULL),
('Basic Food', 'Rice, flour, legumes and staples', NULL),
('Spices', 'Moroccan spices and seasoning', NULL),
('Drinks', 'Water, juice and beverages', NULL),
('Snacks', 'Biscuits, chips and sweets', NULL);

GO


INSERT INTO PricingTypes (name)
VALUES
('Unit'),
('Weight'),
('Pack');

GO

INSERT INTO Products (barcode, name, description, unitPrice, quantity, imagePath, category_id, pricingType_id)
VALUES
-- Bakery
('611000111001', 'Khobz Blanc', 'White Moroccan bread', 1.20, 1, NULL, 1, 1),
('611000111002', 'Khobz Dial Dar', 'Homemade Moroccan bread', 1.50, 1, NULL, 1, 1),
('611000111003', 'Batbout', 'Moroccan flatbread', 1.00, 1, NULL, 1, 1),

-- Dairy
('611000222001', 'Lait Centrale 1L', 'Fresh milk 1 liter', 7.50, 1, NULL, 2, 1),
('611000222002', 'Raibi Jamila', 'Moroccan yogurt drink', 3.00, 1, NULL, 2, 1),
('611000222003', 'La Vache Qui Rit', 'Processed cheese portions', 12.00, 8, NULL, 2, 1),
('611000222004', 'Jben', 'Fresh Moroccan cheese', 25.00, 0.25, NULL, 2, 1),

-- Meat
('611000333001', 'Poulet entier', 'Whole chicken', 65.00, 1, NULL, 3, 2),
('611000333002', 'Kefta', 'Minced meat', 95.00, 1, NULL, 3, 2),
('611000333003', 'Œufs 12 pcs', 'Pack of 12 eggs', 18.00, 12, NULL, 3, 1),

-- Basic Food
('611000444001', 'Riz', 'Long grain rice', 12.00, 1, NULL, 4, 1),
('611000444002', 'Lentilles', 'Brown lentils', 14.00, 1, NULL, 4, 1),
('611000444003', 'Haricots blancs', 'White beans', 16.00, 1, NULL, 4, 1),
('611000444004', 'Farine', 'White flour', 8.00, 1, NULL, 4, 1),
('611000444005', 'Semoule', 'Fine semolina', 10.00, 1, NULL, 4, 1),

-- Spices
('611000555001', 'Ras El Hanout', 'Moroccan spice mix', 5.00, 0.05, NULL, 5, 1),
('611000555002', 'Cumin', 'Ground cumin', 4.00, 0.05, NULL, 5, 1),
('611000555003', 'Paprika', 'Sweet paprika', 4.50, 0.05, NULL, 5, 1),
('611000555004', 'Saffron', 'Premium saffron', 35.00, 0.001, NULL, 5, 1),

-- Drinks
('611000666001', 'Sidi Ali 1.5L', 'Mineral water', 5.00, 1, NULL, 6, 1),
('611000666002', 'Oulmès', 'Sparkling water', 6.00, 1, NULL, 6, 1),
('611000666003', 'Jus d''orange', 'Orange juice', 8.00, 1, NULL, 6, 1),
('611000666004', 'Thé Atlas', 'Green tea', 20.00, 0.25, NULL, 6, 1),

-- Snacks
('611000777001', 'Biscuit Maruja', 'Sweet biscuits', 2.50, 1, NULL, 7, 1),
('611000777002', 'Chocolat Aiguebelle', 'Milk chocolate', 6.00, 0.10, NULL, 7, 1),
('611000777003', 'Chips Hawaii', 'Potato chips', 3.00, 1, NULL, 7, 1);


GO

INSERT INTO MovementTypes (Name, StockEffect)
VALUES
('Purchase', 1),
('Purchase Return', -1),
('Sale', -1),
('Sales Return', 1),
('Stock Adjustment Increase', 1),
('Stock Adjustment Decrease', -1),
('Opening Balance', 1),
('Stock Transfer In', 1),
('Stock Transfer Out', -1),
('Damaged Goods', -1),
('Expired Goods', -1),
('Inventory Count Correction', 0);

GO

INSERT INTO StockMovements (product_id, movementType_id, quantity)
VALUES
-- Product 1
(1,1,120),(1,2,15),(1,2,12),(1,3,2),(1,4,1),(1,2,18),

-- Product 2
(2,1,90),(2,2,10),(2,2,8),(2,3,1),(2,4,2),(2,2,14),

-- Product 3
(3,1,150),(3,2,20),(3,2,25),(3,3,3),(3,4,1),(3,2,12),

-- Product 4
(4,1,80),(4,2,6),(4,2,9),(4,3,1),(4,4,2),(4,2,11),

-- Product 5
(5,1,200),(5,2,22),(5,2,30),(5,3,4),(5,4,3),(5,2,18),

-- Product 6
(6,1,175),(6,2,14),(6,2,16),(6,3,2),(6,4,1),(6,2,20),

-- Product 7
(7,1,95),(7,2,11),(7,2,7),(7,3,1),(7,4,1),(7,2,13),

-- Product 8
(8,1,130),(8,2,18),(8,2,15),(8,3,2),(8,4,2),(8,2,21),

-- Product 9
(9,1,110),(9,2,9),(9,2,12),(9,3,1),(9,4,1),(9,2,14),

-- Product 10
(10,1,160),(10,2,20),(10,2,18),(10,3,2),(10,4,2),(10,2,24),

-- Product 11
(11,1,210),(11,2,30),(11,2,25),(11,3,3),(11,4,2),(11,2,28),

-- Product 12
(12,1,145),(12,2,14),(12,2,17),(12,3,2),(12,4,1),(12,2,19),

-- Product 13
(13,1,125),(13,2,13),(13,2,15),(13,3,1),(13,4,1),(13,2,16),

-- Product 14
(14,1,190),(14,2,22),(14,2,19),(14,3,2),(14,4,3),(14,2,25),

-- Product 15
(15,1,220),(15,2,27),(15,2,24),(15,3,3),(15,4,2),(15,2,30),

-- Product 16
(16,1,300),(16,2,35),(16,2,40),(16,3,5),(16,4,4),(16,2,32),

-- Product 17
(17,1,260),(17,2,31),(17,2,28),(17,3,3),(17,4,2),(17,2,26),

-- Product 18
(18,1,170),(18,2,16),(18,2,18),(18,3,2),(18,4,1),(18,2,20),

-- Product 19
(19,1,240),(19,2,29),(19,2,22),(19,3,4),(19,4,2),(19,2,27);


GO 

INSERT INTO Users (firstName, lastName, phone, email, passwordHash, hashSalt, permissions, updatedAt, imagePath)
VALUES 
('Jane', 'Doe', '555-0199', 'jane.doe@example.com', 'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'salt_xyz123', 7, NULL, '/uploads/avatars/jane_doe.png'),

('John', 'Smith', '555-0142', 'john.smith@example.com', '86f7e437faa5a7fce15d1ddcb9eaeaea377667b8', 'salt_abc456', 1, NULL, NULL),

('Alice', 'Johnson', NULL, 'alice.j@example.com', 'abcdef437faa5a7fce15d1ddcb9eaeaea377667b8', 'salt_qrs789', 3, NULL, '/uploads/avatars/alice_j.jpg'),

('Bob', 'Miller', '555-0177', 'bob.miller@example.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'salt_tuv012', 1, NULL, NULL),

('Charlie', 'Brown', '555-0185', 'charlie.b@example.com', '240be518fabd2724ddb6f04eeb1da14157b91876f503514763049800a29dac47', 'salt_wxyz567', 15, NULL, '/uploads/avatars/charlie_b.png');