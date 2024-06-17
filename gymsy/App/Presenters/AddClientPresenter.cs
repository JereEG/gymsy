using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Utilities;
using System.Runtime.CompilerServices;
using gymsy.Models;
using gymsy.Modelos;

namespace gymsy.App.Presenters
{
    internal static class AddClientPresenter
    {
        private static GymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;

        public static PlanEntrenamiento TraerPrimerPlan()
        {
            return gymsydb.PlanEntrenamientos.FirstOrDefault();
        }

        public static PlanEntrenamiento BuscarPlan(int pIdPlanBuscado)
        {
            return gymsydb.PlanEntrenamientos
                    .Where(plan => plan.IdPlanEntrenamiento == pIdPlanBuscado)
                    .First();
        }

        public static List<PlanEntrenamiento> TraerPlanes()
        {
            return gymsydb.PlanEntrenamientos.ToList();
        }
        
        public static void GuardarCliente(string pUsuario, string pNombre, string pApellido, string pAvatar, string pPassword, string pNumberPhone,
            string pSexo, DateTime pFechaNacimiento, DateTime pExpiration, int pIdPlan)
        {
            Usuario usuario = new Usuario()
            {
                Apodo = pUsuario,
                Nombre = pNombre,
                Apellido = pApellido,
                AvatarUrl = SaveImage(pAvatar),
                Contrasena = Bcrypt.HashPassoword(pPassword),
                FechaCreacion = DateTime.Now,
                NumeroTelefono = pNumberPhone,
                Sexo = pSexo,
                IdRol = 3, // 3 es el rol de cliente
                UsuarioInactivo = true // ya que aun no ha pagado
            };

            // Se guarda en la base de datos
            gymsydb.Usuarios.Add(usuario);
            gymsydb.SaveChanges();

            AlumnoSuscripcion suscripcion = new AlumnoSuscripcion
            {
                IdAlumno = usuario.IdUsuario,
                IdPlanEntrenamiento = pIdPlan,
                FechaExpiracion = pExpiration
            };

            gymsydb.AlumnoSuscripcions.Add(suscripcion);
            gymsydb.SaveChanges();

            // Se guarda en AppState
            AppState.clients.Add(usuario);
        }
        
        private static string SaveImage(string imagePath)
        {
            try
            {
                // Ruta completa para guardar la imagen en la carpeta
                string pathDestinationFolder = AppState.pathDestinationFolder + AppState.nameCarpetImageClient;

                // Asegúrate de que la carpeta exista, y si no, créala
                if (!Directory.Exists(pathDestinationFolder))
                {
                    Directory.CreateDirectory(pathDestinationFolder);
                }

                // Obtén la extensión de archivo de la imagen original
                string extension = Path.GetExtension(imagePath);

                // Genera un nombre de archivo único usando un GUID y la fecha/hora actual
                string uniqueFileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;

                // Ruta completa para guardar la imagen en la carpeta
                string destinationPath = Path.Combine(pathDestinationFolder, uniqueFileName);

                // Copia la imagen desde la ubicación original a la carpeta de destino
                File.Copy(imagePath, destinationPath, true);

                return uniqueFileName; // nombre del archivo 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
        public static List<Usuario> getUsuarios(int idUsuario)
        {
            return (List<Usuario>)gymsydb.Usuarios.Where(u => u.IdUsuario == idUsuario);
        }
        public static bool IsNicknameUnique(string nickname)
        {
            try
            {
                // Consulta la base de datos para verificar si ya existe un registro con el mismo 'nickname'
                var existingPerson = gymsydb.Usuarios.FirstOrDefault(u => u.Apodo == nickname);

                // Si 'existingPerson' no es nulo, significa que ya existe un registro con el mismo 'nickname'
                if (existingPerson == null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ya existe");
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
}
