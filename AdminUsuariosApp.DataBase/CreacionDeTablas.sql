-- CreateTables.sql
CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    FechaAlta DATETIME DEFAULT GETDATE()
);