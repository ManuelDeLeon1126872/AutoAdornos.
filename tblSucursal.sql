CREATE TABLE [dbo].[tblSucursal]
(
    [IdSucursal] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Direccion] NVARCHAR(200) NULL,
    [Telefono] NVARCHAR(20) NULL,
    [Estado] BIT NOT NULL DEFAULT 1,
    [FechaCreacion] DATETIME NOT NULL DEFAULT GETDATE()
);