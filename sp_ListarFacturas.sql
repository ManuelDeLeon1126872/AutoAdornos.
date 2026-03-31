CREATE PROCEDURE [dbo].[sp_ListarFacturas]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        F.IdFactura,
        F.Fecha,
        C.Nombre AS Cliente,
        F.CanalVenta,
        F.Total,
        F.Estado
    FROM dbo.tblFactura F
    INNER JOIN dbo.tblCliente C ON F.IdCliente = C.IdCliente
    ORDER BY F.IdFactura DESC;
END;
GO