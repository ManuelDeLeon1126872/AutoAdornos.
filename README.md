# 🌉 Capa de Integración - Sistema Auto Adornos
---
## 🛠️ Requisitos Previos

Para ejecutar este proyecto en un entorno local de desarrollo (`localhost`), asegúrate de tener:

1.  **Visual Studio 2022** (con la carga de trabajo de desarrollo web y ASP.NET).
2.  **SQL Server LocalDB** (incluido con Visual Studio).
3.  **Entity Framework** (instalado vía NuGet en el proyecto de Datos).
4.  El proyecto **CORE (Rol 1)** configurado y listo para ejecutarse.

---

## 🚀 Guía de Instalación y Ejecución (Para Rol 3 y Rol 4)

Para que puedan consumir este servicio, deben seguir estos pasos **en orden estricto**:

### Paso 1: Configurar la Base de Datos de Integración
1. Abrir el *Explorador de objetos de SQL Server* en Visual Studio.
2. Conectarse a `(localdb)\MSSQLLocalDB`.
3. Crear una nueva base de datos llamada `DB_Integracion`.
4. Abrir una "Nueva consulta" y ejecutar el archivo `Script_Integracion.sql` para crear las tablas de Cache, Logs y Cola.

### Paso 2: Encender el Ecosistema
1. **Levantar el CORE:** Abre la solución del CORE en Visual Studio y presiona `F5` (Iniciar). Déjalo corriendo en segundo plano.
2. **Levantar la Integración:** Abre esta solución (`SistemaAutoAdornos.sln`), asegúrate de que `Integracion.API` sea el proyecto de inicio y presiona `F5`.

### Paso 3: Conectar los Clientes
**⚠️ REGLA DE ARQUITECTURA:** La Web y la Caja no deben conectarse al CORE de forma directa. 

1. En tu proyecto (Web o Caja), haz clic derecho en *Referencias* -> *Agregar Referencia de Servicio* (Add Connected Service).
2. Pega la URL que se generó en el Paso 2 al correr la Integración (ej. `http://localhost:XXXX/IntegracionService.asmx`).
3. Asigna un nombre al espacio de nombres (ej. `IntegracionAPI`) y haz clic en Aceptar.

---

## 📡 Contrato del API (Métodos Disponibles)

Los canales de venta tienen a su disposición los siguientes métodos:

### `ListarProductos()`
Devuelve el catálogo de productos disponibles. Si el CORE está inaccesible, devuelve los datos desde el Cache Local.
* **Retorna:** `List<Cache_tblProducto>`

### `RegistrarVenta(...)`
Procesa una factura y sus detalles. 
* **Parámetros requeridos:**
    * `idCliente` (int): ID del cliente.
    * `idVehiculo` (int): ID del vehículo (0 si no aplica).
    * `idUsuario` (int): ID del cajero o usuario activo.
    * `idSucursal` (int): ID de la sucursal donde se hace la venta.
    * `canalVenta` (string): "WEB" o "CAJA".
    * `total` (decimal): Monto total final pagado por el cliente (el ITBIS se calcula internamente).
    * `detalles` (List<ItemVenta>): Arreglo de productos/servicios comprados.
* **Retorna:** `string` (Mensaje de confirmación o aviso de guardado offline).

---
*Desarrollado para el proyecto final de Sistema Auto Adornos.*