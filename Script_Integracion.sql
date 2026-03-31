
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DB_Integracion')
BEGIN
    CREATE DATABASE DB_Integracion;
END
GO

USE DB_Integracion;
GO

DROP TABLE IF EXISTS [dbo].[Cola_tblFacturaDetalle];
DROP TABLE IF EXISTS [dbo].[Cola_tblFactura];
DROP TABLE IF EXISTS [dbo].[Cache_tblProducto];
DROP TABLE IF EXISTS [dbo].[tblLogServicio];
GO


CREATE TABLE [dbo].[Cache_tblProducto] (
    [IdProducto]  INT             NOT NULL,
    [Codigo]      VARCHAR (50)    NULL,
    [Descripcion] VARCHAR (100)   NULL,
    [Precio]      DECIMAL (18, 2) NULL,
    [Existencia]  INT             NULL,
    [Estado]      BIT             NULL,
    [UltimaActualizacion] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([IdProducto] ASC)
);
GO


CREATE TABLE [dbo].[tblLogServicio] (
    [IdLog]      INT            IDENTITY (1, 1) NOT NULL,
    [Servicio]   VARCHAR (100)  NULL,
    [Parametros] VARCHAR (MAX)  NULL,
    [Respuesta]  VARCHAR (MAX)  NULL,
    [Fecha]      DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([IdLog] ASC)
);
GO


CREATE TABLE [dbo].[Cola_tblFactura] (
    [IdFacturaLocal] INT             IDENTITY (1, 1) NOT NULL,
    [IdCliente]      INT             NULL,
    [IdVehiculo]     INT             NULL, 
    [IdUsuario]      INT             NULL, 
    [IdSucursal]     INT             NULL, 
    [CanalVenta]     VARCHAR(50)     NULL, 
    [Fecha]          DATETIME        DEFAULT (getdate()) NULL,
    [Subtotal]       DECIMAL (18, 2) NULL, 
    [Impuesto]       DECIMAL (18, 2) NULL, 
    [Total]          DECIMAL (18, 2) NULL,
    [Sincronizado]   BIT             DEFAULT ((0)) NULL, -- 0 = No enviado, 1 = Ya se envió al CORE
    PRIMARY KEY CLUSTERED ([IdFacturaLocal] ASC)
);
GO

CREATE TABLE [dbo].[Cola_tblFacturaDetalle] (
    [IdDetalleLocal] INT             IDENTITY (1, 1) NOT NULL,
    [IdFacturaLocal] INT             NULL,
    [IdProducto]     INT             NULL,
    [IdServicio]     INT             NULL,
    [Cantidad]       INT             NULL,
    [Precio]         DECIMAL (18, 2) NULL,
    [Importe]        DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([IdDetalleLocal] ASC),
    FOREIGN KEY ([IdFacturaLocal]) REFERENCES [dbo].[Cola_tblFactura] ([IdFacturaLocal])
);
GO

PRINT 'Base de datos DB_Integracion creada exitosamente.'
GO