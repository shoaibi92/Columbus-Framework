-- Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

-- Create_Tenant_Schema.sql
-- Drop the tables if they exist and create tables

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_UserTenant_User]') AND parent_object_id = OBJECT_ID(N'[UserTenant]'))
  ALTER TABLE [UserTenant] DROP CONSTRAINT [FK_UserTenant_User]
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_UserTenant_Tenant]') AND parent_object_id = OBJECT_ID(N'[UserTenant]'))
  ALTER TABLE [UserTenant] DROP CONSTRAINT [FK_UserTenant_Tenant]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Tenant]') AND type in (N'U'))
  DROP TABLE [Tenant]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[User]') AND type in (N'U'))
  DROP TABLE [User]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UserTenant]') AND type in (N'U'))
  DROP TABLE [UserTenant]
GO

BEGIN
  CREATE TABLE [Tenant](
    [ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
    [TenantId] [uniqueidentifier] UNIQUE NULL,
    [SiteId] [uniqueidentifier] UNIQUE NOT NULL,
    [InternalName] [nvarchar](36) UNIQUE NOT NULL,
    [Version] [nvarchar](50) NULL,
    [Status] INT NOT NULL,
    [UpdatedTimestamp] [rowversion] NOT NULL,
    [LastUpdated] [datetime] NOT NULL,
    [Company] [char](6) NOT NULL DEFAULT ('COMPNY'),
    [DatabaseLogin] [nvarchar](100) NULL,
    [DatabasePassword] [nvarchar](500) NULL,
    [DatabaseName] [nvarchar](100) NULL,
    [ServerName] [nvarchar](100) NOT NULL DEFAULT (''),)
END
GO

BEGIN
  CREATE TABLE [User](
    [ProductUserId] [uniqueidentifier] NOT NULL PRIMARY KEY CLUSTERED,
    [Name] [nvarchar](100) NOT NULL,
    [Email] [nvarchar](100) NULL,
    [Status] [nvarchar](20) NOT NULL,
    [FirstTimeUser] [bit] NOT NULL DEFAULT 0,
    [UpdatedTimestamp] [rowversion] NOT NULL,
    [LastUpdated] [datetime] NOT NULL)
END
GO

BEGIN
  CREATE TABLE [UserTenant](
    [ID] INT IDENTITY(1,1) NOT NULL  PRIMARY KEY CLUSTERED,
    [ProductUserId] [uniqueidentifier] NOT NULL,
    [Tenant_Id] [INT] NOT NULL,
    [ApplicationLoginId] [nvarchar](100) NOT NULL,
    [ApplicationPassword] [nvarchar](500) NOT NULL,
    CONSTRAINT [FK_UserTenant_User] FOREIGN KEY ([ProductUserId]) REFERENCES [User]([ProductUserId]),
    CONSTRAINT [FK_UserTenant_Tenant] FOREIGN KEY ([Tenant_Id]) REFERENCES [Tenant](ID),
    CONSTRAINT [UC_UserTenant_ProductUserId_TenantId] UNIQUE ([ProductUserId],[Tenant_Id]))
END
GO

CREATE NONCLUSTERED INDEX [IX_UserTenant_UserId] ON [UserTenant]([ProductUserId] ASC)
GO