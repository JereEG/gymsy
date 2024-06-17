using gymsy.Context;
using gymsy.Modelos;
using gymsy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace gymsy.App.Presenters
{
    internal static class ControlPagosAlumnoPresenter
    {
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;
        //Corregir
        public static List<Pago> listarPagosRealizados(int pIdUsuario)
        {
            return gymsydb.Pagos
                   .Where(p => p.IdUsuario == pIdUsuario)
                   .Include(p => p.IdTipoPagoNavigation)
                   .ToList();
        }
        //Corregir
        public static List<Pago> listarPagosRecibidos(int pIdUsuario)
        {
            return gymsydb.Pagos
            .Where(p => p.IdUsuario == pIdUsuario)
            .Include(p => p.IdTipoPagoNavigation)
            .ToList();
        }

        public static List<Pago> listarTodasTransferencias(int pIdUsuario)
        {
            try
            {
                // Verifica si el contexto de base de datos está inicializado
                if (gymsydb == null)
                {
                    throw new InvalidOperationException("El contexto de base de datos no está inicializado.");
                }

                // Realiza la consulta para listar todas las transferencias
                var transferencias = gymsydb.Pagos
                    .Where(p => p.IdUsuario == pIdUsuario)
                    .Include(p => p.IdTipoPagoNavigation)
                    .ToList();

                // Registra el resultado de la consulta
                Console.WriteLine($"Se encontraron {transferencias.Count} transferencias para el usuario con ID: {pIdUsuario}.");

                return transferencias;
            }
            catch (Exception ex)
            {
                // Captura y registra detalles de la excepción
                Console.WriteLine($"Error al listar transferencias para el usuario con ID: {pIdUsuario}. Mensaje: {ex.Message}");
                Console.WriteLine($"Detalles de la excepción: {ex.ToString()}");

                // Opcionalmente, puedes registrar la excepción en un archivo de log o un sistema de monitoreo
                LogException(ex, pIdUsuario);

                // Retorna una lista vacía en caso de excepción
                return new List<Pago>();
            }
        }

        private static void LogException(Exception ex, int pIdUsuario)
        {
            // Aquí puedes implementar la lógica para registrar la excepción en un archivo de log o un sistema de monitoreo
            // Ejemplo simple de registrar la excepción en un archivo de texto
            using (StreamWriter writer = new StreamWriter("error_log.txt", true))
            {
                writer.WriteLine("--------------------------------------------------");
                writer.WriteLine($"Fecha: {DateTime.Now}");
                writer.WriteLine($"Usuario ID: {pIdUsuario}");
                writer.WriteLine($"Mensaje de error: {ex.Message}");
                writer.WriteLine($"Detalles de la excepción: {ex.ToString()}");
            }
        }



    }
}
