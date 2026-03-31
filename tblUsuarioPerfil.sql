CREATE TABLE [dbo].[tblUsuarioPerfil]
(
    [IdUsuarioPerfil] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdUsuario] INT NOT NULL,
    [IdPerfil] INT NOT NULL
);