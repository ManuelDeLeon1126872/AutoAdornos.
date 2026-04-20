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

===========================================
FACTURAS OFFLINE (COLA)
===========================================

Se implementó soporte para recepción de facturas generadas en modo offline por el módulo de Integración.

OBJETIVO
Permitir que Integración envíe facturas pendientes (en cola) cuando se restablezca la conexión con el CORE.

MÉTODO DISPONIBLE
- RecibirFacturaOffline

PARÁMETROS
- idLocal (string)
  Identificador local de la factura en el sistema de Integración (cola offline)

- cliente (string)
  Nombre o referencia del cliente

- total (decimal)
  Monto total de la factura

- canal (string)
  Canal de origen de la venta
  Valores válidos:
    - WEB
    - CAJA

COMPORTAMIENTO
- El CORE almacena la información recibida en una tabla independiente:
  - tblFacturaOfflineRecibida

- No se mezcla con la facturación principal del sistema.
- Se guarda como registro de respaldo para trazabilidad.

RESPUESTA DEL MÉTODO
- true  → la factura fue recibida correctamente y puede eliminarse de la cola en Integración
- false → ocurrió un error y NO debe eliminarse de la cola

REGLAS IMPORTANTES
- El campo "canal" solo acepta:
  - WEB
  - CAJA
- Cualquier otro valor devolverá false

TABLA UTILIZADA
- tblFacturaOfflineRecibida

Campos:
- IdFacturaOfflineRecibida (PK)
- IdLocal
- Cliente
- Total
- Canal
- FechaRecepcion
- Estado

LOGS
- Se registran eventos en:
  - Logs\CoreService.log
  - tblLogServicio

USO RECOMENDADO (INTEGRACIÓN)
1. Intentar enviar factura offline
2. Si el CORE devuelve true:
   → eliminar de la cola
3. Si devuelve false:
   → mantener en cola y reintentar

NOTA
Este método es independiente del flujo normal de facturación (InsertarFactura).
Se utiliza exclusivamente para sincronización offline.