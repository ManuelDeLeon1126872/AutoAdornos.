CREATE TABLE [dbo].[tblFactura]
(
    [IdFactura] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdCliente] INT NOT NULL,
    [IdVehiculo] INT NULL,
    [IdUsuario] INT NOT NULL,
    [IdSucursal] INT NOT NULL,
    [CanalVenta] NVARCHAR(20) NOT NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Impuesto] DECIMAL(18,2) NOT NULL DEFAULT 0,
    [Total] DECIMAL(18,2) NOT NULL,
    [Estado] NVARCHAR(20) NOT NULL DEFAULT 'ACTIVA'
);