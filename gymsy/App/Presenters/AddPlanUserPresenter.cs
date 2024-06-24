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
            return PlanEntrenamiento.buscarInstrucorDelPlan(pIdInstructor);
                
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
