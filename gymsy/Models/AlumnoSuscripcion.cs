﻿using gymsy.Models;
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

    public static AlumnoSuscripcion getSuscripcion(int idAlumno)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            return gymsydb.AlumnoSuscripcions.FirstOrDefault(a => a.IdAlumno == idAlumno);
        }
    }
}
