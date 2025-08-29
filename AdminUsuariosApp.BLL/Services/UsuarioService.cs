using AdminUsuarioApp.BLL.Dtos;
using AdminUsuarioApp.BLL.Interfaces;
using AdminUsuarioApp.BLL.Mappers;
using AdminUsuariosApp.DAL.Repositories;
using AdminUsuariosApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AdminUsuarioApp.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _repo = new UsuarioRepository();

        public bool Agregar(UsuarioDto usuario)
        {
            Usuario usuarioEntity = UsuarioMapper.ToEntity(usuario);

            return _repo.Agregar(usuarioEntity);

        }

        public bool Eliminar(int id)
        {
           return _repo.Eliminar(id);
        }

        public bool ExisteNickName(string nick)
        {
            var usuarios = _repo.ObtenerTodos();

            var usuarioEncontrado = usuarios.Where(x => x.NickName.Equals(nick.Trim())).FirstOrDefault();
            if (usuarioEncontrado == null) return false;

            return true;
        }

        public List<UsuarioDto> ObtenerTodos()
        {
            var usuarios = _repo.ObtenerTodos();

            return UsuarioMapper.ToDtoList(usuarios);
        }

       
    }
}
