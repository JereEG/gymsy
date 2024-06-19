using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class AlumnoSuscripcionAudit
{
    public int AuditId { get; set; }

    public int? IdAlumnoSuscripcion { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdPlanEntrenamiento { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
