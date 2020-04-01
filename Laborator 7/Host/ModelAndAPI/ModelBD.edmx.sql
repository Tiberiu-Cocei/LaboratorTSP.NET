
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2020 18:19:02
-- Generated from EDMX file: D:\Informatica\Anul 3 Semestrul 2\TSP.NET\Proiect\ProiectTSPNET\ModelAndAPI\ModelBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProiectDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(40)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [Path] nvarchar(200)  NOT NULL,
    [Size] float  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ToDelete] bit  NOT NULL
);
GO

-- Creating table 'PropertyLists'
CREATE TABLE [dbo].[PropertyLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileId] int  NOT NULL,
    [PropertyId] int  NOT NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropertyLists'
ALTER TABLE [dbo].[PropertyLists]
ADD CONSTRAINT [PK_PropertyLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FileId] in table 'PropertyLists'
ALTER TABLE [dbo].[PropertyLists]
ADD CONSTRAINT [FK_FilePropertyList]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilePropertyList'
CREATE INDEX [IX_FK_FilePropertyList]
ON [dbo].[PropertyLists]
    ([FileId]);
GO

-- Creating foreign key on [PropertyId] in table 'PropertyLists'
ALTER TABLE [dbo].[PropertyLists]
ADD CONSTRAINT [FK_PropertyListProperty]
    FOREIGN KEY ([PropertyId])
    REFERENCES [dbo].[Properties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyListProperty'
CREATE INDEX [IX_FK_PropertyListProperty]
ON [dbo].[PropertyLists]
    ([PropertyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------