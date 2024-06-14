GO
CREATE DATABASE BookStoreDB

USE BookStoreDB 

GO 
CREATE TABLE Genres
(
 GenreId INT PRIMARY KEY IDENTITY(1,1), 
 GenreName VARCHAR(20) NOT NULL
)
GO 
CREATE TABLE Authors
(
 AuthorId INT PRIMARY KEY IDENTITY(1,1), 
 AuthorName VARCHAR(30) NOT NULL, 
 AuthorSurname VARCHAR(30) NOT NULL,
)
GO 
CREATE TABLE Publishers
(
 PublisherId INT PRIMARY KEY IDENTITY(1,1), 
 PublisherName VARCHAR(50) NOT NULL
)
GO 
CREATE TABLE Books
(
 BookId INT PRIMARY KEY IDENTITY(1,1),
 Title VARCHAR(80) NOT NULL, 
 GenreId INT FOREIGN KEY REFERENCES Genres(GenreId),
 PublicationYear VARCHAR(4) DEFAULT('2024'), 
 AuthorId INT FOREIGN KEY REFERENCES Authors(AuthorId), 
 PublisherId INT FOREIGN KEY REFERENCES Publishers(PublisherId)
)

GO 
INSERT INTO Genres VALUES ('Fantasy')
INSERT INTO Genres VALUES ('Mystery')
INSERT INTO Genres VALUES ('Horror')

GO 
INSERT INTO Authors VALUES ('J.K.', 'Rowling')
INSERT INTO Authors VALUES ('George R.R.', 'Martin')
INSERT INTO Authors VALUES ('J.R.R.', 'Tolkien')
INSERT INTO Authors VALUES ('Agatha', 'Christie')
INSERT INTO Authors VALUES ('Stephen', 'King')

GO 
INSERT INTO Publishers VALUES ('Bloomsbury Publishing')
INSERT INTO Publishers VALUES ('Bantam Books')
INSERT INTO Publishers VALUES ('HarperCollins')
INSERT INTO Publishers VALUES ('Penguin Random House')
INSERT INTO Publishers VALUES ('Hachette Book Group')

GO 
INSERT INTO Books VALUES ('Harry Potter and the Sorcerer''s Stone', 1, '1997', 1, 1)
INSERT INTO Books VALUES ('A Game of Thrones', 1, '1996', 2, 2)
INSERT INTO Books VALUES ('The Fellowship of the Ring', 1, '1954', 3, 3)
INSERT INTO Books VALUES ('Murder on the Orient Express', 2, '1934', 4, 4)
INSERT INTO Books VALUES ('The Shining', 3, '1977', 5, 5)