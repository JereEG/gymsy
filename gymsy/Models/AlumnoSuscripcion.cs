using gymsy.Models;
using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class AlumnoSuscripcion
{
    public int IdAlumnoSuscripcion { get; set; }

    public int IdAlumno { get; set; }

    public int IdPlanEntrenamiento { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public virtual ICollection<EstadoFisico> EstadoFisicos { get; set; } = new List<EstadoFisico>();

    public virtual Usuario IdAlumnoNavigation { get; set; } = null!;

    public virtual PlanEntrenamiento IdPlanEntrenamientoNavigation { get; set; } = null!;

    public static AlumnoSuscripcion obtenerSuscripcionPorAlumno(int idAlumno)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            return gymsydb.AlumnoSuscripcions.FirstOrDefault(a => a.IdAlumno == idAlumno);
        }
    }


    public static void guardarSuscripcion(int idAlumno,int pIdPlan,DateTime pExpiration)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {

            AlumnoSuscripcion suscripcion = new AlumnoSuscripcion
            {
                IdAlumno = usuario.IdUsuario,
                IdPlanEntrenamiento = pIdPlan,
                FechaExpiracion = pExpiration
            };

            gymsydb.AlumnoSuscripcions.Add(suscripcion);
            gymsydb.SaveChanges();
        }
    }
}
