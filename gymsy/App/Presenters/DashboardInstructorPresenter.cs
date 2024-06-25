
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Models;
using gymsy.Modelos;


namespace gymsy.App.Presenters
{
    internal static class DashboardInstructorPresenter
    {

        public static int ContarExpiradosONoExpirados(bool Expirado)
        {
            using (var gymsydb = new NuevoGymsyContext())
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
                }
                else
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
        }
        
    }

}
