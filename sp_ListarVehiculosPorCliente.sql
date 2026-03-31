CREATE PROCEDURE [dbo].[sp_ListarVehiculosPorCliente]
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdVehiculo,
        IdCliente,
        Marca,
        Modelo,
        Anio,
        Placa,
        Color,
        Estado
    FROM dbo.tblVehiculo
    WHERE IdCliente = @IdCliente
      AND Estado = 1;
END;
GO