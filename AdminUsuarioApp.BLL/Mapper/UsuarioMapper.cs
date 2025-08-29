using AdminUsuarioApp.BLL.Dtos;
using AdminUsuariosApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AdminUsuarioApp.BLL.Mapper
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO ToDto(Usuario usuario)
        {
            if (usuario == null) return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                FechaNacimiento = usuario.FechaNacimiento,
                TipoDocumento = usuario.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento,
                TipoUsuario = usuario.TipoUsuario,
                FechaAlta = usuario.FechaAlta
            };
        }

        public static Usuario ToEntity(UsuarioDTO dto)
        {
            if (dto == null) return null;

            return new Usuario
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                FechaNacimiento = dto.FechaNacimiento,
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                TipoUsuario = dto.TipoUsuario,
                FechaAlta = dto.FechaAlta
            };
        }

        public static List<UsuarioDTO> ToDtoList(List<Usuario> usuarios)
        {
            if (usuarios == null) return new List<UsuarioDTO>();
            return usuarios.Select(ToDto).ToList();
        }

        public static List<Usuario> ToEntityList(List<UsuarioDTO> dtos)
        {
            if (dtos == null) return new List<Usuario>();
            return dtos.Select(ToEntity).ToList();
        }
    }
}
