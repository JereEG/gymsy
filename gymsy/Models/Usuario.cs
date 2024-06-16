using System;
using System.Collections.Generic;

namespace gymsy.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public string Apodo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string AvatarUrl { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string NumeroTelefono { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public bool UsuarioInactivo { get; set; }

    public virtual ICollection<AlumnoSuscripcion> AlumnoSuscripcions { get; set; } = new List<AlumnoSuscripcion>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<PlanEntrenamiento> PlanEntrenamientos { get; set; } = new List<PlanEntrenamiento>();

    public Usuario(int rol)
    {
        IdRol = rol;
    }
}
