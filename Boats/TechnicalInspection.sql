CREATE TABLE [dbo].[TechnicalInspection]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TechInspectId] INT NOT NULL, 
    [CorpusStatus] INT NULL, 
    [InspectionPeriod] INT NULL, 
    [LastDayOfInspection] DATE NULL
)
