-- LISTADO DE USUARIOS
CREATE PROCEDURE sp_ObtenerUsuarios
AS
BEGIN
    SELECT * FROM Usuario;
END;
GO
-- INSERCIÓN DE USUARIO COMPLETO
CREATE PROCEDURE sp_InsertarUsuario
    @NickName NVARCHAR(100),
    @TipoUsuario NVARCHAR(50),
    @NombreCompleto NVARCHAR(150),
    @Email NVARCHAR(150),
    @FechaNacimiento DATE,
    @TipoDocumento NVARCHAR(50),
    @NumeroDocumento NVARCHAR(50),
    @FechaAlta DATETIME
AS
BEGIN
    INSERT INTO Usuario (
        NickName, TipoUsuario, NombreCompleto, Email,
        FechaNacimiento, TipoDocumento, NumeroDocumento, FechaAlta
    )
    VALUES (
        @NickName, @TipoUsuario, @NombreCompleto, @Email,
        @FechaNacimiento, @TipoDocumento, @NumeroDocumento, @FechaAlta
    );
END;

GO
-- ELIMINACIÓN DE USUARIO POR ID
CREATE PROCEDURE sp_EliminarUsuario
    @Id INT
AS
BEGIN
    DELETE FROM Usuario WHERE Id = @Id;
END;