CREATE PROCEDURE [dbo].[sp_InsertarLogServicio]
    @Servicio NVARCHAR(100),
    @Parametros NVARCHAR(MAX) = NULL,
    @Respuesta NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblLogServicio
    (
        Servicio,
        Parametros,
        Respuesta,
        Fecha
    )
    VALUES
    (
        @Servicio,
        @Parametros,
        @Respuesta,
        GETDATE()
    );
END;
GO