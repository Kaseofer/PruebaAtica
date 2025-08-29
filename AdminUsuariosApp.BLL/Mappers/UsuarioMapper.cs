using AdminUsuarioApp.BLL.Dtos;
using AdminUsuariosApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AdminUsuarioApp.BLL.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDto ToDto(Usuario usuario)
        {
            if (usuario == null) return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                NickName = usuario.NickName,
                NombreCompleto = usuario.NombreCompleto,
                Email = usuario.Email,
                FechaNacimiento = usuario.FechaNacimiento,
                TipoDocumento = usuario.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento,
                TipoUsuario = usuario.TipoUsuario,
                FechaAlta = usuario.FechaAlta
            };
        }

        public static Usuario ToEntity(UsuarioDto dto)
        {
            if (dto == null) return null;

            return new Usuario
            {
                Id = dto.Id,
                NickName = dto.NickName,
                NombreCompleto = dto.NombreCompleto,
                Email = dto.Email,
                FechaNacimiento = dto.FechaNacimiento,
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                TipoUsuario = dto.TipoUsuario,
                FechaAlta = dto.FechaAlta
            };
        }

        public static List<UsuarioDto> ToDtoList(List<Usuario> usuarios)
        {
            if (usuarios == null) return new List<UsuarioDto>();
            return usuarios.Select(ToDto).ToList();
        }

        public static List<Usuario> ToEntityList(List<UsuarioDto> dtos)
        {
            if (dtos == null) return new List<Usuario>();
            return dtos.Select(ToEntity).ToList();
        }
    }
}
