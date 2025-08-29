-- StoredProcedures.sql

/* LISTADO DE USARIOS */
CREATE PROCEDURE sp_ObtenerUsuarios AS
BEGIN
SELECT * FROM Usuario;
END;

/* INSERCION DEL USUARIO
 Nombre: nombre del usuario
 Email: direccionn de correo
 */
CREATE PROCEDURE sp_InsertarUsuario
    @Nombre NVARCHAR(100),
    @Email NVARCHAR(100)
AS
BEGIN
    INSERT INTO Usuario (Nombre, Email)
    VALUES (@Nombre, @Email);
END;


/*ELIMINACION DEL USUARIO
   ID : IDENTIFICADOR DEL USUARIO A ELIMINAR*/
CREATE PROCEDURE sp_EliminarUsuario
    @Id INT
AS
BEGIN
    DELETE FROM Usuario WHERE Id = @Id;
END;