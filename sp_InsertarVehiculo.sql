CREATE PROCEDURE [dbo].[sp_InsertarVehiculo]
    @IdCliente INT,
    @Marca NVARCHAR(50),
    @Modelo NVARCHAR(50),
    @Anio INT = NULL,
    @Placa NVARCHAR(20) = NULL,
    @Color NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblVehiculo
    (
        IdCliente,
        Marca,
        Modelo,
        Anio,
        Placa,
        Color,
        Estado
    )
    VALUES
    (
        @IdCliente,
        @Marca,
        @Modelo,
        @Anio,
        @Placa,
        @Color,
        1
    );

    SELECT SCOPE_IDENTITY() AS IdVehiculo;
END;
GO