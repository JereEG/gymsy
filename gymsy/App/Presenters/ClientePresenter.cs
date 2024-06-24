using gymsy.Context;
using gymsy.Modelos;
using gymsy.Models;
using gymsy.Modelos;
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
        public static Usuario BuscarCliente( int pIdCliente)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                return gymsydb.Usuarios
                                    .Where(client => client.IdUsuario == pIdCliente && client.IdRol == 3)
                                    .First();
            }
        }
        
        public static List<PlanEntrenamiento> BuscarPlanesInstructor(int pIdInstructor)
        {
            // Obtener todos los planes de entrenamiento del instructor actual
            using (var gymsydb =new NuevoGymsyContext())
            {
                return gymsydb.PlanEntrenamientos
                   .Where(plan => plan.IdEntrenador == pIdInstructor)
                   .Include(plan => plan.AlumnoSuscripcions)
                   .ToList();
            }
               
        }
       
    }
}
