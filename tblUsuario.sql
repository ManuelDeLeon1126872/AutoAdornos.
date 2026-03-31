CREATE TABLE [dbo].[tblUsuario]
(
    [IdUsuario] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NombreUsuario] NVARCHAR(50) NOT NULL,
    [Clave] NVARCHAR(200) NOT NULL,
    [NombreCompleto] NVARCHAR(100) NOT NULL,
    [Estado] BIT NOT NULL DEFAULT 1,
    [FechaCreacion] DATETIME NOT NULL DEFAULT GETDATE()
);