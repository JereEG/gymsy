using gymsy.App.Models;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gymsy.Utilities;
using System.Runtime.CompilerServices;

namespace gymsy.App.Presenters
{
    internal static class AddClientPresenter
    {
        private static GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;

        public static TrainingPlan TraerPrimerPlan()
        {
            return gymsydb.TrainingPlans.FirstOrDefault();
        }
        public static TrainingPlan BuscarPlan(int pIdPlanBuscado)
        {
            return gymsydb.TrainingPlans
                    .Where(trainingPlan => trainingPlan.IdTrainingPlan == pIdPlanBuscado)
                    .First();
        }
        public static List<TrainingPlan> TraerPlanes()
        {
            return gymsydb.TrainingPlans.ToList();
        }

        public static void guardarCliente( string pUsuario, string pNombre, string pApellido, string pAvatar, string pPassword, string pNumberPhone, 
            DateTime pBirthday, string pSexo, DateTime pExpiration, int pIdPlan)
        {
            Person persona = new Person
            {
                Nickname = pUsuario,
                FirstName = pNombre,
                Avatar = SaveImage(pAvatar),
                Password = Bcrypt.HashPassoword(pPassword),
                CreatedAt = DateTime.Now,
                LastName = pApellido,
                //CBU = usuario,
                NumberPhone = pNumberPhone,
                Birthday = pBirthday, //DPFechaNacimiento.Value,
                Gender = pSexo,
                RolId = 3,//3 es el rol de cliente
                Inactive = true // ya que aun no ha pagado
            };

            //se guarda en la base de datos, primero la persona por la relacion de la llave foranea
            gymsydb.People.Add(persona);
            gymsydb.SaveChanges();

            Client cliente = new Client
            {
                LastExpiration = pExpiration,//Se le añade un mes mas a la fecha actual
                IdPerson = persona.IdPerson,
                IdTrainingPlan = pIdPlan,
            };

            //Se guarda en AppState
            AppState.clients.Add(persona);

            Wallet wallet = new Wallet
            {
                Total = 0.0,
                Retirable = 0.0,
                Inactive = false,
                CBU = pUsuario,
                IdPerson = persona.IdPerson
            };

            gymsydb.Add(wallet);
            gymsydb.SaveChanges();



            gymsydb.Clients.Add(cliente);
            gymsydb.SaveChanges();
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
        public static bool IsNicknameUnique(string nickname)
        {
            try
            {
                // Consulta la base de datos para verificar si ya existe un registro con el mismo 'nickname'
                var existingPerson = gymsydb.People.FirstOrDefault(p => p.Nickname == nickname);

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
