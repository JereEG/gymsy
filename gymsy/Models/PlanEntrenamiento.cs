using System;
using System.Collections.Generic;

namespace gymsy.Models;

public partial class PlanEntrenamiento
{
    public int IdPlanEntrenamiento { get; set; }

    public int IdUsuario { get; set; }

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public bool PlanEntrenamientoInactivo { get; set; }

    public virtual ICollection<AlumnoSuscripcion> AlumnoSuscripcions { get; set; } = new List<AlumnoSuscripcion>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
