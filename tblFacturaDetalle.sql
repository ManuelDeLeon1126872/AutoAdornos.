CREATE TABLE [dbo].[tblFacturaDetalle]
(
    [IdFacturaDetalle] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdFactura] INT NOT NULL,
    [IdProducto] INT NULL,
    [IdServicio] INT NULL,
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [Importe] DECIMAL(18,2) NOT NULL
);