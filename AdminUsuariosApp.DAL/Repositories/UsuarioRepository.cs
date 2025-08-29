using AdminUsuariosApp.DAL.Interfaces;
using AdminUsuariosApp.Entities;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdminUsuariosApp.DAL.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // Agregar un nuevo usuario
        public bool Agregar(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 100) { Value = usuario.NickName });
                        cmd.Parameters.Add(new SqlParameter("@TipoUsuario", SqlDbType.NVarChar, 50) { Value = usuario.TipoUsuario });
                        cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.NVarChar, 150) { Value = usuario.NombreCompleto });
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 150) { Value = usuario.Email });
                        cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.Date) { Value = usuario.FechaNacimiento });
                        cmd.Parameters.Add(new SqlParameter("@TipoDocumento", SqlDbType.NVarChar, 50) { Value = usuario.TipoDocumento });
                        cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.NVarChar, 50) { Value = usuario.NumeroDocumento });
                        cmd.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime) { Value = usuario.FechaAlta });
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch {return false;}
        }


        // Eliminar un usuario por ID
        public bool Eliminar(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch { return false; }
        }


        // Obtener todos los usuarios
        public List<Usuario> ObtenerTodos()
        {
            var usuarios = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NickName = reader.GetString(reader.GetOrdinal("NickName")),
                                NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
                                TipoDocumento = reader.GetString(reader.GetOrdinal("TipoDocumento")),
                                NumeroDocumento = reader.GetString(reader.GetOrdinal("NumeroDocumento")),
                                TipoUsuario = reader.GetString(reader.GetOrdinal("TipoUsuario")),
                                FechaAlta = reader.GetDateTime(reader.GetOrdinal("FechaAlta"))

                            });
                        }
                    }
                }
            }

            return usuarios;
        }

    }
}
