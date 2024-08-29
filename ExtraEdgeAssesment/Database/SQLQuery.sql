create table brand
(
    BrandID INT IDENTITY(1,1) PRIMARY KEY,
    BrandName NVARCHAR(100) NOT NULL,
)

select * from brand

CREATE TABLE mobile (
    MobileID INT IDENTITY(1,1) PRIMARY KEY,
    BrandID INT NOT NULL,
    ModelName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2),
    FOREIGN KEY (BrandID) REFERENCES brand(BrandID)
);
select * from mobile

CREATE TABLE orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME NOT NULL,
    CustomerName NVARCHAR(100),
    TotalAmount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(50)
);

select * from orders

CREATE TABLE orderdetails (
   OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    MobileID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES orders(OrderID),
    FOREIGN KEY (MobileID) REFERENCES mobile(MobileID)
);

ALTER TABLE orderdetails
ADD Discount DECIMAL(10, 2) NOT NULL DEFAULT 0;

select * from orderdetails

	CREATE TABLE mobilepricehistory (
    PriceHistoryID INT IDENTITY(1,1) PRIMARY KEY,
    MobileID INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    EffectiveDate DATETIME NOT NULL,
    FOREIGN KEY (MobileID) REFERENCES mobile(MobileID)
);
select * from mobilepricehistory


INSERT INTO mobilepricehistory (MobileID, Price, EffectiveDate) VALUES
(1, 19000.00, '2024-07-01'),
(2, 29000.00, '2024-07-01'),
(3, 49000.00, '2024-07-01'),
(5, 25999.00, '2024-07-01'),
(6, 29999.00, '2024-07-01'),
(8, 43999.00, '2024-07-01'),
(9, 52999.00, '2024-07-01');

-- Insert updated prices as of 2024-08-15
INSERT INTO mobilepricehistory (MobileID, Price, EffectiveDate) VALUES
(10, 21999.00, '2024-08-15'),
(11, 31999.00, '2024-08-15');

INSERT INTO mobilepricehistory (MobileID, Price, EffectiveDate) VALUES
(3, 21999.00, '2024-08-15')

CREATE TABLE users (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Email NVARCHAR(256) NOT NULL,      
    Password NVARCHAR(256) NOT NULL    
);

select * from users