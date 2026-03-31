CREATE PROCEDURE [dbo].[sp_BuscarClientePorCedulaRNC]
    @CedulaRNC NVARCHAR(20)
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
    WHERE CedulaRNC = @CedulaRNC
      AND Estado = 1;
END;
GO