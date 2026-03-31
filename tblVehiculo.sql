CREATE TABLE [dbo].[tblVehiculo]
(
    [IdVehiculo] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdCliente] INT NOT NULL,
    [Marca] NVARCHAR(50) NOT NULL,
    [Modelo] NVARCHAR(50) NOT NULL,
    [Anio] INT NULL,
    [Placa] NVARCHAR(20) NULL,
    [Color] NVARCHAR(30) NULL,
    [Estado] BIT NOT NULL DEFAULT 1
);