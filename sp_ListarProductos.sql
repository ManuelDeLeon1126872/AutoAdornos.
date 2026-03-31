CREATE PROCEDURE [dbo].[sp_ListarProductos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdProducto,
        Codigo,
        Descripcion,
        Precio,
        Existencia,
        Estado,
        FechaCreacion
    FROM dbo.tblProducto
    WHERE Estado = 1
    ORDER BY Descripcion;
END;
GO