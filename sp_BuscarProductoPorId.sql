CREATE PROCEDURE [dbo].[sp_BuscarProductoPorId]
    @IdProducto INT
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
    WHERE IdProducto = @IdProducto;
END;
GO