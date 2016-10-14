-- Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

-- Update_WorkflowOnPremise_Data.sql
-- Update the WorkflowSchedule table for an on premise deployment

UPDATE [dbo].[WorkflowSchedule] SET IsRunning = 1 WHERE WorkflowKindId = 29 AND TenantId = '00000000-0000-0000-0000-000000000000'
UPDATE [dbo].[WorkflowSchedule] SET IsRunning = 1 WHERE WorkflowKindId = 65 AND TenantId = '00000000-0000-0000-0000-000000000000'
GO