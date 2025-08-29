using AdminUsuarioApp.BLL.Dtos;
using AdminUsuarioApp.BLL.Interfaces;
using AdminUsuarioApp.BLL.Mapper;
using AdminUsuariosApp.DAL.Repositories;
using AdminUsuariosApp.Entities;
using System.Collections.Generic;

namespace AdminUsuarioApp.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _repo = new UsuarioRepository();

        public bool Agregar(UsuarioDTO usuario)
        {
            Usuario usuarioEntity = UsuarioMapper.ToEntity(usuario);

            return _repo.Agregar(usuarioEntity);

        }

        public bool Eliminar(int id)
        {
           return _repo.Eliminar(id);
        }

        public List<UsuarioDTO> ObtenerTodos()
        {
            var usuarios = _repo.ObtenerTodos();

            return UsuarioMapper.ToDtoList(usuarios);
        }
    }
}
