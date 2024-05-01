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
    internal static class AddPlanUserPresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;

        public static List<TrainingPlan> listarPlanesInstructor()
        {
            return gymsydb.TrainingPlans.Where(p => p.IdInstructor == AppState.Instructor.IdInstructor).ToList();
        }

        public static void modificarPlan(int pidPlan, string pDescripcion, float pPrecio)
        {
            var plan = gymsydb.TrainingPlans.Where(p => p.IdTrainingPlan == pidPlan).FirstOrDefault();
            plan.Description = pDescripcion;
            plan.Price = pPrecio;

            gymsydb.SaveChanges();

            //Se actualiza el plan en la base de datos


        }
        public static TrainingPlan guardarPlan(string pDescripcion, float pPrecio)
        {
            TrainingPlan plan = new TrainingPlan();
            plan.Description = pDescripcion;
            plan.Price = pPrecio;
            plan.Inactive = false;
            plan.IdInstructor = AppState.Instructor.IdInstructor;

            gymsydb.TrainingPlans.Add(plan);
            gymsydb.SaveChanges();
            return plan;
        }
        public static bool DescripcionUnica(string nuevaDescripcion, int? idPlanActual = null)
        {
            // Consulta para encontrar planes con la misma descripción
            var planesConMismaDescripcion = gymsydb.TrainingPlans
                .Where(p => p.Description == nuevaDescripcion);

            // Si se está modificando un plan, excluimos el plan actual de la consulta
            if (idPlanActual.HasValue)
            {
                planesConMismaDescripcion = planesConMismaDescripcion.Where(p => p.IdTrainingPlan != idPlanActual);
            }

            // Verificamos si se encontró algún plan con la misma descripción
            bool descripcionUnica = !planesConMismaDescripcion.Any();

            // Devolvemos el resultado
            return descripcionUnica;
        }
        public static void EliminarOActivarPlan( int pIdPlan, bool pDeleteOrAcitive)
        {

           var plan = gymsydb.TrainingPlans.Where(p => p.IdTrainingPlan == pIdPlan).FirstOrDefault();
            if (plan != null)
            {
                plan.Inactive = pDeleteOrAcitive;
                gymsydb.SaveChanges();
            }
            
        }
        public static TrainingPlan buscarPlan(int pidPlan)
        {
            return gymsydb.TrainingPlans.Where(p => p.IdTrainingPlan == pidPlan).FirstOrDefault();
        }


    }
}
