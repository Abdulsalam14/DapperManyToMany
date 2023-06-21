GO
CREATE DATABASE ManyToMany
GO

USE ManyToMany
GO
CREATE TABLE Authors(
[Id] int IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar (30)
)

CREATE TABLE Books(
[Id] int IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar (30),
[Price] int
)

GO

GO
CREATE TABLE AuthorBook(
[Id] int IDENTITY (1,1) PRIMARY KEY,
[AuthorId] int, 
[BookId] int 
FOREIGN KEY ([AuthorId]) REFERENCES Authors(Id),
FOREIGN KEY ([BookId]) REFERENCES Books(Id) 
)
GO

GO
INSERT INTO Authors
VALUES
('Author1'),
('Author2'),
('Author3')

INSERT INTO Books
VALUES
('Book1',10),
('Book2',12),
('Book3',15),
('Book4',27),
('Book5',22)

GO

GO
INSERT INTO AuthorBook
VALUES 
(1,1),
(1,2),
(2,2),
(2,3),
(3,4),
(3,5)
GO