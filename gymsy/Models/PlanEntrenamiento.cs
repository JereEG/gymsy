using gymsy.Context;
using gymsy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class PlanEntrenamiento
{
    public int IdPlanEntrenamiento { get; set; }

    public int IdEntrenador { get; set; }

    public decimal Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool PlanEntrenamientoInactivo { get; set; }

    public virtual ICollection<AlumnoSuscripcion> AlumnoSuscripcions { get; set; } = new List<AlumnoSuscripcion>();

    public virtual Usuario IdEntrenadorNavigation { get; set; } = null!;

    public static bool descripcionUnica(string nuevaDescripcion, int? idPlanActual = null)
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
    public static PlanEntrenamiento agregarPlan(string pDescripcion, decimal pPrecio)
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


    public static PlanEntrenamiento buscarPlan(int idPlan)
    {
        using (var gymsy = new NuevoGymsyContext())
        {
            return gymsy.PlanEntrenamientos
                .Where(trainingPlan => trainingPlan.IdPlanEntrenamiento == idPlan)
                .First();
        }
    }


    public static void modificarPlan(int idPlan, string descripcion, decimal precio)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            var plan = gymsydb.PlanEntrenamientos
                .Where(p => p.IdPlanEntrenamiento == idPlan).FirstOrDefault();
            plan.Descripcion = descripcion;
            plan.Precio = precio;

            gymsydb.SaveChanges();
        }

    }


    public static List<PlanEntrenamiento> buscarPlanesPorInstructor(int id)
    {
        // Obtener todos los planes de entrenamiento del instructor actual
        using (var gymsydb = new NuevoGymsyContext())
        {
            return gymsydb.PlanEntrenamientos
               .Where(plan => plan.IdEntrenador == id)
               .Include(plan => plan.AlumnoSuscripcions)
               .ToList();
        }

    }

    public static Usuario buscarInstrucorDelPlan(int idPlan)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                // Busca el plan de entrenamiento por su Id e incluye la entidad Instructor relacionada
                var plan = gymsydb.PlanEntrenamientos
                                  .Include(p => p.IdEntrenador) // Asume que PlanEntrenamiento tiene una propiedad de navegación Instructor
                                  .FirstOrDefault(plan => plan.IdPlanEntrenamiento == idPlan);

                // Retorna el instructor asociado al plan si se encuentra, de lo contrario devuelve null
                return plan?.IdEntrenadorNavigation;
            }
        }

    public static List<PlanEntrenamiento> listarPlanes()
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            return gymsydb.PlanEntrenamientos.ToList();
        }
    }


     public static void desactivarOActivarPlan(int idPlan, bool estado)
        {
            using (var gymsydb = new NuevoGymsyContext())
            {

                var plan = gymsydb.PlanEntrenamientos.Where(p => p.IdPlanEntrenamiento == idPlan).FirstOrDefault();
                if (plan != null)
                {
                    plan.PlanEntrenamientoInactivo = estado;
                    gymsydb.SaveChanges();
                }
            }

        }
}
