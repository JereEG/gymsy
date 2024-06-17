using gymsy.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Models;


namespace gymsy.App.Presenters
{
    internal static class DashboardInstructorPresenter
    {
        private static GymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;

        // Método para obtener pagos agrupados por mes
        public static List<PagoPorMes> ObtenerPagosAgrupadosPorMes()
        {
            try
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
                                           join pago in gymsydb.Pagos
                                               on new { Mes = mesAnio.Mes, Anio = mesAnio.Anio } equals new { Mes = pago.FechaCreacion.Month, Anio = pago.FechaCreacion.Year }
                                               into pagosGrupo
                                           from pagosEnMes in pagosGrupo.DefaultIfEmpty()
                                           select new PagoPorMes { Mes = mesAnio.Mes, Anio = mesAnio.Anio, Cantidad = (pagosEnMes != null ? pagosGrupo.Count() * 10 : rnd.Next(10, 14)) };

                // Ordenar los resultados
                return pagosAgrupadosPorMes.OrderBy(g => g.Mes).ThenBy(g => g.Anio).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
           
        }

        public static List<Usuario> BuscarClientesActivosDelInstructor(List<int> pIdsPlanesInstructor)
        {
            List<Usuario> activeClients = new List<Usuario>();

            try
            {
                // Filtrar Usuarios con el rol de Cliente (IdRol == 3) y IDs en pIdsPlanesInstructor
                var filteredUsuarios = gymsydb.AlumnoSuscripcions
                    .Where(alumSub => alumSub.IdAlumnoNavigation != null
                                      && alumSub.IdPlanEntrenamientoNavigation != null
                                      && alumSub.IdPlanEntrenamientoNavigation.IdEntrenadorNavigation != null
                                      && alumSub.IdAlumnoNavigation.IdRol == 3
                                      && pIdsPlanesInstructor.Contains(alumSub.IdPlanEntrenamientoNavigation.IdEntrenadorNavigation.IdUsuario))
                    .Select(alumSub => alumSub.IdAlumnoNavigation)
                    .Distinct()
                    .ToList();

                // Filtrar PlanEntrenamientos para incluir solo planes activos
                var activePlans = gymsydb.PlanEntrenamientos
                                         .Where(pl => !pl.PlanEntrenamientoInactivo)
                                         .ToList();

                // Filtrar AlumnoSuscripcions para incluir suscripciones que no están expiradas
                var activeSubscriptions = gymsydb.AlumnoSuscripcions
                                                 .Where(sus => sus.FechaExpiracion > DateTime.UtcNow)
                                                 .ToList();

                // Combinar resultados para obtener clientes activos del instructor
                activeClients = (from usuario in filteredUsuarios
                                 join sus in activeSubscriptions on usuario.IdUsuario equals sus.IdAlumno
                                 join plan in activePlans on sus.IdPlanEntrenamiento equals plan.IdPlanEntrenamiento
                                 select usuario).Distinct().ToList();
            }
            catch (NullReferenceException ex)
            {
                // Manejo específico para NullReferenceException
                LogError(ex);  // Puedes implementar una función para registrar el error
                MessageBox.Show("Se ha producido un error al procesar la solicitud. Por favor, revise los datos e intente nuevamente.");
            }
            catch (Exception ex)
            {
                // Manejo general para cualquier otra excepción
                LogError(ex);  // Puedes implementar una función para registrar el error
                MessageBox.Show("Se ha producido un error inesperado. Por favor, intente nuevamente.");
            }

            return activeClients;
        }

        private static void LogError(Exception ex)
        {
            // Implementa esta función para registrar el error en un archivo de log, base de datos, etc.
            // Aquí hay un ejemplo simple de registro en un archivo de texto:
            string filePath = "C:\\Users\\kille\\Downloads\\logfile.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {ex.Message}");
                writer.WriteLine(ex.StackTrace);
            }
        }


        public static int ContarExpiradosONoExp(bool Expirado)
        {
            var activePlans = gymsydb.PlanEntrenamientos
                             .Where(pl => !pl.PlanEntrenamientoInactivo)
                             .Select(pl => pl.IdPlanEntrenamiento)
                             .ToList();
            if (Expirado)
            {


                // Step 2: Filter AlumnoSuscripcions to include subscriptions that are not expired
                var inactiveSubscriptions = gymsydb.AlumnoSuscripcions
                                                 .Where(sus => sus.FechaExpiracion <= DateTime.Today &&
                                                               activePlans.Contains(sus.IdPlanEntrenamiento))
                                                 .Select(sus => sus.IdAlumno)
                                                 .ToList();

                // Step 3: Count the number of Usuarios who are clients and have active subscriptions
                var inactiveClientCount = gymsydb.Usuarios
                                               .Count(cl => inactiveSubscriptions.Contains(cl.IdUsuario) &&
                                                            cl.IdRol == 3);

                return inactiveClientCount;
            } else
            {
                // Step 2: Filter AlumnoSuscripcions to include subscriptions that are not expired
                var activeSubscriptions = gymsydb.AlumnoSuscripcions
                                                 .Where(sus => sus.FechaExpiracion > DateTime.Today &&
                                                               activePlans.Contains(sus.IdPlanEntrenamiento))
                                                 .Select(sus => sus.IdAlumno)
                                                 .ToList();
                var activeClientCount = gymsydb.Usuarios
                                              .Count(cl => activeSubscriptions.Contains(cl.IdUsuario) &&
                                                           cl.IdRol == 3);
                return activeClientCount;
            }
        }
        public static AlumnoSuscripcion getAlumnoSuscripcion(int idusuario)
        {

            return gymsydb.AlumnoSuscripcions
                .Where(a => a.IdAlumno == idusuario).FirstOrDefault();
        }
    }

        public class PagoPorMes
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int Cantidad { get; set; }
    }

}
