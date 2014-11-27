
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2014 12:56:26
-- Generated from EDMX file: C:\Users\kalleguld\Documents\JohannesVidnerProject\Model\ModelClasses.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JohannesVidner];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PublicationEdition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EditionSet] DROP CONSTRAINT [FK_PublicationEdition];
GO
IF OBJECT_ID(N'[dbo].[FK_PublicationUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_PublicationUser];
GO
IF OBJECT_ID(N'[dbo].[FK_EditionPage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PageSet] DROP CONSTRAINT [FK_EditionPage];
GO
IF OBJECT_ID(N'[dbo].[FK_PublicationPublication]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PublicationSet] DROP CONSTRAINT [FK_PublicationPublication];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PublicationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublicationSet];
GO
IF OBJECT_ID(N'[dbo].[EditionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EditionSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PageSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PublicationSet'
CREATE TABLE [dbo].[PublicationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParentPublicationId] int  NULL,
    [ShortName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EditionSet'
CREATE TABLE [dbo].[EditionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RunningStarted] datetime  NOT NULL,
    [MaxMissingPages] int  NOT NULL,
    [Running] bit  NOT NULL,
    [LogText] nvarchar(max)  NOT NULL,
    [ErrorMessage] nvarchar(max)  NOT NULL,
    [PublicationId] int  NOT NULL,
    [NumberOfPages] int  NOT NULL,
    [LastLogCheck] datetime  NOT NULL,
    [ExpectedReleaseTime] datetime  NULL,
    [CurrentStatus] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [PasswordText] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [WriteAccess] bit  NOT NULL,
    [UserAdminAccess] bit  NOT NULL,
    [PublicationId] int  NOT NULL,
    [CultureName] varchar(16)  NULL
);
GO

-- Creating table 'PageSet'
CREATE TABLE [dbo].[PageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Section] int  NOT NULL,
    [PageNumber] int  NOT NULL,
    [EditionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PublicationSet'
ALTER TABLE [dbo].[PublicationSet]
ADD CONSTRAINT [PK_PublicationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EditionSet'
ALTER TABLE [dbo].[EditionSet]
ADD CONSTRAINT [PK_EditionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PageSet'
ALTER TABLE [dbo].[PageSet]
ADD CONSTRAINT [PK_PageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PublicationId] in table 'EditionSet'
ALTER TABLE [dbo].[EditionSet]
ADD CONSTRAINT [FK_PublicationEdition]
    FOREIGN KEY ([PublicationId])
    REFERENCES [dbo].[PublicationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicationEdition'
CREATE INDEX [IX_FK_PublicationEdition]
ON [dbo].[EditionSet]
    ([PublicationId]);
GO

-- Creating foreign key on [PublicationId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_PublicationUser]
    FOREIGN KEY ([PublicationId])
    REFERENCES [dbo].[PublicationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicationUser'
CREATE INDEX [IX_FK_PublicationUser]
ON [dbo].[UserSet]
    ([PublicationId]);
GO

-- Creating foreign key on [EditionId] in table 'PageSet'
ALTER TABLE [dbo].[PageSet]
ADD CONSTRAINT [FK_EditionPage]
    FOREIGN KEY ([EditionId])
    REFERENCES [dbo].[EditionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EditionPage'
CREATE INDEX [IX_FK_EditionPage]
ON [dbo].[PageSet]
    ([EditionId]);
GO

-- Creating foreign key on [ParentPublicationId] in table 'PublicationSet'
ALTER TABLE [dbo].[PublicationSet]
ADD CONSTRAINT [FK_PublicationPublication]
    FOREIGN KEY ([ParentPublicationId])
    REFERENCES [dbo].[PublicationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicationPublication'
CREATE INDEX [IX_FK_PublicationPublication]
ON [dbo].[PublicationSet]
    ([ParentPublicationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------