using gymsy.App.Models;
using gymsy.Context;
using gymsy.Utilities;
using gymsy.UserControls.AdminControls;
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
using gymsy.App.Views.UserControls.AdminControls;
using gymsy.App.Presenters;

namespace gymsy.UserControls.AdminControls
{
    public partial class AddInstructorControl : UserControl
    {
        private bool isEditMode = false; // Variable para saber si se esta editando o agregando 

        private AdminPresenter presenter;
        public AddInstructorControl()
        {

            InitializeComponent();
            presenter = new AdminPresenter();
        }

        private void BGuardarCliente_Click(object sender, EventArgs e)
        {

            string nombre = TBNombre.Text;
            string apellido = TBApellido.Text;
            string telefono = TBTelefono.Text;
            string usuario = TBUsuario.Text;
            string contraseña = Bcrypt.HashPassoword(TBContraseña.Text);
            string nameImagen = SaveImage(TBRutaImagen.Text);
            DateTime birthday = DPFechaNacimiento.Value;
            string sexo = "";

            if (RBMasculino.Checked)
            {
                sexo = "M";
            }
            else
            {
                sexo = "F";
            }

            try
            { //Se verifica que se hayan ingresado todos los datos
                bool isValidTextBoxes = isValidTextsBoxesMostrarError();
                if (isValidTextBoxes)
                {
                    presenter.GuardarCliente(nombre,apellido,telefono,usuario,contraseña,nameImagen,sexo,birthday);
                    
                    AppState.needRefreshClientsUserControl = true;
                    MessageBox.Show("Se Guardaron correcctamente los datos");
                    this.restablecerTextBoxes();


                    MessageBox.Show("Se Guardaron correcctamente los datos");

                }
                else
                {
                    MessageBox.Show("Revise y complete correctamente los campos.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de la excepción: {ex.Message}\n\n" +
                                $"Stack Trace: {ex.StackTrace}\n\n" +
                                $"Excepción interna: {ex.InnerException}\n\n" +
                                $"Data: {ex.Data}\n\n" +
                                $"Origen: {ex.Source}\n\n" +
                                $"Tipo de excepción: {ex.GetType().ToString()}");
                throw;
            }
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

        private string SaveImage(string imagePath)
        {
            try
            {

                //Ruta completa para guardar la imagen en la carpeta
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
            IPImagenInstructor.Image = gymsy.Properties.Resources.instructor;
        }
        private bool IsNicknameUnique(string nickname)
        {
           return  presenter.NicknameUnique(nickname);

        }
        public override void Refresh()
        {
            BBack.Visible = AppState.isModeAdd;
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            MainView.navigationControl.Display(1, true);
            AppState.isModeAdd = false;
        }
    }
}
