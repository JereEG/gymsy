using gymsy.Models;
using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

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

    public DateTime FechaNacimiento { get; set; }

    public string NumeroTelefono { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public bool UsuarioInactivo { get; set; }

    public virtual ICollection<AlumnoSuscripcion> AlumnoSuscripcions { get; set; } = new List<AlumnoSuscripcion>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<PlanEntrenamiento> PlanEntrenamientos { get; set; } = new List<PlanEntrenamiento>();



    public static void guardarInstructor(string nombre, string apellido, string telefono, string usuario, string contraseña, string nameImage, string sexo, DateTime pfecha_cumpleanos)
    {

        using (var gymsydb = new NuevoGymsyContext())
        {
            ProcedimientoAlmacenado.crearInstructor(usuario, nombre, apellido, nameImage, contraseña, telefono, sexo, pfecha_cumpleanos);
        }
    }

    public static bool esUnicoElApodo(string apodo)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {

            var existingUsuario = gymsydb.Usuarios.FirstOrDefault(u => u.Apodo == apodo);
            if (existingUsuario == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public static bool verificarNacimiento(DateTime fechaNacimiento)
    {
        return fechaNacimiento < DateTime.Now;
    }


    public static void desactivarOActivarUsuario(int idUsuario, bool estado)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            var persona = gymsydb.Usuarios
                .Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

            if (persona != null)
            {
                persona.UsuarioInactivo = estado;
                gymsydb.SaveChanges();
            }
        }

    }

    public static Usuario buscarUsuario(int id, int idRol)
    {

        //Cuando el id rol es cero significa que busca cualquier usuario en cualquier role
        using (var gymsydb = new NuevoGymsyContext())
        {
            if (idRol != 0)
            {
                return gymsydb.Usuarios
                                .Where(usuario => usuario.IdUsuario == id && usuario.IdRol == idRol)
                                .First();
            }
            else
            {
                return gymsydb.Usuarios.Where(usuario => usuario.IdUsuario == id).First();
            }

        }
    }

}
