using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using gymsy.Context;
using gymsy.App.Models;
using System.Collections;
using gymsy.Utilities;
using gymsy.App.Presenters;

namespace gymsy.UserControls
{
    public partial class EditClient : UserControl
    {
        private int indexRowSelect = 0;
        //private GymsyDbContext dbContext;

        //private Dictionary<int, string> descripcionPorValor = new Dictionary<int, string>();

        public EditClient()
        {
            //Se trae el contexto de la base de datos
           // this.dbContext = GymsyContext.GymsyContextDB;

            InitializeComponent();



        }

        public override void Refresh()
        {
            //Se carga el cliente
            this.CargarCliente();
            //Carga el comboBox con los planes
            this.CargarElementosComboBox();
        }
        private void CargarCliente()
        {
            if (AppState.ClientActive != null && AppState.ClientActive.IdPersonNavigation != null)
            {
                string name = AppState.ClientActive.IdPersonNavigation.FirstName.ToString();
                string lastName = AppState.ClientActive.IdPersonNavigation.LastName.ToString();
                string numberPhone = AppState.ClientActive.IdPersonNavigation.NumberPhone.ToString();
                string nickname = AppState.ClientActive.IdPersonNavigation.Nickname.ToString();

                TBContraseña.Text = AppState.ClientActive.IdPersonNavigation.Password.ToString();

                TBNombre.Text = name;
                TBApellido.Text = lastName;
                TBTelefono.Text = numberPhone;
                TBUsuario.Text = nickname;
                //Que hacer con la contraseña?
                TBContraseña.Text = AppState.ClientActive.IdPersonNavigation.Password;

                TBRutaImagen.Text = AppState.ClientActive.IdPersonNavigation.Avatar.ToString();
                if (AppState.ClientActive.IdPersonNavigation.Gender.ToString() == "M" || AppState.ClientActive.IdPersonNavigation.Gender.ToString() == "m")
                {
                    RBMasculino.Checked = true;
                }
                else
                {
                    RBFemenino.Checked = true;
                }
                DPFechaNacimiento.Value = AppState.ClientActive.IdPersonNavigation.Birthday;
                DPVencimiento.Value = AppState.ClientActive.LastExpiration;

                try
                {
                    string ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageClient + "\\" + AppState.ClientActive.IdPersonNavigation.Avatar;

                    IPImagenUsuario.Image = System.Drawing.Image.FromFile(ruta);
                } catch
                {
                    IPImagenUsuario.Image = gymsy.Properties.Resources.vector_fitness_couple_doing_exercise;
                }
                




            }

        }

