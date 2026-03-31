CREATE PROCEDURE [dbo].[sp_InsertarCliente]
    @Nombre NVARCHAR(100),
    @CedulaRNC NVARCHAR(20) = NULL,
    @Telefono NVARCHAR(20) = NULL,
    @Direccion NVARCHAR(200) = NULL,
    @Email NVARCHAR(100) = NULL,
    @EsAnonimo BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblCliente
    (
        Nombre,
        CedulaRNC,
        Telefono,
        Direccion,
        Email,
        EsAnonimo,
        Estado,
        FechaCreacion
    )
    VALUES
    (
        @Nombre,
        @CedulaRNC,
        @Telefono,
        @Direccion,
        @Email,
        @EsAnonimo,
        1,
        GETDATE()
    );

    SELECT SCOPE_IDENTITY() AS IdCliente;
END;
GO