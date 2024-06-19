using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class EstadoFisico
{
    public int IdEstadoFisico { get; set; }

    public string Titulo { get; set; } = null!;

    public decimal Peso { get; set; }

    public decimal Altura { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Notas { get; set; } = null!;

    public bool EstadoFisicoInactivo { get; set; }

    public int IdAlumnoSuscripcion { get; set; }

    public string ImagenUrl { get; set; } = null!;

    public virtual AlumnoSuscripcion IdAlumnoSuscripcionNavigation { get; set; } = null!;
}
