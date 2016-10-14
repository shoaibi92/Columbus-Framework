-- Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

-- Create_WorkerRole_Schema.sql
-- Drop the tables if they exist and create tables

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]') AND type in (N'U'))
  DROP TABLE [dbo].[UnitOfWorkInstance]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]') AND type in (N'U'))
  DROP TABLE [dbo].[WorkflowInstance]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowSchedule]') AND type in (N'U'))
  DROP TABLE [dbo].[WorkflowSchedule]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkStatus]') AND type in (N'U'))
  DROP TABLE [dbo].[WorkStatus]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkKind]') AND type in (N'U'))
  DROP TABLE [dbo].[UnitOfWorkKind]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowKind]') AND type in (N'U'))
  DROP TABLE [dbo].[WorkflowKind]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowKind]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[WorkflowKind](
    [WorkflowKindId] [int] NOT NULL,
    [UniqueName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaxRetries] [int] NOT NULL,
    CONSTRAINT [PK_dbo.WorkflowKind] PRIMARY KEY CLUSTERED ([WorkflowKindId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))
END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowSchedule]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[WorkflowSchedule](
    [WorkflowScheduleId] [int] IDENTITY(1,1) NOT NULL,
    [TenantId] [uniqueidentifier] NOT NULL,
    [InitiatorId] [uniqueidentifier] NOT NULL,
    [WorkflowKindId] [int] NOT NULL,
    [IsRunning] [bit] NOT NULL,
    [Interval] [bigint] NOT NULL,
    [StartTime] [datetime] NOT NULL,
    [NextRunTime] [datetime] NULL,
    [SeedEntity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [AggregateEntity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_dbo.WorkflowSchedule] PRIMARY KEY CLUSTERED ([WorkflowScheduleId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowSchedule]') AND name = N'IX_WorkflowKindId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkflowKindId] ON [dbo].[WorkflowSchedule]([WorkflowKindId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkStatus]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[WorkStatus](
    [WorkStatusId] [int] NOT NULL,
    [Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
CONSTRAINT [PK_dbo.WorkStatus] PRIMARY KEY CLUSTERED ([WorkStatusId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))
END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[WorkflowInstance](
    [WorkflowInstanceId] [int] IDENTITY(1,1) NOT NULL,
    [WorkflowKindId] [int] NOT NULL,
    [WorkStatusId] [int] NOT NULL,
    [TenantId] [uniqueidentifier] NOT NULL,
    [InitiatorId] [uniqueidentifier] NOT NULL,
    [RetryCount] [int] NOT NULL,
    [SeedEntity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateCreated] [datetime] NOT NULL,
    [DateStartExecution] [datetime] NULL,
    [DateCompleteExecution] [datetime] NULL,
    [WorkflowScheduleId] [int] NULL,
    [Error] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_dbo.WorkflowInstance] PRIMARY KEY CLUSTERED ([WorkflowInstanceId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]') AND name = N'IX_WorkflowKindId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkflowKindId] ON [dbo].[WorkflowInstance]([WorkflowKindId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]') AND name = N'IX_WorkflowScheduleId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkflowScheduleId] ON [dbo].[WorkflowInstance]([WorkflowScheduleId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]') AND name = N'IX_WorkStatusId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkStatusId] ON [dbo].[WorkflowInstance]([WorkStatusId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkKind]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[UnitOfWorkKind](
    [UnitOfWorkKindId] [int] IDENTITY(1,1) NOT NULL,
    [WorkflowKindId] [int] NOT NULL,
    [UniqueName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [AssemblyName] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [TypeName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ExecutionOrder] [int] NOT NULL,
    [IsAsynchronous] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.UnitOfWorkKind] PRIMARY KEY CLUSTERED ([UnitOfWorkKindId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkKind]') AND name = N'IX_WorkflowKindId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkflowKindId] ON [dbo].[UnitOfWorkKind]([WorkflowKindId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[UnitOfWorkInstance](
    [UnitOfWorkInstanceId] [int] IDENTITY(1,1) NOT NULL,
    [WorkflowInstanceId] [int] NOT NULL,
    [UnitOfWorkKindId] [int] NOT NULL,
    [WorkStatusId] [int] NOT NULL,
    [TenantId] [uniqueidentifier] NOT NULL,
    [RetryCount] [int] NOT NULL,
    [ErrorMessage] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [AggregateEntity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ResultEntity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [WorkerRoleAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [WorkerRolePort] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateCreated] [datetime] NOT NULL,
    [DateStartExecution] [datetime] NULL,
    [DateCompleteExecution] [datetime] NULL,
    CONSTRAINT [PK_dbo.UnitOfWorkInstance] PRIMARY KEY CLUSTERED ([UnitOfWorkInstanceId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]') AND name = N'IX_UnitOfWorkKindId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_UnitOfWorkKindId] ON [dbo].[UnitOfWorkInstance]([UnitOfWorkKindId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]') AND name = N'IX_WorkflowInstanceId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkflowInstanceId] ON [dbo].[UnitOfWorkInstance]([WorkflowInstanceId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]') AND name = N'IX_WorkStatusId')
BEGIN
  CREATE NONCLUSTERED INDEX [IX_WorkStatusId] ON [dbo].[UnitOfWorkInstance]([WorkStatusId] ASC) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowSchedule_dbo.WorkflowKind_WorkflowKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowSchedule]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowSchedule]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkflowSchedule_dbo.WorkflowKind_WorkflowKindId] FOREIGN KEY([WorkflowKindId]) REFERENCES [dbo].[WorkflowKind] ([WorkflowKindId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowSchedule_dbo.WorkflowKind_WorkflowKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowSchedule]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowSchedule] CHECK CONSTRAINT [FK_dbo.WorkflowSchedule_dbo.WorkflowKind_WorkflowKindId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowInstance_dbo.WorkflowKind_WorkflowKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowInstance]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkflowInstance_dbo.WorkflowKind_WorkflowKindId] FOREIGN KEY([WorkflowKindId]) REFERENCES [dbo].[WorkflowKind] ([WorkflowKindId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowInstance_dbo.WorkflowKind_WorkflowKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowInstance] CHECK CONSTRAINT [FK_dbo.WorkflowInstance_dbo.WorkflowKind_WorkflowKindId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowInstance_dbo.WorkflowSchedule_WorkflowScheduleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowInstance]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkflowInstance_dbo.WorkflowSchedule_WorkflowScheduleId] FOREIGN KEY([WorkflowScheduleId]) REFERENCES [dbo].[WorkflowSchedule] ([WorkflowScheduleId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowInstance_dbo.WorkflowSchedule_WorkflowScheduleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowInstance] CHECK CONSTRAINT [FK_dbo.WorkflowInstance_dbo.WorkflowSchedule_WorkflowScheduleId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowInstance_dbo.WorkStatus_WorkStatusId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowInstance]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkflowInstance_dbo.WorkStatus_WorkStatusId] FOREIGN KEY([WorkStatusId]) REFERENCES [dbo].[WorkStatus] ([WorkStatusId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.WorkflowInstance_dbo.WorkStatus_WorkStatusId]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkflowInstance]'))
BEGIN
  ALTER TABLE [dbo].[WorkflowInstance] CHECK CONSTRAINT [FK_dbo.WorkflowInstance_dbo.WorkStatus_WorkStatusId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkKind_dbo.WorkflowKind_WorkflowKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkKind]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkKind]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UnitOfWorkKind_dbo.WorkflowKind_WorkflowKindId] FOREIGN KEY([WorkflowKindId]) REFERENCES [dbo].[WorkflowKind] ([WorkflowKindId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkKind_dbo.WorkflowKind_WorkflowKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkKind]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkKind] CHECK CONSTRAINT [FK_dbo.UnitOfWorkKind_dbo.WorkflowKind_WorkflowKindId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkInstance_dbo.UnitOfWorkKind_UnitOfWorkKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkInstance]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UnitOfWorkInstance_dbo.UnitOfWorkKind_UnitOfWorkKindId] FOREIGN KEY([UnitOfWorkKindId]) REFERENCES [dbo].[UnitOfWorkKind] ([UnitOfWorkKindId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkInstance_dbo.UnitOfWorkKind_UnitOfWorkKindId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkInstance] CHECK CONSTRAINT [FK_dbo.UnitOfWorkInstance_dbo.UnitOfWorkKind_UnitOfWorkKindId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkInstance_dbo.WorkflowInstance_WorkflowInstanceId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkInstance]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UnitOfWorkInstance_dbo.WorkflowInstance_WorkflowInstanceId] FOREIGN KEY([WorkflowInstanceId]) REFERENCES [dbo].[WorkflowInstance] ([WorkflowInstanceId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkInstance_dbo.WorkflowInstance_WorkflowInstanceId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkInstance] CHECK CONSTRAINT [FK_dbo.UnitOfWorkInstance_dbo.WorkflowInstance_WorkflowInstanceId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkInstance_dbo.WorkStatus_WorkStatusId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkInstance]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UnitOfWorkInstance_dbo.WorkStatus_WorkStatusId] FOREIGN KEY([WorkStatusId]) REFERENCES [dbo].[WorkStatus] ([WorkStatusId])
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UnitOfWorkInstance_dbo.WorkStatus_WorkStatusId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UnitOfWorkInstance]'))
BEGIN
  ALTER TABLE [dbo].[UnitOfWorkInstance] CHECK CONSTRAINT [FK_dbo.UnitOfWorkInstance_dbo.WorkStatus_WorkStatusId]
END
GO