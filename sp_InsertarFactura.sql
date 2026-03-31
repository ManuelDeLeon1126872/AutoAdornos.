CREATE PROCEDURE [dbo].[sp_InsertarFactura]
    @IdCliente INT,
    @IdVehiculo INT = NULL,
    @IdUsuario INT,
    @IdSucursal INT,
    @CanalVenta NVARCHAR(20),
    @Subtotal DECIMAL(18,2),
    @Impuesto DECIMAL(18,2),
    @Total DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblFactura
    (
        IdCliente,
        IdVehiculo,
        IdUsuario,
        IdSucursal,
        CanalVenta,
        Fecha,
        Subtotal,
        Impuesto,
        Total,
        Estado
    )
    VALUES
    (
        @IdCliente,
        @IdVehiculo,
        @IdUsuario,
        @IdSucursal,
        @CanalVenta,
        GETDATE(),
        @Subtotal,
        @Impuesto,
        @Total,
        'ACTIVA'
    );

    SELECT SCOPE_IDENTITY() AS IdFactura;
END;
GO