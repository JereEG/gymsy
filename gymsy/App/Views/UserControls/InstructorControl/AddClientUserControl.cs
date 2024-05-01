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
using System.Numerics;
using System.Reflection;
using gymsy.Utilities;
using gymsy.App.Presenters;

namespace gymsy.UserControls
{
    public partial class AddClientUserControl : UserControl
    {
        private bool isEditMode = false; // Variable para saber si se esta editando o agregando un nuevo cliente
        private int indexRowSelect = 0;
        //private GymsyDbContext dbContext;

        public AddClientUserControl()
        {
           //this.dbContext = GymsyContext.GymsyContextDB;

            InitializeComponent();

            // Inicializar el contexto de la base de datos
            //GymsyContext dbContext = new GymsyContext();

            //Carga el comboBox con los planes
            CargarElementosComboBox();

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
            if (!string.IsNullOrWhiteSpace(TBUsuario.Text) && TBUsuario.Text.Length < 7 && AddClientPresenter.IsNicknameUnique(TBUsuario.Text) && TBUsuario.PlaceholderText != TBUsuario.Text)
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


            if (!string.IsNullOrWhiteSpace(TBPrecio.Text) || !string.IsNullOrWhiteSpace(TBDescripcion.Text) || !string.IsNullOrWhiteSpace(TBNombreInstructor.Text))
            {
                LPlanRequerido.Visible = false;

            }
            else
            {
                isValid = false;
                LPlanRequerido.Visible = true;
            }


            return isValid;
        }
        private void CargarElementosComboBox()
        {
            try
            {
                //Ahora se cargan los demas elementos

                List<TrainingPlan> trainingPlans = AddClientPresenter.TraerPlanes();

                TrainingPlan trainingPlan = AddClientPresenter.TraerPrimerPlan();

                if (trainingPlan != null)
                {
                    if(trainingPlan != null)
                    {
                        LidPlan.Text = trainingPlan.IdTrainingPlan.ToString();
                        TBPrecio.Text = trainingPlan.Price.ToString();
                        TBDescripcion.Text = trainingPlan.Description;
                        TBNombreInstructor.Text = trainingPlan.IdInstructorNavigation.IdPersonNavigation.FirstName + " " + trainingPlan.IdInstructorNavigation.IdPersonNavigation.LastName;

                        CBPlanes.Items.Add(trainingPlan.Description);
                    }
                    
                }

                foreach (TrainingPlan plan in trainingPlans)
                {
                    if (!plan.Inactive && trainingPlan.IdTrainingPlan != plan.IdTrainingPlan)
                    {
                        CBPlanes.Items.Add(plan.IdTrainingPlan + "-" + plan.Description);
                    }

                }




            } catch (Exception e)
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
                   
         
        
                    AddClientPresenter.guardarCliente(usuario, TBNombre.Text, TBApellido.Text, TBRutaImagen.Text, Bcrypt.HashPassoword(TBContraseña.Text),
                    TBTelefono.Text, DPFechaNacimiento.Value, sexo, DPVencimiento.Value, idPlan);

                    AppState.needRefreshClientsUserControl = true;
                    MessageBox.Show("Se Guardaron correcctamente los datos");
                    this.restablecerTextBoxes();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exepcion inesperada!" + ex.Message);
                throw;
            }
        }


        /**
         * Guarda en Mis domumentos la imagen seleccionada
         */
        


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

                var trainingPlan = AddClientPresenter.BuscarPlan(selectedPlanId);

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

        // Función para verificar si el 'nickname' es único
        

        public override void Refresh()
        {
            //Carga el comboBox con los planes
            this.CargarElementosComboBox();
            BBack.Visible = AppState.isModeAdd;
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            MainView.navigationControl.Display(1, true);
            AppState.isModeAdd = false;
        }

    
    }



}
