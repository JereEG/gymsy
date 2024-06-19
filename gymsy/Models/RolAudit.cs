using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class RolAudit
{
    public int AuditId { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public bool? RolInactivo { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
