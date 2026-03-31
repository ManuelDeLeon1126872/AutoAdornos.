CREATE TABLE [dbo].[tblMovimientoInventario]
(
    [IdMovimientoInventario] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdProducto] INT NOT NULL,
    [IdSucursal] INT NOT NULL,
    [TipoMovimiento] NVARCHAR(20) NOT NULL,
    [Cantidad] INT NOT NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Observacion] NVARCHAR(200) NULL,
    [IdUsuario] INT NOT NULL
);