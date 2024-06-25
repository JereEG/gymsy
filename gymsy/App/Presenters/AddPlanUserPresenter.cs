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
    internal static class AddPlanUserPresenter
    {
        public static List<PlanEntrenamiento> ListarPlanesInstructor(int pIdInstructor)
        {
            return PlanEntrenamiento.buscarPlanesPorInstructor(pIdInstructor);
    
        }
        public static void EliminarOActivarPlan(int pIdPlan, bool pDeleteOrAcitive)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {

                var plan = gymsydb.PlanEntrenamientos.Where(p => p.IdPlanEntrenamiento == pIdPlan).FirstOrDefault();
                if (plan != null)
                {
                    plan.PlanEntrenamientoInactivo = pDeleteOrAcitive;
                    gymsydb.SaveChanges();
                }
            }

        }
        public static void ModificarPlan(int idPlan, string descripcion, decimal precio)
        {
            PlanEntrenamiento.modificarPlan(idPlan,descripcion,precio);

        }

        public static PlanEntrenamiento AgregarPlan(string descripcion, decimal precio)
        {
            return PlanEntrenamiento.agregarPlan(descripcion, precio);
        }


        public static bool DescripcionUnica(string nuevaDescripcion, int? idPlanActual = null)
        {
            return PlanEntrenamiento.descripcionUnica(nuevaDescripcion, idPlanActual);
        }
       


    }
}
