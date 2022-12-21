CREATE TABLE [dbo].[Dannie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [First_Name] NVARCHAR(50) NULL, 
    [Last_Name] NVARCHAR(50) NULL, 
    [Make] NVARCHAR(50) NULL, 
    [Model] NVARCHAR(50) NULL, 
    [Year] INT NULL, 
    [Works] NTEXT NULL, 
    [Summa] MONEY NULL
)
