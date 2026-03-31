CREATE PROCEDURE [dbo].[sp_ListarSucursales]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdSucursal,
        Nombre,
        Direccion,
        Telefono,
        Estado,
        FechaCreacion
    FROM dbo.tblSucursal
    WHERE Estado = 1
    ORDER BY Nombre;
END;
GO