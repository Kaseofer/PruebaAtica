using AdminUsuarioApp.BLL.Dtos;
using System.Collections.Generic;

namespace AdminUsuarioApp.BLL.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioDto> ObtenerTodos();
        bool Agregar(UsuarioDto usuario);
        bool Eliminar(int id);
    }
}
