CREATE PROCEDURE [dbo].[sp_InsertarAuditoria]
    @IdUsuario INT,
    @Modulo NVARCHAR(50),
    @Accion NVARCHAR(50),
    @Descripcion NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblAuditoria
    (
        IdUsuario,
        Modulo,
        Accion,
        Descripcion,
        Fecha
    )
    VALUES
    (
        @IdUsuario,
        @Modulo,
        @Accion,
        @Descripcion,
        GETDATE()
    );
END;
GO