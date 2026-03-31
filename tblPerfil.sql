CREATE TABLE [dbo].[tblPerfil]
(
    [IdPerfil] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NombrePerfil] NVARCHAR(50) NOT NULL,
    [Descripcion] NVARCHAR(150) NULL,
    [Estado] BIT NOT NULL DEFAULT 1
);