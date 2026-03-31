CREATE PROCEDURE [dbo].[sp_InsertarFacturaDetalle]
    @IdFactura INT,
    @IdProducto INT = NULL,
    @IdServicio INT = NULL,
    @Cantidad INT,
    @Precio DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Importe DECIMAL(18,2);
    SET @Importe = @Cantidad * @Precio;

    INSERT INTO dbo.tblFacturaDetalle
    (
        IdFactura,
        IdProducto,
        IdServicio,
        Cantidad,
        Precio,
        Importe
    )
    VALUES
    (
        @IdFactura,
        @IdProducto,
        @IdServicio,
        @Cantidad,
        @Precio,
        @Importe
    );
END;
GO