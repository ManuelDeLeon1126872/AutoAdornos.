CREATE TABLE [dbo].[tblAuditoria]
(
    [IdAuditoria] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdUsuario] INT NOT NULL,
    [Modulo] NVARCHAR(50) NOT NULL,
    [Accion] NVARCHAR(50) NOT NULL,
    [Descripcion] NVARCHAR(250) NOT NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE()
);