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
using Microsoft.EntityFrameworkCore;

namespace gymsy.App.Presenters
{
    internal static class AddClientPresenter
    {

        public static PlanEntrenamiento TraerPrimerPlan()
        {
            using (var gymsydb = new NuevoGymsyContext())
            {
                return gymsydb.PlanEntrenamientos.FirstOrDefault();
            }
        }

        public static PlanEntrenamiento BuscarPlan(int idPlan)
        {
            return PlanEntrenamiento.buscarPlan(idPlan);
        }


        public static Usuario BuscarInstrucorDelPlan(int idPlan)
        {
            return PlanEntrenamiento.buscarInstrucorDelPlan(idPlan);
        }

        public static List<PlanEntrenamiento> TraerPlanes()
        {
            return PlanEntrenamiento.listarPlanes();
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
                FechaNacimiento = pFechaNacimiento,
                NumeroTelefono = pNumberPhone,
                Sexo = pSexo,
                IdRol = 3, // 3 es el rol de cliente
                UsuarioInactivo = true // ya que aun no ha pagado
            };
            using (var gymsydb = new NuevoGymsyContext())
            {
                // Se guarda en la base de datos
                gymsydb.Usuarios.Add(usuario);
                gymsydb.SaveChanges();
            }

            AlumnoSuscripcion.guardarSuscripcion(usuario.IdUsuario,pIdPlan,pExpiration);

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
        public static Usuario ObtenerUsuario(int idUsuario)
        {
            return Usuario.buscarUsuario(idUsuario, 0);
        }


        public static bool IsNicknameUnique(string nickname)
        {

            try
            {

                if (Usuario.esUnicoElApodo(nickname))
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
