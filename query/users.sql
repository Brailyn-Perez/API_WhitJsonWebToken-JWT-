CREATE DATABASE API_JWT
GO 

USE API_JWT
GO

CREATE TABLE Users(
[ID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50),
[E-mail] VARCHAR(50),
[Password] VARCHAR(100)
)
GO

CREATE TABLE Products(
[ID] INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50),
[Brand] VARCHAR(50),
[Price] DECIMAL(10,2)
)
GO

delete from Users

SELECT * FROM Users
GO

SELECT * FROM Products
GO

INSERT INTO Products (Name, Brand, Price) VALUES  
('Laptop', 'Dell', 950.00),  
('Smartphone', 'Samsung', 750.00),  
('Monitor', 'LG', 200.00),  
('Teclado Mecánico', 'Razer', 120.00),  
('Mouse Inalámbrico', 'Logitech', 50.00),  
('Disco Duro Externo 1TB', 'Western Digital', 80.00),  
('Memoria RAM 16GB', 'Corsair', 95.00),  
('Procesador Ryzen 7', 'AMD', 300.00),  
('Tarjeta Gráfica RTX 4060', 'NVIDIA', 450.00),  
('Impresora Multifuncional', 'HP', 180.00),  
('Auriculares Bluetooth', 'Sony', 130.00),  
('Tablet', 'Apple', 900.00),  
('Smartwatch', 'Garmin', 250.00),  
('Router Wi-Fi 6', 'TP-Link', 110.00),  
('Cámara Web Full HD', 'Logitech', 85.00),  
('Silla Gamer', 'Corsair', 290.00),  
('Disco SSD 500GB', 'Samsung', 100.00),  
('Fuente de Poder 750W', 'EVGA', 140.00),  
('Microondas Digital', 'Panasonic', 200.00),  
('Refrigerador Doble Puerta', 'LG', 1200.00);  
GO

select NEWID()