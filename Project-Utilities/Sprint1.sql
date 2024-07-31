-- Check if the database exists and create it if it doesn't
IF DB_ID('TravelRecommendation') IS NULL
BEGIN
    EXEC('CREATE DATABASE TravelRecommendation');
END
GO

-- Switch to the newly created or existing database
USE TravelRecommendation;
GO

-- Create the User table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UserCredentials')
BEGIN
    CREATE TABLE UserCredentials (
        Id INT IDENTITY PRIMARY KEY,
        Email VARCHAR(50) NOT NULL UNIQUE,
        Password VARCHAR(100) NOT NULL,
        IsActive VARCHAR(50) NOT NULL,
        CreatedOn VARCHAR(50) NOT NULL,
        CreatedBy VARCHAR(50) NOT NULL,
        UpdatedOn VARCHAR(50) NOT NULL,
        UpdatedBy VARCHAR(50) NOT NULL    
);
END
GO

-- Create the UserProfile table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UserProfile')
BEGIN
    CREATE TABLE UserProfile(
        Id INT PRIMARY KEY,
        Email VARCHAR(50) NOT NULL,
        FirstName VARCHAR(50) NOT NULL,
        LastName VARCHAR(50) NOT NULL,
        DOB VARCHAR(50) NOT NULL,
        Gender VARCHAR(10) NOT NULL,
        Motto VARCHAR(255) NULL,
        Country VARCHAR(50) NOT NULL,
        CreatedOn VARCHAR(20) NOT NULL,
        CreatedBy VARCHAR(50) NOT NULL,
        UpdatedOn VARCHAR(20) NULL,
        UpdatedBy VARCHAR(50) NULL,
    );
END
GO

-- Create the UserRole table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UserRole')
BEGIN
    CREATE TABLE UserRole (
        Email VARCHAR(50) NOT NULL,
        Role VARCHAR(50) NOT NULL,
        UpdatedBy VARCHAR(50) NOT NULL,
        UpdatedOn VARCHAR(50) NOT NULL
    );
END
GO

-- Create the Country table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Country')
BEGIN
    CREATE TABLE Country (
        Id INT IDENTITY PRIMARY KEY,
        CountryName VARCHAR(50)
    );
END
GO

INSERT INTO UserRole (Email, Role, UpdatedBy, UpdatedOn)
VALUES (
    'admin@gmail.com',
    'Admin',
    'System',
    FORMAT(GETDATE(), 'MM/dd/yyyy hh:mm:ss tt')  
);

INSERT INTO UserCredentials (Email, Password, IsActive, CreatedOn, CreatedBy, UpdatedBy, UpdatedOn)
VALUES (
    'admin@gmail.com',
    'Password@1023',
     CAST(1 AS VARCHAR),  
     FORMAT(GETDATE(), 'MM/dd/yyyy hh:mm:ss tt'),
    'System',
    'System',  
    FORMAT(GETDATE(), 'MM/dd/yyyy hh:mm:ss tt') 
);


-- Insert into Country table with a country name
INSERT INTO Country (CountryName)
VALUES ('USA');

INSERT INTO Country (CountryName)
VALUES ('India');

INSERT INTO Country (CountryName)
VALUES ('Japan');
