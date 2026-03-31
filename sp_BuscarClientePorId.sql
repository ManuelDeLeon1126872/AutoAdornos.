CREATE PROCEDURE [dbo].[sp_BuscarClientePorId]
    @IdCliente INT
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
    WHERE IdCliente = @IdCliente;
END;
GO