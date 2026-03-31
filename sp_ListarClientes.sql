CREATE PROCEDURE [dbo].[sp_ListarClientes]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCliente,
        Nombre,
        CedulaRNC,
        Telefono,
        Direccion,
        Email,
        EsAnonimo,
        Estado,
        FechaCreacion
    FROM dbo.tblCliente
    WHERE Estado = 1
    ORDER BY Nombre;
END;
GO