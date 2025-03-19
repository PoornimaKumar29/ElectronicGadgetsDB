
-----------------------------insert values into table------------------------------
--- Insert Sample Data into Customers---
INSERT INTO Customers (Customer_id,Customer_FirstName, Customer_LastName, Customer_Email, Customer_Phone, Address) VALUES
(1, 'John', 'Doe', 'john.doe@example.com', 9876543210, '123 Main St, New York'),
(2, 'Alice', 'Smith', 'alice.smith@example.com', 8765432109, '456 Elm St, California'),
(3, 'Robert', 'Brown', 'robert.brown@example.com', 7654321098, '789 Pine St, Texas'),
(4, 'Emily', 'Johnson', 'emily.johnson@example.com', 6543210987, '321 Oak St, Florida'),
(5, 'Michael', 'Williams', 'michael.williams@example.com', 7432109876, '987 Birch St, Illinois'),
(6, 'Sophia', 'Anderson', 'sophia.anderson@example.com', 7321098765, '564 Maple St, Ohio'),
(7, 'Daniel', 'Martinez', 'daniel.martinez@example.com', 7210987654, '891 Cedar St, Arizona'),
(8, 'Olivia', 'Taylor', 'olivia.taylor@example.com', 7109876543, '234 Walnut St, Michigan'),
(9, 'James', 'Thomas', 'james.thomas@example.com', 7098765432, '678 Oakwood St, Georgia'),
(10, 'Isabella', 'White', 'isabella.white@example.com', 6987654321, '345 Redwood St, Nevada');
INSERT INTO Customers (Customer_id, Customer_FirstName, Customer_LastName, Customer_Email, Customer_Phone, Address) VALUES
(11, 'Ethan', 'Clark', 'ethan.clark@example.com', 6876543210, '789 Park Ave, California'),
(12, 'Ava', 'Lewis', 'ava.lewis@example.com', 6765432109, '456 Green St, Texas'),
(13, 'Noah', 'Harris', 'noah.harris@example.com', 6654321098, '123 Blue St, Florida'),
(14, 'Mia', 'Walker', 'mia.walker@example.com', 6543210977, '890 Sunset Blvd, New York'),
(15, 'William', 'Allen', 'william.allen@example.com', 6432109866, '567 River Rd, Illinois'),
(16, 'Charlotte', 'Young', 'charlotte.young@example.com', 6321098755, '321 Oak Ave, Ohio'),
(17, 'Benjamin', 'King', 'benjamin.king@example.com', 6210987644, '745 Cypress St, Arizona'),
(18, 'Emma', 'Wright', 'emma.wright@example.com', 6109876533, '908 Silver St, Michigan'),
(19, 'Lucas', 'Scott', 'lucas.scott@example.com', 6098765422, '333 Golden Rd, Georgia'),
(20, 'Harper', 'Green', 'harper.green@example.com', 6987654311, '258 Mountain Dr, Nevada');

-- Insert Sample Data into Products--

INSERT INTO Products (Product_id,Product_Name, Product_Description, Product_Price) VALUES
(1, 'Laptop', 'High-performance laptop', 1200.00),
(2, 'Smartphone', 'Latest 5G smartphone', 800.00),
(3, 'Tablet', '10-inch display tablet', 500.00),
(4, 'Smartwatch', 'Fitness and health tracking smartwatch', 250.00),
(5, 'Headphones', 'Noise-cancelling headphones', 150.00),
(6, 'Keyboard', 'Mechanical gaming keyboard', 100.00),
(7, 'Mouse', 'Wireless ergonomic mouse', 50.00),
(8, 'Monitor', '27-inch 4K monitor', 400.00),
(9, 'Printer', 'Laser printer with wireless connectivity', 300.00),
(10, 'External HDD', '1TB external hard drive', 120.00),
(11, 'Speaker', 'Bluetooth portable speaker', 200.00),
(12, 'Webcam', 'HD webcam with microphone', 75.00),
(13, 'Router', 'Dual-band WiFi router', 180.00),
(14, 'SSD', '512GB NVMe SSD', 130.00),
(15, 'Graphics Card', '8GB VRAM gaming GPU', 500.00),
(16, 'Power Bank', '20000mAh fast charging power bank', 60.00),
(17, 'Tripod', 'Adjustable camera tripod', 40.00),
(18, 'VR Headset', 'Virtual reality gaming headset', 350.00),
(19, 'Smart TV', '50-inch 4K Smart TV', 1000.00),
(20, 'Gaming Chair', 'Ergonomic gaming chair with lumbar support', 250.00);

-- Insert Sample Data into Orders--

INSERT INTO Orders (Order_id, Customer_id, Order_Date, Total_Amount) VALUES

(1, 1, '2024-03-01', 1400.00),
(2, 2, '2024-03-02', 1050.00),
(3, 3, '2024-03-05', 1800.00),
(4, 4, '2024-03-07', 250.00),
(5, 5, '2024-03-10', 400.00),
(6, 6, '2024-03-12', 850.00),
(7, 7, '2024-03-15', 300.00),
(8, 8, '2024-03-18', 500.00),
(9, 9, '2024-03-20', 100.00),
(10, 10, '2024-03-25', 700.00),
(11, 11, '2024-03-26', 650.00),
(12, 12, '2024-03-27', 1200.00),
(13, 13, '2024-03-28', 500.00),
(14, 14, '2024-03-29', 1300.00),
(15, 15, '2024-03-30', 2000.00),
(16, 16, '2024-04-01', 900.00),
(17, 17, '2024-04-02', 450.00),
(18, 18, '2024-04-03', 320.00),
(19, 19, '2024-04-04', 290.00),
(20, 20, '2024-04-05', 1000.00);

-- Insert Sample Data into OrderDetails
INSERT INTO OrderDetails (OrderDetail_id,Order_id, Product_id, Quantity) VALUES
(1, 1, 1, 1),
(2, 1, 5, 2),
(3, 2, 2, 1),
(4, 2, 6, 5),
(5, 3, 3, 2),
(6, 3, 4, 1),
(7, 4, 4, 5),
(8, 5, 8, 3),
(9, 6, 9, 4),
(10, 7, 10, 2),
(11, 8, 3, 1),
(12, 9, 7, 1),
(13, 10, 5, 3),
(14, 11, 12, 2),
(15, 12, 13, 3),
(16, 13, 14, 6),
(17, 14, 15, 5),
(18, 15, 16, 2),
(19, 16, 17, 7),
(20, 17, 18, 3);

-- Insert Sample Data into Inventory
INSERT INTO Inventory (Inventory_id,Product_id, Quantity_InStock, LastStock_Update) VALUES
(1, 1, 10, '2024-03-01'),
(2, 2, 15, '2024-03-02'),
(3, 3, 8, '2024-03-05'),
(4, 4, 12, '2024-03-07'),
(5, 5, 20, '2024-03-10'),
(6, 6, 25, '2024-03-12'),
(7, 7, 30, '2024-03-15'),
(8, 8, 18, '2024-03-18'),
(9, 9, 14, '2024-03-20'),
(10, 10, 22, '2024-03-25'),
(11, 11, 16, '2024-03-26'),
(12, 12, 20, '2024-03-27'),
(13, 13, 18, '2024-03-28'),
(14, 14, 12, '2024-03-29'),
(15, 15, 5, '2024-03-30'),
(16, 16, 10, '2024-04-01'),
(17, 17, 15, '2024-04-02'),
(18, 18, 10, '2024-04-03'),
(19, 19, 6, '2024-04-04'),
(20, 20, 8, '2024-04-05');

