CREATE PROCEDURE [dbo].[sp_ListarServicios]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdServicio,
        Descripcion,
        Precio,
        Estado
    FROM dbo.tblServicio
    WHERE Estado = 1
    ORDER BY Descripcion;
END;
GO