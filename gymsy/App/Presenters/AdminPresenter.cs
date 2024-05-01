using gymsy.App.Models;
using gymsy.App.Views.UserControls.AdminControls;
using gymsy.Context;
using gymsy.Properties;
using gymsy.UserControls.AdminControls;
using gymsy.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using Twilio.Rest.Trunking.V1;

namespace gymsy.App.Presenters
{
    internal class AdminPresenter
    {
        private bool isEditMode = false; // Variable para saber si se esta editando o agregando 

        private GymsyDbContext dbContext;
        public AdminPresenter()
        {
            this.dbContext = GymsyContext.GymsyContextDB;
            
        }


        // ADD Instructor
        public void GuardarCliente(string nombre,string apellido,string telefono,string usuario,string contraseña,string nameImage,string sexo,DateTime birthday)
        {
           


                    Person persona = new Person
                    {
                        Nickname = usuario,
                        FirstName = nombre,
                        Avatar = nameImage,
                        Password = contraseña,
                        CreatedAt = DateTime.Now,
                        LastName = apellido,

                        NumberPhone = telefono,
                        Birthday = birthday,
                        Gender = sexo,
                        RolId = 2,//2 es el rol de Instructor
                        Inactive = false
                    };
                    //se guarda en la base de datos, primero la persona por la relacion de la llave foranea
                    this.dbContext.People.Add(persona);
                    this.dbContext.SaveChanges();

                    Instructor newInstructor = new Instructor
                    {
                        IdPerson = persona.IdPerson
                    };

                    //Se guarda en AppState
                    //AppState.clients.Add(persona);

                    Wallet wallet = new Wallet
                    {
                        Total = 0.0,
                        Retirable = 0.0,
                        CBU = usuario,
                        Inactive = false,
                        IdPerson = persona.IdPerson
                    };

                    this.dbContext.Add(wallet);
                    this.dbContext.SaveChanges();

                    this.dbContext.Instructors.Add(newInstructor);
                    this.dbContext.SaveChanges();

                    
        }


        
 
