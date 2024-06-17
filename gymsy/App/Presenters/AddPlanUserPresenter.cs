﻿using gymsy.Context;
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
        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;

        public static List<PlanEntrenamiento> listarPlanesInstructor(int pIdInstructor)
        {
            using (var gymsydb=new NuevoGymsyContext())
            {
                return gymsydb.PlanEntrenamientos
                    .Where(p => p.IdEntrenadorNavigation.IdRol == 2 && p.IdEntrenador == pIdInstructor).ToList();
            }
                
        }

        public static void modificarPlan(int pidPlan, string pDescripcion, decimal pPrecio)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                var plan = gymsydb.PlanEntrenamientos
                    .Where(p => p.IdPlanEntrenamiento == pidPlan).FirstOrDefault();
                plan.Descripcion = pDescripcion;
                plan.Precio = pPrecio;

                gymsydb.SaveChanges();

                //Se actualiza el plan en la base de datos
            }

        }
        public static PlanEntrenamiento guardarPlan(string pDescripcion, decimal pPrecio)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                PlanEntrenamiento plan = new PlanEntrenamiento();
                plan.Descripcion = pDescripcion;
                plan.Precio = pPrecio;
                plan.PlanEntrenamientoInactivo = false;
                plan.IdEntrenador = AppState.Instructor.IdUsuario;

                gymsydb.PlanEntrenamientos.Add(plan);
                gymsydb.SaveChanges();
                return plan;
            }
        }
        public static bool DescripcionUnica(string nuevaDescripcion, int? idPlanActual = null)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                // Consulta para encontrar planes con la misma descripción
                var planesConMismaDescripcion = gymsydb.PlanEntrenamientos
                .Where(p => p.Descripcion == nuevaDescripcion);

                // Si se está modificando un plan, excluimos el plan actual de la consulta
                if (idPlanActual.HasValue)
                {
                    planesConMismaDescripcion = planesConMismaDescripcion.Where(p => p.IdPlanEntrenamiento != idPlanActual);
                }

                // Verificamos si se encontró algún plan con la misma descripción
                bool descripcionUnica = !planesConMismaDescripcion.Any();

                // Devolvemos el resultado
                return descripcionUnica;
            }
        }
        public static void EliminarOActivarPlan( int pIdPlan, bool pDeleteOrAcitive)
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
        public static PlanEntrenamiento buscarPlan(int pidPlan)
        {
            using (var gymsydb=new NuevoGymsyContext())
            {
                return gymsydb.PlanEntrenamientos.Where(p => p.IdPlanEntrenamiento == pidPlan).FirstOrDefault();
            }
               
        }


    }
}
