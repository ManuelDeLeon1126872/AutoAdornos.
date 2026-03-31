INSERT INTO dbo.tblPerfil (NombrePerfil, Descripcion, Estado)
VALUES 
('ADMIN', 'Administrador del sistema', 1),
('CAJERO', 'Usuario de caja', 1),
('WEB', 'Usuario de portal web', 1),
('INTEGRACION', 'Usuario de integracion', 1);

INSERT INTO dbo.tblUsuario (NombreUsuario, Clave, NombreCompleto, Estado)
VALUES
('admin', '1234', 'Administrador General', 1);

INSERT INTO dbo.tblUsuarioPerfil (IdUsuario, IdPerfil)
VALUES (1, 1);

INSERT INTO dbo.tblCliente (Nombre, CedulaRNC, Telefono, Direccion, Email, EsAnonimo, Estado)
VALUES
('CLIENTE ANONIMO', NULL, NULL, NULL, NULL, 1, 1),
('Juan Perez', '00112345678', '8095551234', 'Santo Domingo', 'juan@email.com', 0, 1);

INSERT INTO dbo.tblVehiculo (IdCliente, Marca, Modelo, Anio, Placa, Color, Estado)
VALUES
(2, 'Honda', 'Civic', 2018, 'A123456', 'Negro', 1);

INSERT INTO dbo.tblProducto (Codigo, Descripcion, Precio, Existencia, Estado)
VALUES
('P001', 'Radio Pioneer', 8500.00, 10, 1),
('P002', 'Aros de Magnesio', 18000.00, 5, 1),
('P003', 'Luces LED', 2500.00, 20, 1),
('P004', 'Alarma Viper', 7200.00, 8, 1);

INSERT INTO dbo.tblServicio (Descripcion, Precio, Estado)
VALUES
('Instalacion de Radio', 1500.00, 1),
('Tintado de Vidrios', 6000.00, 1),
('Instalacion de Alarma', 3500.00, 1),
('Balanceo', 1200.00, 1);

INSERT INTO dbo.tblSuplidor (Nombre, RNC, Telefono, Direccion, Email, Estado)
VALUES
('Suplidora Auto Parts SRL', '131000111', '8095557777', 'Santo Domingo', 'ventas@autoparts.com', 1),
('Importadora Car Audio', '131000222', '8095558888', 'Santiago', 'info@caraudio.com', 1);

INSERT INTO dbo.tblSucursal (Nombre, Direccion, Telefono, Estado)
VALUES
('Sucursal Principal', 'Av. John F. Kennedy', '8095550001', 1),
('Sucursal Santiago', 'Av. 27 de Febrero', '8095550002', 1);