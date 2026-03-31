CREATE TABLE [dbo].[tblLogServicio]
(
    [IdLogServicio] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Servicio] NVARCHAR(100) NOT NULL,
    [Parametros] NVARCHAR(MAX) NULL,
    [Respuesta] NVARCHAR(MAX) NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE()
);