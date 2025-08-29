using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUsuariosApp.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }       
        public string NumeroDocumento { get; set; }     
        public string TipoUsuario { get; set; }         
        public DateTime FechaAlta { get; set; }
    }
}
