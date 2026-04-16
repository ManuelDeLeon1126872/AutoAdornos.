CORE - Instrucciones de instalación

1. Restaurar paquetes NuGet.
2. Crear base DBAutoAdornosCore en (localdb)\MSSQLLocalDB.
3. Ejecutar scripts en este orden:
   - Tables
   - Scripts
   - Seed
   - Stored Procedures
4. Verificar connection strings en TestApp y Services.
5. Startup project: AutoAdornos.Core.Services
6. Ejecutar CoreService.asmx

Usuario de prueba:
admin / 1234

Métodos finales:
- ValidarUsuario
- ListarProductos
- ListarServicios
- ListarSucursales
- ListarClientes
- BuscarClientePorCedulaRNC
- ListarVehiculosPorCliente
- ObtenerVehiculoGenerico
- InsertarCliente
- InsertarVehiculo
- InsertarFactura
- InsertarFacturaDetalle
- RegistrarMovimientoInventario

Métodos de apoyo para pruebas:
- InsertarVehiculoPrueba
- InsertarFacturaPrueba
- InsertarFacturaDetalleProductoPrueba
- InsertarFacturaDetalleServicioPrueba

Logs:
- Archivo: Logs\CoreService.log
- BD: tblLogServicio
- BD: tblAuditoria

CAMBIOS RECIENTES / NOTAS PARA INTEGRACIÓN


1. LOGIN (IMPORTANTE)
- El método ValidarUsuario ahora devuelve:
  - IdUsuario
  - IdSucursal
  - IdPerfil
  - NombrePerfil
- Deben usar IdSucursal para operaciones de caja e inventario.

2. VEHÍCULO GENÉRICO
- Se implementó soporte para ventas sin vehículo.
- Existe un vehículo genérico en la BD:
  Marca: GENERICA
  Modelo: VENTA RAPIDA
- Método disponible:
  - ObtenerVehiculoGenerico

3. FACTURACIÓN (IMPORTANTE)
- Método final:
  InsertarFactura

- Regla:
  - Si no hay vehículo, enviar:
    idVehiculo = 0

- El CORE convierte:
  0 → NULL → usa vehículo genérico automáticamente

4. MÉTODOS DE PRUEBA
- Los métodos con sufijo "Prueba" son solo para testing manual en ASMX.
- NO deben ser usados por Integración.

5. LOGS
- Todas las operaciones importantes generan:
  - Log técnico (archivo)
  - Log funcional (tblLogServicio)
  - Auditoría (tblAuditoria)

6. ERRORES COMUNES
- Si InsertarFactura falla:
  - verificar IdCliente
  - verificar IdUsuario
  - verificar IdSucursal
- Si no hay vehículo:
  usar idVehiculo = 0

7. ORDEN DE USO RECOMENDADO
- ValidarUsuario
- ObtenerVehiculoGenerico (opcional)
- InsertarCliente (si no existe)
- InsertarVehiculo (si aplica)
- InsertarFactura
- InsertarFacturaDetalle
- RegistrarMovimientoInventario