CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NickName NVARCHAR(100) NOT NULL,
    TipoUsuario NVARCHAR(50) NOT NULL,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    TipoDocumento NVARCHAR(50) NOT NULL,
    NumeroDocumento NVARCHAR(50) NOT NULL,
    FechaAlta DATETIME NOT NULL
);
