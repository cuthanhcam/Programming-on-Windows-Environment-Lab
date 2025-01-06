CREATE DATABASE FLIPGAME;
ON

USE FLIPGAME;
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL UNIQUE CHECK (Email LIKE '%@gmail.com'),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(64) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Scores (
    ScoreID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    TimeTaken INT NOT NULL, -- Thời gian hoàn thành trò chơi (giây)
    GameDate DATETIME DEFAULT GETDATE()
);

INSERT INTO Users (Email, Username, PasswordHash)
VALUES 
    ('user1@gmail.com', 'user1', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'password1'), 2)),
    ('user2@gmail.com', 'user2', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'password2'), 2));
GO

INSERT INTO Scores (UserID, TimeTaken)
VALUES 
    (1, 120),
    (2, 90);
GO

SELECT * FROM Users;
SELECT * FROM Scores;