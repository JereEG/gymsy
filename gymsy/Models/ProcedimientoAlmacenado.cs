using gymsy;
using gymsy.Modelos;
using gymsy.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.Models
{
    internal static class ProcedimientoAlmacenado
    {
        private static NuevoGymsyContext dbContext = StacticGymsyContext.GymsyContextDB;


        public static void crearInstructor(string apodo, string nombre, string apellido, string avatarUrl, string contrasena, string numeroTelefono, string sexo,DateTime fechaNacimiento)
        {
            using (var dbContext = new NuevoGymsyContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "CrearInstructor";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@apodo", apodo));
                command.Parameters.Add(new SqlParameter("@nombre", nombre));
                command.Parameters.Add(new SqlParameter("@apellido", apellido));
                command.Parameters.Add(new SqlParameter("@avatar_url", avatarUrl));
                command.Parameters.Add(new SqlParameter("@fecha_nacimiento", fechaNacimiento));
                command.Parameters.Add(new SqlParameter("@contrasena", contrasena));
                command.Parameters.Add(new SqlParameter("@numero_telefono", numeroTelefono));
                command.Parameters.Add(new SqlParameter("@sexo", sexo));

                // Abre la conexión a la base de datos
                dbContext.Database.OpenConnection();
                try
                {
                    // Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
                finally
                {
                    // Cierra la conexión a la base de datos
                    dbContext.Database.CloseConnection();
                }
            }
        }
        public static List<Usuario> ObtenerAlumnosActivosPorEntrenador(int idEntrenador)
        {
            using (var dbContext = new NuevoGymsyContext())
            {

                var alumnos = new List<Usuario>();
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "ObtenerAlumnosActivosPorEntrenador";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id_entrenador", idEntrenador));

                dbContext.Database.OpenConnection();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var alumno = new Usuario
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("id_alumno")),
                                Apodo = reader.GetString(reader.GetOrdinal("apodo")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                AvatarUrl = reader.GetString(reader.GetOrdinal("avatar_url")),
                                FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento")),
                                NumeroTelefono = reader.GetString(reader.GetOrdinal("numero_telefono")),
                                Sexo = reader.GetString(reader.GetOrdinal("sexo")),
                                UsuarioInactivo = reader.GetBoolean(reader.GetOrdinal("usuario_inactivo"))
                            };
                            alumnos.Add(alumno);
                        }
                    }
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }

                return alumnos;
            }
        }
        public static void CrearPlanEntrenamiento(int idUsuarioInstructor, decimal precio, string descripcion)
        {
            using (var dbContext = new NuevoGymsyContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "CrearPlanEntrenamiento";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id_usuario_instructor", idUsuarioInstructor));
                command.Parameters.Add(new SqlParameter("@precio", precio));
                command.Parameters.Add(new SqlParameter("@descripcion", descripcion));

                dbContext.Database.OpenConnection();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }
        public static void CrearEstadoFisico(string titulo, decimal peso, decimal altura, string notas, int idAlumnoSuscripcion, string imagenUrl)
        {
            using (var dbContext = new NuevoGymsyContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "CrearEstadoFisico";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@titulo", titulo));
                command.Parameters.Add(new SqlParameter("@peso", peso));
                command.Parameters.Add(new SqlParameter("@altura", altura));
                command.Parameters.Add(new SqlParameter("@notas", notas));
                command.Parameters.Add(new SqlParameter("@id_alumno_suscripcion", idAlumnoSuscripcion));
                command.Parameters.Add(new SqlParameter("@imagen_url", imagenUrl));

                dbContext.Database.OpenConnection();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        public static void CrearCliente(string apodo, string nombre, string apellido, string avatarUrl, string contrasena, string numeroTelefono, string sexo)
        {
            using (var dbContext = new NuevoGymsyContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "CrearCliente";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@apodo", apodo));
                command.Parameters.Add(new SqlParameter("@nombre", nombre));
                command.Parameters.Add(new SqlParameter("@apellido", apellido));
                command.Parameters.Add(new SqlParameter("@avatar_url", avatarUrl));
                command.Parameters.Add(new SqlParameter("@contrasena", contrasena));
                command.Parameters.Add(new SqlParameter("@numero_telefono", numeroTelefono));
                command.Parameters.Add(new SqlParameter("@sexo", sexo));

                dbContext.Database.OpenConnection();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        public static void CambiarEstadoUsuario(int idUsuario)
        {
            using (var dbContext = new NuevoGymsyContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "CambiarEstadoUsuario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id_usuario", idUsuario));

                dbContext.Database.OpenConnection();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }
    

    }
}
