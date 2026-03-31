CREATE TABLE [dbo].[tblProducto]
(
    [IdProducto] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Codigo] NVARCHAR(20) NOT NULL,
    [Descripcion] NVARCHAR(100) NOT NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [Existencia] INT NOT NULL DEFAULT 0,
    [Estado] BIT NOT NULL DEFAULT 1,
    [FechaCreacion] DATETIME NOT NULL DEFAULT GETDATE()
);