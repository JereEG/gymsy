using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class PlanEntrenamientoAudit
{
    public int AuditId { get; set; }

    public int? IdPlanEntrenamiento { get; set; }

    public int? IdEntrenador { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public bool? PlanEntrenamientoInactivo { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
