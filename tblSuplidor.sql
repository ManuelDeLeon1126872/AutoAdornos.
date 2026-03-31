CREATE TABLE [dbo].[tblSuplidor]
(
    [IdSuplidor] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [RNC] NVARCHAR(20) NULL,
    [Telefono] NVARCHAR(20) NULL,
    [Direccion] NVARCHAR(200) NULL,
    [Email] NVARCHAR(100) NULL,
    [Estado] BIT NOT NULL DEFAULT 1,
    [FechaCreacion] DATETIME NOT NULL DEFAULT GETDATE()
);