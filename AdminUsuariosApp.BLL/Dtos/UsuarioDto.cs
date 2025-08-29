using System;

namespace AdminUsuarioApp.BLL.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string TipoUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
