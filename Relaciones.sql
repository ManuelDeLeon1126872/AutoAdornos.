ALTER TABLE [dbo].[tblUsuarioPerfil]
ADD CONSTRAINT [FK_tblUsuarioPerfil_tblUsuario]
FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario]([IdUsuario]);
GO

ALTER TABLE [dbo].[tblUsuarioPerfil]
ADD CONSTRAINT [FK_tblUsuarioPerfil_tblPerfil]
FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[tblPerfil]([IdPerfil]);
GO

ALTER TABLE [dbo].[tblVehiculo]
ADD CONSTRAINT [FK_tblVehiculo_tblCliente]
FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[tblCliente]([IdCliente]);
GO

ALTER TABLE [dbo].[tblFactura]
ADD CONSTRAINT [FK_tblFactura_tblCliente]
FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[tblCliente]([IdCliente]);
GO

ALTER TABLE [dbo].[tblFactura]
ADD CONSTRAINT [FK_tblFactura_tblVehiculo]
FOREIGN KEY ([IdVehiculo]) REFERENCES [dbo].[tblVehiculo]([IdVehiculo]);
GO

ALTER TABLE [dbo].[tblFactura]
ADD CONSTRAINT [FK_tblFactura_tblUsuario]
FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario]([IdUsuario]);
GO

ALTER TABLE [dbo].[tblFactura]
ADD CONSTRAINT [FK_tblFactura_tblSucursal]
FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[tblSucursal]([IdSucursal]);
GO

ALTER TABLE [dbo].[tblFacturaDetalle]
ADD CONSTRAINT [FK_tblFacturaDetalle_tblFactura]
FOREIGN KEY ([IdFactura]) REFERENCES [dbo].[tblFactura]([IdFactura]);
GO

ALTER TABLE [dbo].[tblFacturaDetalle]
ADD CONSTRAINT [FK_tblFacturaDetalle_tblProducto]
FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[tblProducto]([IdProducto]);
GO

ALTER TABLE [dbo].[tblFacturaDetalle]
ADD CONSTRAINT [FK_tblFacturaDetalle_tblServicio]
FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[tblServicio]([IdServicio]);
GO

ALTER TABLE [dbo].[tblMovimientoInventario]
ADD CONSTRAINT [FK_tblMovimientoInventario_tblProducto]
FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[tblProducto]([IdProducto]);
GO

ALTER TABLE [dbo].[tblMovimientoInventario]
ADD CONSTRAINT [FK_tblMovimientoInventario_tblSucursal]
FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[tblSucursal]([IdSucursal]);
GO

ALTER TABLE [dbo].[tblMovimientoInventario]
ADD CONSTRAINT [FK_tblMovimientoInventario_tblUsuario]
FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario]([IdUsuario]);
GO

ALTER TABLE [dbo].[tblAuditoria]
ADD CONSTRAINT [FK_tblAuditoria_tblUsuario]
FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario]([IdUsuario]);
GO