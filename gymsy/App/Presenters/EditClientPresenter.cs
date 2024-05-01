using gymsy.App.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Utilities;

namespace gymsy.App.Presenters
{
    internal static class EditClientPresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;

        public static TrainingPlan PlanDelCliente()
        {
           return gymsydb.TrainingPlans
                        .Where(trainingPlan => trainingPlan.IdTrainingPlan == AppState.ClientActive.IdTrainingPlan)
                        .First();
        }
        public static List<TrainingPlan> PlanesQueNoSonDelCliente()
        {
            return gymsydb.TrainingPlans
                        .Where(trainingPlan => trainingPlan.IdTrainingPlan != AppState.ClientActive.IdTrainingPlan)
                        .ToList();
        }

        public static void ActualizarCliente(string pUsuario, string pNombre, string pApellido, string pRutaImagen, string pContraseña,
            string pNumeroTelefono, string pGenero, DateTime pBirthDay, DateTime pLastExpiration, int pIdPlan)
        {
            var personUpdated = gymsydb.People
                               .Where(people => people.IdPerson == AppState.ClientActive.IdPersonNavigation.IdPerson)
                               .First();


            var clientUpdated = gymsydb.Clients
                            .Where(client => client.IdClient == AppState.ClientActive.IdClient)
                            .First();


            if (personUpdated != null && clientUpdated != null)
            {
                // Actualiza las propiedades de la tabla person
                personUpdated.Nickname = pUsuario;
                personUpdated.FirstName = pNombre;
                if (personUpdated.Avatar != pRutaImagen)
                {
                    personUpdated.Avatar = SaveImage(pRutaImagen);
                }
                //Si se cambio la contraseña se actualizara
                if (personUpdated.Password != pContraseña)
                {
                    personUpdated.Password = Bcrypt.HashPassoword(pContraseña);
                }
                personUpdated.LastName = pApellido;
                //personUpdated.CBU = usuario;
                personUpdated.NumberPhone = pNumeroTelefono;
                personUpdated.Gender = pGenero;
                personUpdated.Birthday = pBirthDay;

                // Actualiza las propiedades de la tabla client
                clientUpdated.LastExpiration = pLastExpiration;
                clientUpdated.IdTrainingPlan = pIdPlan;

                gymsydb.SaveChanges();
            }
        }
        
        public static TrainingPlan BuscarPlan(int pIdPlan)
        {
            return gymsydb.TrainingPlans
                    .Where(trainingPlan => trainingPlan.IdTrainingPlan == pIdPlan)
                    .First();
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
