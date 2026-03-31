CORE - Instrucciones de instalación y uso

1. Requisitos
- Visual Studio
- SQL Server LocalDB ((localdb)\MSSQLLocalDB)
- .NET Framework 4.7.2
- Restaurar paquetes NuGet

2. Base de datos
Crear la base de datos:
DBAutoAdornosCore

Ejecutar scripts en este orden:
1. Tables
2. Scripts
3. Seed
4. Stored Procedures

3. Connection string
Verificar que AutoAdornos.Core.Data, AutoAdornos.Core.TestApp y AutoAdornos.Core.Services apunten a:
Server: (localdb)\MSSQLLocalDB
Database: DBAutoAdornosCore

4. Proyecto de inicio
Para probar el servicio:
AutoAdornos.Core.Services

5. URL del servicio
http://localhost:PUERTO/CoreService.asmx

6. Métodos principales para Integración
- ValidarUsuario
- ListarProductos
- ListarServicios
- ListarSucursales
- ListarClientes
- BuscarClientePorCedulaRNC
- InsertarCliente
- InsertarVehiculo
- InsertarFactura
- InsertarFacturaDetalle
- RegistrarMovimientoInventario

7. Datos de prueba
Usuario:
admin / 1234

8. Logs
- Archivo: Logs\CoreService.log
- Base de datos:
  - tblLogServicio
  - tblAuditoria