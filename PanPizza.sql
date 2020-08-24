IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'PanPizza')
CREATE database PanPizza;
GO

-- deleting tables
IF OBJECT_ID('tblPizza', 'U') IS NOT NULL DROP TABLE tblPizza;
IF OBJECT_ID('tblSize', 'U') IS NOT NULL DROP TABLE tblSize;

use PanPizza
CREATE TABLE tblSize(SizeID int IDENTITY(1,1) PRIMARY KEY NOT NULL, SizeName nvarchar(50) NOT NULL);

use PanPizza
INSERT INTO tblSize (SizeName) 
VALUES ('Small'),
('Medium'),
('Big');

use PanPizza
CREATE TABLE tblPizza (PizzaID int IDENTITY(1,1) PRIMARY KEY NOT NULL, Salami bit, Ham bit, Kulen bit, Ketchup bit,
Mayonnaise bit, HotPepper bit, Olives bit, Oregano bit, Sesame bit, Cheese bit, Price int,
SizeID int FOREIGN KEY references tblSize(SizeID));