CREATE TABLE [dbo].[tblServicio]
(
    [IdServicio] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descripcion] NVARCHAR(100) NOT NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [Estado] BIT NOT NULL DEFAULT 1
);