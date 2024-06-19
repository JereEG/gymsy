using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class PagoAudit
{
    public int AuditId { get; set; }

    public int? IdPago { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTipoPago { get; set; }

    public string? CbuDestino { get; set; }

    public string? CbuOrigen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public decimal? Monto { get; set; }

    public bool? InactivoPago { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