        public bool NicknameUnique(string nickname)
        {
            try
            {
                // Consulta la base de datos para verificar si ya existe un registro con el mismo 'nickname'
                var existingPerson = this.dbContext.People.FirstOrDefault(p => p.Nickname == nickname);

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











        // adminControl
        public string backup()
        {
            string rutaDeCopiaDeSeguridad = "C:\\backup";

            if (!Directory.Exists(rutaDeCopiaDeSeguridad))
            {
                Directory.CreateDirectory(rutaDeCopiaDeSeguridad);
            }

            rutaDeCopiaDeSeguridad += "\\" + $"Backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak";

            using (var connection = new SqlConnection(Resources.stringConnection))
            {
                connection.Open();
                using (var command = new SqlCommand($"BACKUP DATABASE [gymsy] TO DISK = '{rutaDeCopiaDeSeguridad}'", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return rutaDeCopiaDeSeguridad;
        }

        public void restore(string backupPath)
        {
            string databaseName;
            string connectionString;

            using (var context = this.dbContext)
            {
                connectionString = Resources.stringConnection;
                databaseName = "gymsy";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlsingleuser = $"ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                using (SqlCommand singleusercommand = new SqlCommand(sqlsingleuser, connection))
                {
                    singleusercommand.ExecuteNonQuery();
                }
                string sqlUseMaster = "USE master;";
                using (SqlCommand useMasterCommand = new SqlCommand(sqlUseMaster, connection))
                {
                    useMasterCommand.ExecuteNonQuery();
                }
                string sqlRestore = $"RESTORE DATABASE {databaseName} FROM DISK = '{backupPath}';";

                using (SqlCommand restoreCommand = new SqlCommand(sqlRestore, connection))
                {
                    restoreCommand.ExecuteNonQuery();
                }
            }
        }


        public string buscar()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos .bak|*.bak";

            // Muestra el cuadro de diálogo para seleccionar un archivo .bak
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    return openFileDialog.FileName;

                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Ocurrió un error al cargar el archivo .bak: " + ex.Message);
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        //Dashboard

        public IEnumerable<object> Pays()
        {
            return dbContext.Pays
                 .GroupBy(p => new { Mes = p.CreatedAt.Month, Anio = p.CreatedAt.Year })
                 .Select(g => new
                 {
                     Mes = g.Key.Mes,
                     Anio = g.Key.Anio,
                     SumaPagos = g.Sum(p => p.Amount)
                 })
                 .Select(item => new
                 {
                     Mes = item.Mes,
                     Amount = item.SumaPagos
                 })
                 .ToArray();
        }
        public System.Windows.Forms.DataVisualization.Charting.Series mes(List<string> listMonth,System.Windows.Forms.DataVisualization.Charting.Series series)
        {
            var Resultado=dbContext.Pays
                .GroupBy(p => new { Mes = p.CreatedAt.Month, Anio = p.CreatedAt.Year })
                .Select(g => new
                {
                    Mes = g.Key.Mes,
                    Anio = g.Key.Anio,
                    SumaPagos = g.Sum(p => p.Amount)
                })
                .Select(item => new
                {
                    Mes = item.Mes,
                    Amount = item.SumaPagos
                })
                .ToArray();

            var listames=Enumerable.Range(1, 12)
                   .Select(mes => Resultado.FirstOrDefault(r => r.Mes == mes) ?? new { Mes = mes, Amount = 0.0 })
                   .ToArray();
            foreach (var data in listames)
            {
                series.Points.AddXY(listMonth[data.Mes - 1], data.Amount);
                series.LegendToolTip = $"Ganancia obtenida por mes";
            }
            return series;
        }

        public DataGridView DatagridPay(DataGridView DataGridPays)
        {

            var ultimosPagos = this.dbContext.Pays
            .OrderByDescending(p => p.CreatedAt)
            .Take(5) // Puedes ajustar la cantidad de pagos que deseas obtener
            .Include(p => p.Remitente)
            .ToList();



            foreach (Pay pay in ultimosPagos)
            {
                DataGridPays.Rows.Add(
                    pay.IdPay,
                    pay.CreatedAt,
                    $"$ {pay.Amount}",
                    $"{pay.Remitente.LastName}, {pay.Remitente.FirstName}"
                );
            }
            return DataGridPays;
        }

            public System.Windows.Forms.DataVisualization.Charting.Series InstructorCant(System.Windows.Forms.DataVisualization.Charting.Series series) {
                var resultado= dbContext.Instructors
                        .Select(instructor => new
                        {
                            Instructor = instructor,
                            CantidadClientes = instructor.TrainingPlans.SelectMany(plan => plan.Clients).Count()
                        })
                        .ToList();
                foreach (var data in resultado)
                {
                    if (data.CantidadClientes > 0)
                    {
                    series.Points.AddXY($"{data.Instructor.IdPersonNavigation.FirstName} - {data.CantidadClientes} Clientes.", data.CantidadClientes);
                    series.LegendToolTip = $"{data.Instructor.IdPersonNavigation.LastName}, {data.Instructor.IdPersonNavigation.FirstName} - {data.CantidadClientes} Clientes.";

                    }

                }
            return series;
        }







        //edit Instructor
        public void personUpdated(string TBNombre,string TBApellido,string TBTelefono,string TBUsuario,string TBContraseña,string TBRutaImagen,bool RBMasculino,DateTime DPFechaNacimiento)
        {

            try
            {

                var personUpdated= dbContext.People
                           .Where(people => people.IdPerson == AppState.InstructorActive.IdPersonNavigation.IdPerson)
                           .First();
            

                string nombre = TBNombre;
                string apellido = TBApellido;
                string telefono = TBTelefono;
                string usuario = TBUsuario;
                string contraseña = TBContraseña;
                string rutaImagen = TBRutaImagen;
                string sexo = RBMasculino ? "M" : "F";
            
          

                if (personUpdated != null)
                {
                    // Actualiza las propiedades de la tabla person
                    personUpdated.Nickname = usuario;
                    personUpdated.FirstName = TBNombre;
                    if (personUpdated.Avatar != TBRutaImagen)
                    {
                        personUpdated.Avatar = SaveImage(TBRutaImagen);
                    }

                    //Si se cambio la contraseña se actualizara
                    if (personUpdated.Password != TBContraseña)    
                    {
                        personUpdated.Password = Bcrypt.HashPassoword(TBContraseña);
                    }
                    personUpdated.LastName = TBApellido;
                    //personUpdated.CBU = usuario;
                    personUpdated.NumberPhone = TBTelefono;
                    personUpdated.Gender = sexo;
                    personUpdated.Birthday = DPFechaNacimiento;

                    this.dbContext.SaveChanges();

                    MessageBox.Show("Se Editaron correcctamente los datos");
                }
                AppState.isModeEdit = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string SaveImage(string imagePath)
        {
            try
            {

                //Ruta completa para guardar la imagen en la carpetaS
                string pathDestinationFolder = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor;


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
                MessageBox.Show("que garron");
                MessageBox.Show(e.Message);
                return "";
            }

        }



        // InstructorAdmin

        public IEnumerable<Instructor> GetInstructors() {return this.dbContext.Instructors.ToList(); }


        public int InstructorCantClientes(Instructor instructor)
        {
            
           return dbContext.Clients.Where(c => c.IdTrainingPlanNavigation.IdInstructor == instructor.IdInstructor).Count();
       
        }

        public double ingresoClientes(Instructor instructor)
        {
           
            return  this.dbContext.Clients.Where(c => c.IdTrainingPlanNavigation.IdInstructor == instructor.IdInstructor).Sum(c => c.IdTrainingPlanNavigation.Price);
        }





    }
}
