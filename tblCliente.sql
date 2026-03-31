CREATE TABLE [dbo].[tblCliente]
(
    [IdCliente] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [CedulaRNC] NVARCHAR(20) NULL,
    [Telefono] NVARCHAR(20) NULL,
    [Direccion] NVARCHAR(200) NULL,
    [Email] NVARCHAR(100) NULL,
    [EsAnonimo] BIT NOT NULL DEFAULT 0,
    [Estado] BIT NOT NULL DEFAULT 1,
    [FechaCreacion] DATETIME NOT NULL DEFAULT GETDATE()
);