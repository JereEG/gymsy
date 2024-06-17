using gymsy.Context;
using gymsy.Modelos;
using gymsy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class ClientePresenter
    {
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;




        public static Usuario BuscarCliente( int pIdCliente)
        {
            return gymsydb.Usuarios
                                .Where(client => client.IdUsuario == pIdCliente && client.IdRol == 3)
                                .First();
        }
        public static void EliminarOActivarCliente(int pIdPersona, bool pDeleteOrAcitive)
        {

            var persona = gymsydb.Usuarios         
                .Where(p => p.IdUsuario == pIdPersona && p.IdRol == 3).FirstOrDefault();

            if (persona != null)
            {
                persona.UsuarioInactivo = pDeleteOrAcitive;
                gymsydb.SaveChanges();
            }

        }
        public static List<PlanEntrenamiento> BuscarPlanesInstructor(int pIdInstructor)
        {
            try
            {
                // Inicializa un nuevo contexto de base de datos
                using (var dbContext = new NuevoGymsyContext())
                {
                    // Obtener todos los planes de entrenamiento del instructor actual
                    var planes = dbContext.PlanEntrenamientos
                                          .Where(plan => plan.IdEntrenador == pIdInstructor)
                                          .ToList();

                    if (planes == null || planes.Count == 0)
                    {
                        Console.WriteLine("No se encontraron planes para el instructor con ID: " + pIdInstructor);
                    }
                    else
                    {
                        Console.WriteLine("Se encontraron " + planes.Count + " planes para el instructor con ID: " + pIdInstructor);
                    }

                    return planes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar planes de entrenamiento: " + ex.Message);

                // Registrar la excepción en el archivo de log
                LogException(ex, pIdInstructor);

                return new List<PlanEntrenamiento>();
            }
        }

        private static void LogException(Exception ex, int pIdInstructor)
        {
            // Define la ruta completa del archivo de log
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "error_log.txt");

            // Crea el directorio si no existe
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            // Escribe en el archivo de log
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("--------------------------------------------------");
                writer.WriteLine($"Fecha: {DateTime.Now}");
                writer.WriteLine($"Instructor ID: {pIdInstructor}");
                writer.WriteLine($"Mensaje de error: {ex.Message}");
                writer.WriteLine($"Detalles de la excepción: {ex.ToString()}");
            }
        }



    }
}
