USE [LeanMaint]
GO

INSERT INTO [Config].[ObjStatuses]
([ID_ObjStatus], [Name],[Description])
VALUES
(1, 'Active', 'Object is active and editable')
,(2, 'Disabled', 'Object is disabled so readonly')
,(3, 'Deleted', 'Object is deleted no more seen if not requested')
