CREATE TABLE [dbo].[Boats]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [BoatsId] INT NOT NULL, 
    [TechInspectId] INT NOT NULL, 
    [CurrentParamsId] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Displacement] INT NULL, 
    [Speed] INT NULL, 
    [NumberOfSeats] INT NULL, 
    [Manufacturer] NVARCHAR(MAX) NULL, 
    FOREIGN KEY (TechInspectId) REFERENCES TechnicalInspection(TechInspectId),
    FOREIGN KEY (CurrentParamsId) REFERENCES CurrentParameters(CurrentParamsId)
)
