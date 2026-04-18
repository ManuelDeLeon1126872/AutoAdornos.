AutoAdornos.Web.UI - Canal Web de Ventas

Qué incluye:
- Login consumiendo ValidarUsuario() de Integración.
- Catálogo consumiendo ListarProductos().
- Carrito de compra por sesión.
- Checkout que envía la venta a RegistrarVenta(..., canalVenta = "WEB").
- Diseño visual usando el logo TurboPOS suministrado.

Tecnología:
- ASP.NET MVC 5
- .NET Framework 4.7.2
- Consumo SOAP ASMX vía BasicHttpBinding

Pasos para usarlo:
1. Abrir la solución principal en Visual Studio 2022.
2. Agregar el proyecto AutoAdornos.Web.UI a la solución, o abrir el .csproj directamente.
3. Restaurar paquetes NuGet.
4. Cambiar en Web.config la clave IntegracionServiceUrl por la URL real de IntegracionService.asmx.
5. Revisar los IDs por defecto del usuario, sucursal, cliente y vehículo en Web.config.
6. Establecer AutoAdornos.Web.UI como proyecto de inicio y ejecutar.

Notas prácticas:
- El servicio ValidarUsuario del proyecto actual devuelve bool, no devuelve IdUsuario ni IdSucursal. Por eso la web usa IDs configurables por appSettings hasta que el CORE devuelva esos valores realmente.
- La web no se conecta al CORE ni a la base de datos directamente. Solo habla con Integración.
- El checkout está preparado para productos. Si luego quieres incluir servicios, se agrega el soporte para IdServicio en el carrito y en la pantalla de catálogo.
