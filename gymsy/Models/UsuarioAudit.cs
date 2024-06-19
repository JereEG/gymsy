using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class UsuarioAudit
{
    public int AuditId { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public string? Apodo { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? NumeroTelefono { get; set; }

    public string? Sexo { get; set; }

    public bool? UsuarioInactivo { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
