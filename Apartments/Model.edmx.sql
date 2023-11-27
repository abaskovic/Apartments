
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2023 11:16:23
-- Generated from EDMX file: C:\Users\office10\source\repos\abaskovic\Apartments\Apartments\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [app];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ApartmentUploadedFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UploadedFiles] DROP CONSTRAINT [FK_ApartmentUploadedFile];
GO
IF OBJECT_ID(N'[dbo].[FK_CityCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_CityCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_ApartmentUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Apartments] DROP CONSTRAINT [FK_ApartmentUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ApartmentCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Apartments] DROP CONSTRAINT [FK_ApartmentCity];
GO
IF OBJECT_ID(N'[dbo].[FK_ApartmentUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Apartments] DROP CONSTRAINT [FK_ApartmentUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_CityApartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Apartments] DROP CONSTRAINT [FK_CityApartment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Apartments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Apartments];
GO
IF OBJECT_ID(N'[dbo].[UploadedFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UploadedFiles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Apartments'
CREATE TABLE [dbo].[Apartments] (
    [IDApartment] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [CityIDCity] int  NOT NULL,
    [UserIDUser] int  NOT NULL
);
GO

-- Creating table 'UploadedFiles'
CREATE TABLE [dbo].[UploadedFiles] (
    [IDUploadedFile] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContentType] nvarchar(50)  NOT NULL,
    [Content] varbinary(max)  NOT NULL,
    [ApartmentIDApartment] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [IDUser] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Phone] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [IDCity] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [CountryIDCountry] int  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [IDCountry] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDApartment] in table 'Apartments'
ALTER TABLE [dbo].[Apartments]
ADD CONSTRAINT [PK_Apartments]
    PRIMARY KEY CLUSTERED ([IDApartment] ASC);
GO

-- Creating primary key on [IDUploadedFile] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [PK_UploadedFiles]
    PRIMARY KEY CLUSTERED ([IDUploadedFile] ASC);
GO

-- Creating primary key on [IDUser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([IDUser] ASC);
GO

-- Creating primary key on [IDCity] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([IDCity] ASC);
GO

-- Creating primary key on [IDCountry] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([IDCountry] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApartmentIDApartment] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [FK_ApartmentUploadedFile]
    FOREIGN KEY ([ApartmentIDApartment])
    REFERENCES [dbo].[Apartments]
        ([IDApartment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentUploadedFile'
CREATE INDEX [IX_FK_ApartmentUploadedFile]
ON [dbo].[UploadedFiles]
    ([ApartmentIDApartment]);
GO

-- Creating foreign key on [CountryIDCountry] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_CityCountry]
    FOREIGN KEY ([CountryIDCountry])
    REFERENCES [dbo].[Countries]
        ([IDCountry])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityCountry'
CREATE INDEX [IX_FK_CityCountry]
ON [dbo].[Cities]
    ([CountryIDCountry]);
GO

-- Creating foreign key on [UserIDUser] in table 'Apartments'
ALTER TABLE [dbo].[Apartments]
ADD CONSTRAINT [FK_ApartmentUser]
    FOREIGN KEY ([UserIDUser])
    REFERENCES [dbo].[Users]
        ([IDUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentUser'
CREATE INDEX [IX_FK_ApartmentUser]
ON [dbo].[Apartments]
    ([UserIDUser]);
GO

-- Creating foreign key on [CityIDCity] in table 'Apartments'
ALTER TABLE [dbo].[Apartments]
ADD CONSTRAINT [FK_ApartmentCity]
    FOREIGN KEY ([CityIDCity])
    REFERENCES [dbo].[Cities]
        ([IDCity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentCity'
CREATE INDEX [IX_FK_ApartmentCity]
ON [dbo].[Apartments]
    ([CityIDCity]);
GO

-- Creating foreign key on [CityIDCity] in table 'Apartments'
ALTER TABLE [dbo].[Apartments]
ADD CONSTRAINT [FK_ApartmentCity1]
    FOREIGN KEY ([CityIDCity])
    REFERENCES [dbo].[Cities]
        ([IDCity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentCity1'
CREATE INDEX [IX_FK_ApartmentCity1]
ON [dbo].[Apartments]
    ([CityIDCity]);
GO

-- Creating foreign key on [UserIDUser] in table 'Apartments'
ALTER TABLE [dbo].[Apartments]
ADD CONSTRAINT [FK_ApartmentUser1]
    FOREIGN KEY ([UserIDUser])
    REFERENCES [dbo].[Users]
        ([IDUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentUser1'
CREATE INDEX [IX_FK_ApartmentUser1]
ON [dbo].[Apartments]
    ([UserIDUser]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------