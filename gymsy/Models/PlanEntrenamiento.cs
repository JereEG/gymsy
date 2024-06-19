using gymsy.Context;
using gymsy.Models;
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
}
