using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Utilities;
using gymsy.Models;
using gymsy.Modelos;
using Microsoft.EntityFrameworkCore;

namespace gymsy.App.Presenters
{
    internal static class EditClientPresenter
    {

        public static AlumnoSuscripcion AlumSubcripcionDelCliente()
        {
            return AlumnoSuscripcion.obtenerSuscripcionPorAlumno(AppState.ClientActive.IdUsuario);
        }

        public static AlumnoSuscripcion BuscarsSuscripcionPorCliente(int idCliente)
        {
            return AlumnoSuscripcion.obtenerSuscripcionPorAlumno(idCliente);
        }

        public static Usuario BuscarInstrucorDePlan(int idPlan)
        {

            return PlanEntrenamiento.buscarInstrucorDelPlan(idPlan);

        }

        public static List<PlanEntrenamiento> PlanesQueNoSonDelCliente()
        {
            using (var gymsy = new NuevoGymsyContext())
            {
                // Obtener la lista de ID de planes de entrenamiento asociados al cliente
                var planesCliente = gymsy.AlumnoSuscripcions
                                        .Where(subAlum => subAlum.IdAlumno == AppState.ClientActive.IdUsuario)
                                        .Select(subAlum => subAlum.IdPlanEntrenamiento)
                                        .ToList();

                // Obtener los planes de entrenamiento que no están asociados al cliente
                var planesNoCliente = gymsy.PlanEntrenamientos
                                        .Where(planEntrenamiento => !planesCliente.Contains(planEntrenamiento.IdPlanEntrenamiento))
                                        .ToList();

                return planesNoCliente;
            }
        }

        public static void ActualizarCliente(string pUsuario, string pNombre, string pApellido, string pRutaImagen, string pContraseña,
            string pNumeroTelefono, string pGenero, DateTime pBirthDay, DateTime pLastExpiration, int pIdPlan)
        {
            using (var gymsy = new NuevoGymsyContext())
            {
                var personUpdated = gymsy.Usuarios
                               .Where(people => people.IdUsuario == AppState.ClientActive.IdUsuario)
                               .First();


                if (personUpdated != null)
                {
                    // Actualiza las propiedades de la tabla person
                    personUpdated.Apodo = pUsuario;
                    personUpdated.Apellido = pNombre;
                    if (personUpdated.AvatarUrl != pRutaImagen)
                    {
                        personUpdated.AvatarUrl = SaveImage(pRutaImagen);
                    }
                    //Si se cambio la contraseña se actualizara
                    if (personUpdated.Contrasena != pContraseña)
                    {
                        personUpdated.Contrasena = Bcrypt.HashPassoword(pContraseña);
                    }
                    personUpdated.Apellido = pApellido;
                    //personUpdated.CBU = usuario;
                    personUpdated.NumeroTelefono = pNumeroTelefono;
                    personUpdated.Sexo = pGenero;
                    personUpdated.FechaCreacion = pBirthDay;

                    // Actualiza las propiedades de la tabla client
                    var subcripcionAlumno = gymsy.AlumnoSuscripcions
                                   .Where(subAlum => subAlum.IdAlumno == personUpdated.IdUsuario)
                                   .First();
                    subcripcionAlumno.FechaExpiracion = pLastExpiration;
                    subcripcionAlumno.IdPlanEntrenamiento = pIdPlan;

                    gymsy.SaveChanges();
                }
            }
        }

        public static PlanEntrenamiento BuscarPlan(int idPlan)
        {

            return PlanEntrenamiento.buscarPlan(idPlan);

        }

        private static string SaveImage(string imagePath)
        {
            try
            {

                //Ruta completa para guardar la imagen en la carpeta
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

                return uniqueFileName;//nombre del archivo 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }

    }
}
