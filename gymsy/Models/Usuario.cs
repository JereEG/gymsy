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



    public static void GuardarInstructor(string nombre, string apellido, string telefono, string usuario, string contraseña, string nameImage, string sexo, DateTime pfecha_cumpleanos)
    {

        using (var gymsydb = new NuevoGymsyContext())
        {

            ProcedimientoAlmacenado.CrearInstructor(usuario, nombre, apellido, nameImage, contraseña, telefono, sexo, pfecha_cumpleanos);
        }

    }

    public static bool IsNicknameUnique(string nickname)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            try
            {
                var existingUsuario = gymsydb.Usuarios.FirstOrDefault(u => u.Apodo == nickname);
                if (existingUsuario == null)
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show("El nombre de usuario ya existe");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el nombre de usuario: " + ex.Message);
                return false;
            }
        }
    }
    public static bool verificarNacimiento(DateTime fechaNacimiento)
    {
        return fechaNacimiento < DateTime.Now;
    }

}
