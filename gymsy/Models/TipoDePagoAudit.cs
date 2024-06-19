using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class TipoDePagoAudit
{
    public int AuditId { get; set; }

    public int? IdTipoPago { get; set; }

    public string? Nombre { get; set; }

    public bool? TipoPagoInactivo { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
