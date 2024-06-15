using gymsy;
using gymsy.App.Models;
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
    internal class ProcedimientoAlmacenado
    {
        private GymsyContext dbContext;

        public ProcedimientoAlmacenado()
        {
            this.dbContext = StacticGymsyContext.GymsyContextDB;
        }

        public void CrearInstructor(string apodo, string nombre, string apellido, string avatarUrl, string contrasena, string numeroTelefono, string sexo)
        {
            var command = this.dbContext.Database.GetDbConnection().CreateCommand();
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
            this.dbContext.Database.OpenConnection();
            try
            {
                // Ejecuta el procedimiento almacenado
                command.ExecuteNonQuery();
            }
            finally
            {
                // Cierra la conexión a la base de datos
                this.dbContext.Database.CloseConnection();
            }
        }
    }
}
