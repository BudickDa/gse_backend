
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2016 12:13:39
-- Generated from EDMX file: D:\Repositories\backend\backend\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Backend];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FAQSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQSet];
GO
IF OBJECT_ID(N'[dbo].[ChecklistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChecklistSet];
GO
IF OBJECT_ID(N'[dbo].[ApplicationProcedureSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ApplicationProcedureSet];
GO
IF OBJECT_ID(N'[dbo].[UniversitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UniversitySet];
GO
IF OBJECT_ID(N'[dbo].[FirstStepsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FirstStepsSet];
GO
IF OBJECT_ID(N'[dbo].[ColorSchemaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColorSchemaSet];
GO
IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO
IF OBJECT_ID(N'[dbo].[HousingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HousingSet];
GO
IF OBJECT_ID(N'[dbo].[DepartmentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentsSet];
GO
IF OBJECT_ID(N'[dbo].[POISet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[POISet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FAQSet'
CREATE TABLE [dbo].[FAQSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [question] nvarchar(max)  NOT NULL,
    [answer] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChecklistSet'
CREATE TABLE [dbo].[ChecklistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [link] nvarchar(max)  NOT NULL,
    [information] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ApplicationProcedureSet'
CREATE TABLE [dbo].[ApplicationProcedureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [deathline] datetime  NOT NULL,
    [link] nvarchar(max)  NOT NULL,
    [information] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UniversitySet'
CREATE TABLE [dbo].[UniversitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [information] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FirstStepsSet'
CREATE TABLE [dbo].[FirstStepsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [information] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'ColorSchemaSet'
CREATE TABLE [dbo].[ColorSchemaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [colorOne] nvarchar(max)  NOT NULL,
    [colorTwo] nvarchar(max)  NOT NULL,
    [colorThree] nvarchar(max)  NOT NULL,
    [colorFive] nvarchar(max)  NOT NULL,
    [colorFour] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CalendarSet'
CREATE TABLE [dbo].[CalendarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [position] nvarchar(max)  NOT NULL,
    [datetime] datetime  NOT NULL,
    [price] smallint  NULL,
    [information] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HousingSet'
CREATE TABLE [dbo].[HousingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [position] nvarchar(max)  NOT NULL,
    [price] smallint  NOT NULL,
    [information] nvarchar(max)  NOT NULL,
    [moveIn] datetime  NOT NULL,
    [moveOut] datetime  NOT NULL,
    [link] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DepartmentsSet'
CREATE TABLE [dbo].[DepartmentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [position] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL,
    [information] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'POISet'
CREATE TABLE [dbo].[POISet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [position] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [information] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FAQSet'
ALTER TABLE [dbo].[FAQSet]
ADD CONSTRAINT [PK_FAQSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChecklistSet'
ALTER TABLE [dbo].[ChecklistSet]
ADD CONSTRAINT [PK_ChecklistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ApplicationProcedureSet'
ALTER TABLE [dbo].[ApplicationProcedureSet]
ADD CONSTRAINT [PK_ApplicationProcedureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UniversitySet'
ALTER TABLE [dbo].[UniversitySet]
ADD CONSTRAINT [PK_UniversitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FirstStepsSet'
ALTER TABLE [dbo].[FirstStepsSet]
ADD CONSTRAINT [PK_FirstStepsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ColorSchemaSet'
ALTER TABLE [dbo].[ColorSchemaSet]
ADD CONSTRAINT [PK_ColorSchemaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalendarSet'
ALTER TABLE [dbo].[CalendarSet]
ADD CONSTRAINT [PK_CalendarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HousingSet'
ALTER TABLE [dbo].[HousingSet]
ADD CONSTRAINT [PK_HousingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepartmentsSet'
ALTER TABLE [dbo].[DepartmentsSet]
ADD CONSTRAINT [PK_DepartmentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'POISet'
ALTER TABLE [dbo].[POISet]
ADD CONSTRAINT [PK_POISet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------