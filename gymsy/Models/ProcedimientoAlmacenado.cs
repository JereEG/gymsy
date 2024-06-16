﻿using gymsy;
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
        private static GymsyContext dbContext = StacticGymsyContext.GymsyContextDB;


        public static void CrearInstructor(string apodo, string nombre, string apellido, string avatarUrl, string contrasena, string numeroTelefono, string sexo)
        {
            var command = dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = "CrearInstructor";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@apodo", apodo));
            command.Parameters.Add(new SqlParameter("@nombre", nombre));
            command.Parameters.Add(new SqlParameter("@apellido", apellido));
            command.Parameters.Add(new SqlParameter("@avatar_url", avatarUrl));
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
        public static void CrearPlanEntrenamiento(int idUsuarioInstructor, decimal precio, string descripcion)
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
        public static void CrearEstadoFisico(string titulo, decimal peso, decimal altura, string notas, int idAlumnoSuscripcion, string imagenUrl)
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

        public static void CrearCliente(string apodo, string nombre, string apellido, string avatarUrl, string contrasena, string numeroTelefono, string sexo)
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

        public static void CambiarEstadoUsuario(int idUsuario)
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