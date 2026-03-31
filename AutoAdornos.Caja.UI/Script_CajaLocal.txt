CREATE TABLE tblProductoCache (
    IdProducto INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Precio DECIMAL(18,2),
    Stock INT
);

CREATE TABLE tblFacturaLocal (
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME,
    CedulaCliente NVARCHAR(20),
    Total DECIMAL(18,2),
    EnviadoAIntegracion BIT DEFAULT 0 
);

CREATE TABLE tblFacturaDetalleLocal (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdFactura INT FOREIGN KEY REFERENCES tblFacturaLocal(IdFactura),
    IdProducto INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(18,2)
);