        private void TBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es una letra del alfabeto
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                // Si no es una letra, ni la tecla de retroceso ni la tecla espacio, suprime la pulsación
                e.Handled = true;
            }
        }

        private void TBApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es una letra del alfabeto
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                // Si no es una letra, ni la tecla de retroceso ni la tecla espacio, suprime la pulsación
                e.Handled = true;
            }
        }


        private void rjTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se cancela el evento KeyPress para que no se escriba nada en el textbox
            e.Handled = true;
        }

        private void BTAgregarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Seleccione la imagen";
                // Configurar el filtro de archivos para mostrar solo imágenes
                openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

                // Mostrar el cuadro de diálogo
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtener la ruta del archivo seleccionado
                        string rutaImagen = openFileDialog1.FileName;

                        // Mostrar la imagen en el PictureBox
                        IPImagenUsuario.Image = System.Drawing.Image.FromFile(rutaImagen);
                        //se escribe en textbox la ruta de la imagen
                        TBRutaImagen.Text = rutaImagen;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al abrir la imagen: " + ex.Message);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Exepcion Inesperado");
            }

        }



        private bool isValidTextsBoxesMostrarError()
        {
            bool isValid = true;

            //Se verifica que se hay ingresado un nombre
            if (!string.IsNullOrWhiteSpace(TBNombre.Text) && TBNombre.PlaceholderText != TBNombre.Text)
            {
                LNombreRequerido.Visible = false;
            }
            else
            {
                LNombreRequerido.Visible = true;
                isValid = false;
            }

            //Se verifica que se hay ingresado un apellido
            if (!string.IsNullOrWhiteSpace(TBApellido.Text) && TBApellido.PlaceholderText != TBApellido.Text)
            {
                LApellidoRequerido.Visible = false;
            }
            else
            {
                LApellidoRequerido.Visible = true;
                isValid = false;
            }

            //Se verifica que se hay ingresado un telefono
            if (!string.IsNullOrWhiteSpace(TBTelefono.Text) && TBTelefono.PlaceholderText != TBTelefono.Text)
            {
                LTelefonoRequerido.Visible = false;
            }
            else
            {

                isValid = false;
                LTelefonoRequerido.Visible = true;
            }

            //Se verifica que se hay ingresado un correo
            if (!string.IsNullOrWhiteSpace(TBUsuario.Text) && TBUsuario.PlaceholderText != TBUsuario.Text)
            {
                LUsurioRequerido.Visible = false;
            }
            else
            {
                isValid = false;
                LUsurioRequerido.Visible = true;
            }

            //Se verifica que se hay ingresado una contraseña
            if (!string.IsNullOrWhiteSpace(TBContraseña.Text))
            {
                LContraseñaRequerido.Visible = false;
            }
            else
            {
                isValid = false;
                LContraseñaRequerido.Visible = true;
                //MessageBox.Show("Con");
            }

            if (!string.IsNullOrWhiteSpace(TBRutaImagen.Text))
            {
                LRuraImagen.Visible = false;

            }
            else
            {
                isValid = false;
                LRuraImagen.Visible = true;

                //MessageBox.Show("Debe seleccionar una imagen");
            }

            /*
            if (string.IsNullOrWhiteSpace(TBPrecio.Text.Trim()) || string.IsNullOrWhiteSpace(TBDescripcion.Text.Trim()) || string.IsNullOrWhiteSpace(TBNombreInstructor.Text.Trim()))
            {
                LPlanRequerido.Visible = false;

            }
            else
            {
                isValid = false;
                LPlanRequerido.Visible = true;
            }
            */

            return isValid;
        }
        private void CargarElementosComboBox()
        {
            try
            {
                if (AppState.ClientActive != null)
                {

                    CBPlanes.Items.Clear();

                    var trainingPlan = EditClientPresenter.PlanDelCliente();

                    LidPlan.Text = trainingPlan.IdTrainingPlan.ToString();
                    TBPrecio.Text = trainingPlan.Price.ToString();
                    TBDescripcion.Text = trainingPlan.Description;
                    TBNombreInstructor.Text = trainingPlan.IdInstructorNavigation.IdPersonNavigation.FirstName + " " + trainingPlan.IdInstructorNavigation.IdPersonNavigation.LastName;

                    CBPlanes.Items.Add(trainingPlan.Description);

                    //Ahora se cargan los demas elementos

                    var trainingPlans = EditClientPresenter.PlanesQueNoSonDelCliente(); 

                    foreach (TrainingPlan plan in trainingPlans)
                    {
                        if (!plan.Inactive)
                        {
                            CBPlanes.Items.Add(plan.IdTrainingPlan + "-" + plan.Description);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void TBPrecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Se cancela el evento KeyPress para que no se escriba nada en el textbox
            e.Handled = true;
        }

        private void TBDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se cancela el evento KeyPress para que no se escriba nada en el textbox
            e.Handled = true;
        }

        private void TBNombreInstructor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se cancela el evento KeyPress para que no se escriba nada en el textbox
            e.Handled = true;
        }

        private void BGuardarCliente_Click_1(object sender, EventArgs e)
        {
            try
            { //Se verifica que se hayan ingresado todos los datos
                bool isValidTextBoxes = isValidTextsBoxesMostrarError();
                if (isValidTextBoxes)
                {
                    this.actualizarCliente();
                    this.restablecerTextBoxes();
                    AppState.needRefreshClientsUserControl = true;
                    MainView.navigationControl.Display(1, true);

                }

            }
            catch (Exception ex)
            {
                // Accede a la InnerException para obtener más detalles sobre el error
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                    Console.WriteLine("Inner Exception Stack Trace: " + ex.InnerException.StackTrace);
                    // O cualquier otra acción que desees tomar para manejar el error
                }
                else
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    // O cualquier otra acción que desees tomar para manejar el error
                }
            }
        }

        private void actualizarCliente()
        {
            try
            {

                string usuario = TBUsuario.Text;

                int idPlan = int.Parse(LidPlan.Text);
                string sexo = "";

                if (RBMasculino.Checked)
                {
                    sexo = "M";
                }
                else
                {
                    sexo = "F";
                }
           

                EditClientPresenter.ActualizarCliente(usuario, TBNombre.Text, TBApellido.Text, TBRutaImagen.Text, TBContraseña.Text,
                     TBTelefono.Text, sexo, DPFechaNacimiento.Value, DPVencimiento.Value, idPlan);


                MessageBox.Show("Se Editaron correcctamente los datos");
            }
            catch (Exception ex)
            {
                // Accede a la InnerException para obtener más detalles sobre el error
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                    Console.WriteLine("Inner Exception Stack Trace: " + ex.InnerException.StackTrace);
                    // O cualquier otra acción que desees tomar para manejar el error
                }
                else
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    // O cualquier otra acción que desees tomar para manejar el error
                }
            }

        }
       
        private void CBPlanes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtén la descripción seleccionada del ComboBox
            string selectedDescription = CBPlanes.SelectedItem.ToString();

            // Divide la descripción en ID y descripción por medio del -
            string[] parts = selectedDescription.Split('-');

            if (parts.Length == 2)
            {
                // Obtén el ID y realiza las consultas en la base de datos
                int selectedPlanId = int.Parse(parts[0]);
                string selectedPlanDescription = parts[1];

                var trainingPlan = EditClientPresenter.BuscarPlan(selectedPlanId);

                LidPlan.Text = trainingPlan.IdTrainingPlan.ToString();
                TBPrecio.Text = trainingPlan.Price.ToString();
                TBDescripcion.Text = trainingPlan.Description;
                TBNombreInstructor.Text = trainingPlan.IdInstructorNavigation.IdPersonNavigation.FirstName + " " + trainingPlan.IdInstructorNavigation.IdPersonNavigation.LastName;


            }
        }

        private void restablecerTextBoxes()
        {
            TBNombre.Text = "";
            TBApellido.Text = "";
            TBTelefono.Text = "";
            TBUsuario.Text = "";
            TBContraseña.Text = "";
            TBRutaImagen.Text = "";
            RBMasculino.Checked = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            MainView.navigationControl.Display(1, true);
        }
    }



}
