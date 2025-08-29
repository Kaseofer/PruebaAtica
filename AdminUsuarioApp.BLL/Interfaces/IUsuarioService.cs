using AdminUsuarioApp.BLL.Dtos;
using System.Collections.Generic;

namespace AdminUsuarioApp.BLL.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> ObtenerTodos();
        bool Agregar(UsuarioDTO usuario);
        bool Eliminar(int id);
    }
}
