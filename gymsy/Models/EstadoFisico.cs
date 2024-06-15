using System;
using System.Collections.Generic;

namespace gymsy.Models;

public partial class EstadoFisico
{
    public int IdEstadoFisico { get; set; }

    public string Titulo { get; set; } = null!;

    public decimal Peso { get; set; }

    public decimal Altura { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Notas { get; set; }

    public bool EstadoFisicoInactivo { get; set; }

    public int IdAlumnoSuscripcion { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual AlumnoSuscripcion IdAlumnoSuscripcionNavigation { get; set; } = null!;
}
