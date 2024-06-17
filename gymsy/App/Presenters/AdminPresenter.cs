using gymsy.App.Views.UserControls.AdminControls;
using gymsy.Modelos;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using gymsy.Models;

namespace gymsy.App.Presenters
{
    internal static class AdminPresenter
    {
        private static bool isEditMode = false; // Variable para saber si se está editando o agregando 

        private static NuevoGymsyContext gymsydb = StacticGymsyContext.GymsyContextDB;

       

        // Método para agregar un nuevo usuario (Instructor)
        public static void GuardarInstructor(string nombre, string apellido, string telefono, string usuario, string contraseña, string nameImage, string sexo, DateTime pfecha_cumpleanos)
        {
            ProcedimientoAlmacenado.CrearInstructor(usuario, nombre, apellido, nameImage, contraseña, telefono, sexo);
        }

        // Método para obtener un usuario por su ID
        public static Usuario GetUsuario(int idUsuario)
        {
            return gymsydb.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        // Método para verificar si el nickname es único
        public static bool NicknameUnique(string nickname)
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

        // Método para crear un backup de la base de datos
        public static string Backup()
        {
            string rutaDeCopiaDeSeguridad = "C:\\backup";
            if (!Directory.Exists(rutaDeCopiaDeSeguridad))
            {
                Directory.CreateDirectory(rutaDeCopiaDeSeguridad);
            }

            rutaDeCopiaDeSeguridad += "\\" + $"Backup_{DateTime.Now:yyyyMMddHHmmss}.bak";

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

        // Método para restaurar la base de datos desde un backup
        public static void Restore(string backupPath)
        {
            string databaseName = "gymsy";
            string connectionString = Resources.stringConnection;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlSingleUser = $"ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                using (SqlCommand singleUserCommand = new SqlCommand(sqlSingleUser, connection))
                {
                    singleUserCommand.ExecuteNonQuery();
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

        // Método para seleccionar un archivo de backup
        public static string Buscar()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos .bak|*.bak"
            };

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

        // Métodos relacionados con pagos y suscripciones
        public static IEnumerable<object> Pays()
        {
            return gymsydb.Pagos
                 .GroupBy(p => new { Mes = p.FechaCreacion.Month, Anio = p.FechaCreacion.Year })
                 .Select(g => new
                 {
                     Mes = g.Key.Mes,
                     Anio = g.Key.Anio,
                    // SumaPagos = g.Sum(p => p.monto)
                 })
                 .Select(item => new
                 {
                     Mes = item.Mes,
                    // Amount = item.SumaPagos
                 })
                 .ToArray();
        }

        public static System.Windows.Forms.DataVisualization.Charting.Series Mes(List<string> listMonth, System.Windows.Forms.DataVisualization.Charting.Series series)
        {
            var resultado = gymsydb.Pagos
                .GroupBy(p => new { Mes = p.FechaCreacion.Month, Anio = p.FechaCreacion.Year })
                .Select(g => new
                {
                    Mes = g.Key.Mes,
                    Anio = g.Key.Anio,
                    //SumaPagos = g.Sum(p => p.monto)
                })
                .Select(item => new
                {
                    Mes = item.Mes,
                    //Amount = item.SumaPagos
                })
                .ToArray();

            var listaMes = Enumerable.Range(1, 12)
                   .Select(mes => resultado.FirstOrDefault(r => r.Mes == mes))
                   .ToArray();
            foreach (var data in listaMes)
            {
                series.Points.AddXY(listMonth[data.Mes - 1], 010101);
                series.LegendToolTip = $"Ganancia obtenida por mes";
            }
            return series;
        }

        public static DataGridView DatagridPay(DataGridView dataGridPays)
        {
            var ultimosPagos = gymsydb.Pagos
            .OrderByDescending(p => p.FechaCreacion)
            .Take(5)
            .Include(p => p.IdUsuario)
            .ToList();

            foreach (var pay in ultimosPagos)
            {
                dataGridPays.Rows.Add(
                    pay.IdPago,
                    pay.FechaCreacion,
                    $"$ {0101010}",
                    $"{pay.IdUsuarioNavigation.Apellido}, {pay.IdUsuarioNavigation.Nombre}"
                );
            }
            return dataGridPays;
        }

        public static System.Windows.Forms.DataVisualization.Charting.Series InstructorCant(System.Windows.Forms.DataVisualization.Charting.Series series)
        {
            var resultado = gymsydb.PlanEntrenamientos
                    .Where(plan => plan.IdEntrenadorNavigation.IdRol == 2)
                    .Select(plan => new
                    {
                        Instructor = plan.IdEntrenadorNavigation,
                        CantidadClientes = plan.AlumnoSuscripcions.Count()
                    })
                    .ToList();

            foreach (var data in resultado)
            {
                if (data.CantidadClientes > 0)
                {
                    series.Points.AddXY($"{data.Instructor.Nombre} - {data.CantidadClientes} Clientes.", data.CantidadClientes);
                    series.LegendToolTip = $"{data.Instructor.Apellido}, {data.Instructor.Nombre} - {data.CantidadClientes} Clientes.";
                }
            }
            return series;
        }

        // Método para actualizar un usuario (Instructor)
        public static void PersonUpdated(string nombre, string apellido, string telefono, string usuario, string contraseña, string rutaImagen, bool masculino, DateTime fechaNacimiento)
        {
            try
            {
                var usuarioActualizado = gymsydb.Usuarios
                           .Where(u => u.IdUsuario == AppState.InstructorActive.IdUsuario)
                           .FirstOrDefault();

                string sexo = masculino ? "M" : "F";

                if (usuarioActualizado != null)
                {
                    usuarioActualizado.Apodo = usuario;
                    usuarioActualizado.Nombre = nombre;
                    if (usuarioActualizado.AvatarUrl != rutaImagen)
                    {
                        usuarioActualizado.AvatarUrl = SaveImage(rutaImagen);
                    }

                    if (usuarioActualizado.Contrasena != contraseña)
                    {
                        usuarioActualizado.Contrasena = Bcrypt.HashPassoword(contraseña);
                    }
                    usuarioActualizado.Apellido = apellido;
                    usuarioActualizado.NumeroTelefono = telefono;
                    usuarioActualizado.Sexo = sexo;

                    gymsydb.SaveChanges();

                    MessageBox.Show("Se editaron correctamente los datos");
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
                string pathDestinationFolder = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor;

                if (!Directory.Exists(pathDestinationFolder))
                {
                    Directory.CreateDirectory(pathDestinationFolder);
                }

                var fileName = Path.GetFileName(imagePath);
                var destinationFilePath = Path.Combine(pathDestinationFolder, fileName);

                if (File.Exists(destinationFilePath))
                {
                    return destinationFilePath;
                }

                File.Copy(imagePath, destinationFilePath, true);
                return destinationFilePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la imagen: " + ex.Message);
            }
        }
        // InstructorAdmin

        public static IEnumerable<Usuario> GetInstructors()
        {
            return gymsydb.Usuarios
                                 .Where(instructor => instructor.IdRol == 2)
                                 .ToList();
        }
        public static Usuario getInstructor(int pId_intructor)
        {
            return gymsydb.Usuarios
                                 .Where(instructor => instructor.IdRol == 2 && instructor.IdUsuario == pId_intructor)
                                 .First();
        }
        public static int InstructorCantClientes(Usuario instructor)
        {
            // Obtener la cantidad de clientes suscritos a los planes del instructor
            int cantidadClientes = gymsydb.AlumnoSuscripcions
                .Where(suscripcion =>
                    gymsydb.PlanEntrenamientos
                        .Where(plan => plan.IdEntrenador== instructor.IdUsuario)
                        .Select(plan => plan.IdPlanEntrenamiento)
                        .Contains(suscripcion.IdPlanEntrenamiento))
                .Select(suscripcion => suscripcion.IdAlumno)
                .Distinct()
                .Count();

            return cantidadClientes;

        }
        public static decimal ingresoPorClientes(Usuario instructor)
        {
            // Consulta para calcular el ingreso total
            decimal ingresoTotal = gymsydb.PlanEntrenamientos
                .Where(plan => plan.IdEntrenador == instructor.IdUsuario) // Filtrar planes por instructor
                .Join(gymsydb.AlumnoSuscripcions,
                      plan => plan.IdPlanEntrenamiento,
                      suscripcion => suscripcion.IdPlanEntrenamiento,
                      (plan, suscripcion) => new { plan.Precio }) // Unir con suscripciones y seleccionar el precio del plan
                .Sum(x => x.Precio); // Calcular la suma del precio multiplicado por la cantidad de suscripciones

            return ingresoTotal;

        }


    }
}
