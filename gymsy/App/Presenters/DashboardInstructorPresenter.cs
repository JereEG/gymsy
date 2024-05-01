using gymsy.App.Models;
using gymsy.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Presenters
{
    internal static class DashboardInstructorPresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;

        // Método para obtener pagos agrupados por mes
        public static List<PagoPorMes> ObtenerPagosAgrupadosPorMes()
        {
            List<string> listMonths = new List<string>
            {
                "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nob", "Dec"
            };
            Random rnd = new Random();

            // Definir el rango de meses y años que te interesa
            var rangoMesesAnios = Enumerable.Range(1, 12)
                .SelectMany(mes => Enumerable.Range(2022, 2).Select(anio => new { Mes = mes, Anio = anio }));

            // Realizar el left join con los pagos
            var pagosAgrupadosPorMes = from mesAnio in rangoMesesAnios
                                       join pago in gymsydb.Pays
                                           on new { Mes = mesAnio.Mes, Anio = mesAnio.Anio } equals new { Mes = pago.CreatedAt.Month, Anio = pago.CreatedAt.Year }
                                           into pagosGrupo
                                       from pagosEnMes in pagosGrupo.DefaultIfEmpty()
                                       select new PagoPorMes { Mes = mesAnio.Mes, Anio = mesAnio.Anio, Cantidad = (pagosEnMes != null ? pagosGrupo.Count() * 10 : rnd.Next(10, 14)) };

            // Ordenar los resultados
            return pagosAgrupadosPorMes.OrderBy(g => g.Mes).ThenBy(g => g.Anio).ToList();
        }

        public static List<Client> BuscarClientesActivosDelInstructor(List<int> pIdsPlanesIntructor)
        {
            return gymsydb.Clients
                                .Where(cl => pIdsPlanesIntructor.Contains(cl.IdTrainingPlan))
                                .Where(cl => !cl.IdTrainingPlanNavigation.Inactive && cl.LastExpiration <= DateTime.UtcNow)
                                .ToList();  
        }

        public static int ContarExpiradosONoExp(bool Expirado)
        {
            if (Expirado)
            {
                return gymsydb.Clients.Count(client => !client.IdTrainingPlanNavigation.Inactive && client.LastExpiration <= DateTime.Today); 
            } else
            {
               return gymsydb.Clients.Count(client => !client.IdTrainingPlanNavigation.Inactive && client.LastExpiration > DateTime.Today);
            }
        }
    }

        public class PagoPorMes
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int Cantidad { get; set; }
    }

}
