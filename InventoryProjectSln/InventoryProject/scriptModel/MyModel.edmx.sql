
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/31/2018 03:55:43
-- Generated from EDMX file: D:\1Obaedullah_software\C# Work\New_InventoryProject\InventoryProjectSln\InventoryProject\Models\MyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tr_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BOOK_INFO_MAIN_BOOK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BOOK_INFO_MAIN_BOOK];
GO
IF OBJECT_ID(N'[dbo].[FK_DISTRICT_DIVSSION]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Districts] DROP CONSTRAINT [FK_DISTRICT_DIVSSION];
GO
IF OBJECT_ID(N'[dbo].[FK_PARTY_DISTRICT]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_PARTY_DISTRICT];
GO
IF OBJECT_ID(N'[dbo].[FK_Tr_Detail_Tr_Master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tr_Details] DROP CONSTRAINT [FK_Tr_Detail_Tr_Master];
GO
IF OBJECT_ID(N'[dbo].[FK_TRAN_DTL_BOOK_INFO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tr_Details] DROP CONSTRAINT [FK_TRAN_DTL_BOOK_INFO];
GO
IF OBJECT_ID(N'[dbo].[FK_TRAN_DTL_MAIN_BOOK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tr_Details] DROP CONSTRAINT [FK_TRAN_DTL_MAIN_BOOK];
GO
IF OBJECT_ID(N'[dbo].[FK_TRAN_MST_DISTRICT]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tr_Masters] DROP CONSTRAINT [FK_TRAN_MST_DISTRICT];
GO
IF OBJECT_ID(N'[dbo].[FK_TRAN_MST_PARTY]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tr_Masters] DROP CONSTRAINT [FK_TRAN_MST_PARTY];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BookGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookGroups];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Districts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Districts];
GO
IF OBJECT_ID(N'[dbo].[Divisions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisions];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tr_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tr_Details];
GO
IF OBJECT_ID(N'[dbo].[Tr_Masters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tr_Masters];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookGroups'
CREATE TABLE [dbo].[BookGroups] (
    [BookGroupID] int IDENTITY(1,1) NOT NULL,
    [MainBookName] varchar(50)  NULL,
    [Class] varchar(30)  NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookID] int IDENTITY(1,1) NOT NULL,
    [BookGroupID] int  NULL,
    [BookName] varchar(1)  NULL,
    [Price] int  NULL,
    [Commission] int  NULL,
    [BookOpnBalance] int  NULL,
    [AuthorName] varchar(1)  NULL,
    [Status] bit  NULL,
    [ReturnRate] int  NULL,
    [BookForma] int  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [ClientName] varchar(200)  NULL,
    [Address] varchar(500)  NULL,
    [DistrictID] int  NULL,
    [ContactNo] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [ClientOpnBalance] int  NULL,
    [ClientType] varchar(20)  NULL,
    [TrDate] datetime  NULL
);
GO

-- Creating table 'Districts'
CREATE TABLE [dbo].[Districts] (
    [DistrictID] int IDENTITY(1,1) NOT NULL,
    [DistrictName] varchar(50)  NULL,
    [DivisionID] int  NULL
);
GO

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [DivisionID] int IDENTITY(1,1) NOT NULL,
    [DivisionName] varchar(200)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tr_Details'
CREATE TABLE [dbo].[Tr_Details] (
    [Tr_DetailID] int IDENTITY(1,1) NOT NULL,
    [Tr_MasterID] int  NULL,
    [BookGroupID] int  NULL,
    [BookID] int  NULL,
    [Qty] int  NULL,
    [Rate] int  NULL,
    [Commission] int  NULL
);
GO

-- Creating table 'Tr_Masters'
CREATE TABLE [dbo].[Tr_Masters] (
    [Tr_MasterID] int IDENTITY(1,1) NOT NULL,
    [Tr_Date] datetime  NOT NULL,
    [MemoNo] varchar(10)  NULL,
    [DistrictID] int  NULL,
    [ClientID] int  NULL,
    [PackDebit] int  NULL,
    [Less] int  NULL,
    [Type] varchar(10)  NOT NULL,
    [ReturnLessMemoNo] varchar(20)  NULL,
    [InvoiceNo] varchar(10)  NULL,
    [BindID] int  NULL,
    [OrderID] varchar(10)  NULL,
    [Commission] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BookGroupID] in table 'BookGroups'
ALTER TABLE [dbo].[BookGroups]
ADD CONSTRAINT [PK_BookGroups]
    PRIMARY KEY CLUSTERED ([BookGroupID] ASC);
GO

-- Creating primary key on [BookID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookID] ASC);
GO

-- Creating primary key on [ClientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [DistrictID] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [PK_Districts]
    PRIMARY KEY CLUSTERED ([DistrictID] ASC);
GO

-- Creating primary key on [DivisionID] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([DivisionID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Tr_DetailID] in table 'Tr_Details'
ALTER TABLE [dbo].[Tr_Details]
ADD CONSTRAINT [PK_Tr_Details]
    PRIMARY KEY CLUSTERED ([Tr_DetailID] ASC);
GO

-- Creating primary key on [Tr_MasterID] in table 'Tr_Masters'
ALTER TABLE [dbo].[Tr_Masters]
ADD CONSTRAINT [PK_Tr_Masters]
    PRIMARY KEY CLUSTERED ([Tr_MasterID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BookGroupID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BOOK_INFO_MAIN_BOOK]
    FOREIGN KEY ([BookGroupID])
    REFERENCES [dbo].[BookGroups]
        ([BookGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BOOK_INFO_MAIN_BOOK'
CREATE INDEX [IX_FK_BOOK_INFO_MAIN_BOOK]
ON [dbo].[Books]
    ([BookGroupID]);
GO

-- Creating foreign key on [BookGroupID] in table 'Tr_Details'
ALTER TABLE [dbo].[Tr_Details]
ADD CONSTRAINT [FK_TRAN_DTL_MAIN_BOOK]
    FOREIGN KEY ([BookGroupID])
    REFERENCES [dbo].[BookGroups]
        ([BookGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TRAN_DTL_MAIN_BOOK'
CREATE INDEX [IX_FK_TRAN_DTL_MAIN_BOOK]
ON [dbo].[Tr_Details]
    ([BookGroupID]);
GO

-- Creating foreign key on [BookID] in table 'Tr_Details'
ALTER TABLE [dbo].[Tr_Details]
ADD CONSTRAINT [FK_TRAN_DTL_BOOK_INFO]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([BookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TRAN_DTL_BOOK_INFO'
CREATE INDEX [IX_FK_TRAN_DTL_BOOK_INFO]
ON [dbo].[Tr_Details]
    ([BookID]);
GO

-- Creating foreign key on [DistrictID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_PARTY_DISTRICT]
    FOREIGN KEY ([DistrictID])
    REFERENCES [dbo].[Districts]
        ([DistrictID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PARTY_DISTRICT'
CREATE INDEX [IX_FK_PARTY_DISTRICT]
ON [dbo].[Clients]
    ([DistrictID]);
GO

-- Creating foreign key on [ClientID] in table 'Tr_Masters'
ALTER TABLE [dbo].[Tr_Masters]
ADD CONSTRAINT [FK_TRAN_MST_PARTY]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TRAN_MST_PARTY'
CREATE INDEX [IX_FK_TRAN_MST_PARTY]
ON [dbo].[Tr_Masters]
    ([ClientID]);
GO

-- Creating foreign key on [DivisionID] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [FK_DISTRICT_DIVSSION]
    FOREIGN KEY ([DivisionID])
    REFERENCES [dbo].[Divisions]
        ([DivisionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DISTRICT_DIVSSION'
CREATE INDEX [IX_FK_DISTRICT_DIVSSION]
ON [dbo].[Districts]
    ([DivisionID]);
GO

-- Creating foreign key on [DistrictID] in table 'Tr_Masters'
ALTER TABLE [dbo].[Tr_Masters]
ADD CONSTRAINT [FK_TRAN_MST_DISTRICT]
    FOREIGN KEY ([DistrictID])
    REFERENCES [dbo].[Districts]
        ([DistrictID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TRAN_MST_DISTRICT'
CREATE INDEX [IX_FK_TRAN_MST_DISTRICT]
ON [dbo].[Tr_Masters]
    ([DistrictID]);
GO

-- Creating foreign key on [Tr_MasterID] in table 'Tr_Details'
ALTER TABLE [dbo].[Tr_Details]
ADD CONSTRAINT [FK_Tr_Detail_Tr_Master]
    FOREIGN KEY ([Tr_MasterID])
    REFERENCES [dbo].[Tr_Masters]
        ([Tr_MasterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tr_Detail_Tr_Master'
CREATE INDEX [IX_FK_Tr_Detail_Tr_Master]
ON [dbo].[Tr_Details]
    ([Tr_MasterID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------