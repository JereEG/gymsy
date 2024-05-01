using gymsy.App.Models;
using gymsy.Context;
using gymsy.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using gymsy.App.Models;
using gymsy.App.Presenters;

namespace gymsy.UserControls.AdminControls
{
    public partial class EditInstructor : UserControl
    {
        private bool isEditMode = false; // Variable para saber si se esta editando o agregando 

        private AdminPresenter presenter;
        public EditInstructor()
        {
            InitializeComponent();
            presenter = new AdminPresenter();
        }
        public override void Refresh()
        {
            //Se carga el cliente
            this.CargarInstructor();

            //BBack.Visible = AppState.isModeAdd;

        }

        private void CargarInstructor()
        {
            if (AppState.InstructorActive != null && AppState.InstructorActive.IdPersonNavigation != null)
            {
                string name = AppState.InstructorActive.IdPersonNavigation.FirstName.ToString();
                string lastName = AppState.InstructorActive.IdPersonNavigation.LastName.ToString();
                string numberPhone = AppState.InstructorActive.IdPersonNavigation.NumberPhone.ToString();
                string nickname = AppState.InstructorActive.IdPersonNavigation.Nickname.ToString();

                TBNombre.Text = name;
                TBApellido.Text = lastName;
                TBTelefono.Text = numberPhone;
                TBUsuario.Text = nickname;
                TBContraseña.Text = AppState.InstructorActive.IdPersonNavigation.Password.ToString();
                //Que hacer con la contraseña?
                //TBContraseña.Text = AppState.InstructorActive.IdPersonNavigation.;

                if (AppState.InstructorActive.IdPersonNavigation.Gender.ToString() == "M" || AppState.InstructorActive.IdPersonNavigation.Gender.ToString() == "m")
                {
                    RBMasculino.Checked = true;
                }
                else
                {
                    RBFemenino.Checked = true;
                }

                DPFechaNacimiento.Value = AppState.InstructorActive.IdPersonNavigation.Birthday;

                try
                {
                    string ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor + "\\" + AppState.InstructorActive.IdPersonNavigation.Avatar;
                    TBRutaImagen.Text = ruta;

                    IPImagenInstructor.Image = System.Drawing.Image.FromFile(ruta);
                }
                catch
                {
                    IPImagenInstructor.Image = gymsy.Properties.Resources.instructor;
                }

            }

        }

        private void BGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            { //Se verifica que se hayan ingresado todos los datos
                bool isValidTextBoxes = isValidTextsBoxesMostrarError();
                if (isValidTextBoxes)
                {
                    this.actualizarInstructor();
                    this.restablecerTextBoxes();
                    AppState.needRefreshClientsUserControl = true;
                    MainView.navigationControl.Display(1, true);

                    MessageBox.Show("Se Guardaron correcctamente los datos");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Exepcion inesperada!");
                throw;
            }
        }
        private void actualizarInstructor()
        {
            
                presenter.personUpdated(TBNombre.Text, TBApellido.Text, TBTelefono.Text, TBUsuario.Text, TBContraseña.Text,TBRutaImagen.Text,RBMasculino.Checked, DPFechaNacimiento.Value);
    

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
                        IPImagenInstructor.Image = System.Drawing.Image.FromFile(rutaImagen);
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
            if (!string.IsNullOrWhiteSpace(TBUsuario.Text) && this.IsNicknameUnique(TBUsuario.Text) && TBUsuario.PlaceholderText != TBUsuario.Text)
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


            return isValid;
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
                MessageBox.Show(e.Message);
                return "";
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
        private bool IsNicknameUnique(string nickname)
        {
            if (!AppState.isModeEdit)
            {
                try
                {
                    // Consulta la base de datos para verificar si ya existe un registro con el mismo 'nickname'

                    
                    var existingPerson = presenter.NicknameUnique(nickname);
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
            else
            {
                return true;
            }
        }


        private void BBack_Click(object sender, EventArgs e)
        {
            AppState.isModeEdit = false;
            AppState.isModeAdd = false;
            MainView.navigationControl.Display(1, true);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TBRutaImagen_TextChanged(object sender, EventArgs e)
        {
        }

        private void LRuraImagen_Click(object sender, EventArgs e)
        {
        }
    }
}
