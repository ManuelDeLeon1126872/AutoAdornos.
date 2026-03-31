CREATE PROCEDURE [dbo].[sp_ConsultarFacturaPorId]
    @IdFactura INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        F.IdFactura,
        F.Fecha,
        F.CanalVenta,
        F.Subtotal,
        F.Impuesto,
        F.Total,
        F.Estado,
        C.IdCliente,
        C.Nombre AS Cliente,
        V.IdVehiculo,
        V.Marca,
        V.Modelo,
        V.Placa,
        U.IdUsuario,
        U.NombreCompleto AS Usuario,
        S.IdSucursal,
        S.Nombre AS Sucursal
    FROM dbo.tblFactura F
    INNER JOIN dbo.tblCliente C ON F.IdCliente = C.IdCliente
    LEFT JOIN dbo.tblVehiculo V ON F.IdVehiculo = V.IdVehiculo
    INNER JOIN dbo.tblUsuario U ON F.IdUsuario = U.IdUsuario
    INNER JOIN dbo.tblSucursal S ON F.IdSucursal = S.IdSucursal
    WHERE F.IdFactura = @IdFactura;

    SELECT
        FD.IdFacturaDetalle,
        FD.IdFactura,
        FD.IdProducto,
        P.Descripcion AS Producto,
        FD.IdServicio,
        SV.Descripcion AS Servicio,
        FD.Cantidad,
        FD.Precio,
        FD.Importe
    FROM dbo.tblFacturaDetalle FD
    LEFT JOIN dbo.tblProducto P ON FD.IdProducto = P.IdProducto
    LEFT JOIN dbo.tblServicio SV ON FD.IdServicio = SV.IdServicio
    WHERE FD.IdFactura = @IdFactura;
END;
GO