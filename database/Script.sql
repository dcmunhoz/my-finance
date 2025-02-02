-- IDENTITY

CREATE DATABASE "IDENTITY"
GO

USE "IDENTITY"
GO

CREATE TABLE USERS(
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    NAME NVARCHAR(255) NOT NULL,
    EMAIL NVARCHAR(320) UNIQUE NOT NULL,
    PASSWORD NVARCHAR(64) NOT NULL,
    CREATEDAT DATETIME NOT NULL DEFAULT GETDATE()
)
GO

-- FINANCE

CREATE DATABASE "FINANCE"
GO

USE FINANCE
GO

CREATE TABLE CATEGORIES(
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    TYPE INTEGER NOT NULL,
    DESCRIPTION NVARCHAR(255) NOT NULL,
    COLOR NVARCHAR(6) NOT NULL,
    PARENTID UNIQUEIDENTIFIER,
    LEVEL INTEGER NOT NULL,
    USERID UNIQUEIDENTIFIER NOT NULL
)
GO

CREATE TABLE REASONS(
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    TYPE INTEGER NOT NULL,
    DESCRIPTION NVARCHAR(255) NOT NULL,
    COLOR NVARCHAR(6),
    USERID UNIQUEIDENTIFIER NOT NULL
)
GO