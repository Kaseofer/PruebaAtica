using AdminUsuariosApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUsuariosApp.DAL.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ObtenerTodos();
        bool Agregar(Usuario usuario);
        bool Eliminar(int id);
    }
}
