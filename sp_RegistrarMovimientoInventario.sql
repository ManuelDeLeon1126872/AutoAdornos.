CREATE PROCEDURE [dbo].[sp_RegistrarMovimientoInventario]
    @IdProducto INT,
    @IdSucursal INT,
    @TipoMovimiento NVARCHAR(20),
    @Cantidad INT,
    @Observacion NVARCHAR(200) = NULL,
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Cantidad <= 0
    BEGIN
        RAISERROR('La cantidad debe ser mayor que cero.', 16, 1);
        RETURN;
    END;

    IF @TipoMovimiento NOT IN ('ENTRADA', 'SALIDA', 'AJUSTE')
    BEGIN
        RAISERROR('TipoMovimiento no válido.', 16, 1);
        RETURN;
    END;

    IF @TipoMovimiento = 'SALIDA'
    BEGIN
        IF EXISTS
        (
            SELECT 1
            FROM dbo.tblProducto
            WHERE IdProducto = @IdProducto
              AND Existencia < @Cantidad
        )
        BEGIN
            RAISERROR('No hay existencia suficiente para realizar la salida.', 16, 1);
            RETURN;
        END
    END;

    INSERT INTO dbo.tblMovimientoInventario
    (
        IdProducto,
        IdSucursal,
        TipoMovimiento,
        Cantidad,
        Fecha,
        Observacion,
        IdUsuario
    )
    VALUES
    (
        @IdProducto,
        @IdSucursal,
        @TipoMovimiento,
        @Cantidad,
        GETDATE(),
        @Observacion,
        @IdUsuario
    );

    IF @TipoMovimiento = 'ENTRADA'
    BEGIN
        UPDATE dbo.tblProducto
        SET Existencia = Existencia + @Cantidad
        WHERE IdProducto = @IdProducto;
    END
    ELSE IF @TipoMovimiento = 'SALIDA'
    BEGIN
        UPDATE dbo.tblProducto
        SET Existencia = Existencia - @Cantidad
        WHERE IdProducto = @IdProducto;
    END
    ELSE IF @TipoMovimiento = 'AJUSTE'
    BEGIN
        UPDATE dbo.tblProducto
        SET Existencia = @Cantidad
        WHERE IdProducto = @IdProducto;
    END;
END;
GO