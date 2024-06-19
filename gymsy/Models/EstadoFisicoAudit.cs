using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class EstadoFisicoAudit
{
    public int AuditId { get; set; }

    public int? IdEstadoFisico { get; set; }

    public string? Titulo { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Altura { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Notas { get; set; }

    public bool? EstadoFisicoInactivo { get; set; }

    public int? IdAlumnoSuscripcion { get; set; }

    public string? ImagenUrl { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
