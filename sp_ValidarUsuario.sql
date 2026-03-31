CREATE PROCEDURE [dbo].[sp_ValidarUsuario]
    @NombreUsuario NVARCHAR(50),
    @Clave NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        U.IdUsuario,
        U.NombreUsuario,
        U.NombreCompleto,
        P.IdPerfil,
        P.NombrePerfil
    FROM dbo.tblUsuario U
    INNER JOIN dbo.tblUsuarioPerfil UP ON U.IdUsuario = UP.IdUsuario
    INNER JOIN dbo.tblPerfil P ON UP.IdPerfil = P.IdPerfil
    WHERE U.NombreUsuario = @NombreUsuario
      AND U.Clave = @Clave
      AND U.Estado = 1
      AND P.Estado = 1;
END;
GO