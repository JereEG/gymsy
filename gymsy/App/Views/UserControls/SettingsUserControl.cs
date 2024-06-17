using gymsy.Models;
using gymsy.App.Views.Interfaces;
using gymsy.Context;
using gymsy.Properties;
using gymsy.utilities;
using gymsy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;
using gymsy.Modelos;

namespace gymsy.UserControls
{
    public partial class SettingsUserControl : UserControl, ISettingView
    {
        Usuario person;
        NuevoGymsyContext dbContext;
        public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SettingsUserControl()
        {
            this.person = AppState.person;
            this.dbContext = ViejoGymsyContext.GymsyContextDB;

            InitializeComponent();
            InitializeDataComponent();
        }

        private void InitializeDataComponent()
        {
            TbFirstName.Text = person.Nombre;
            TbLastName.Text = person.Apellido;
           // TbCBU.Text = person.CBU;
            TbPhone.Text = person.NumeroTelefono;
            try
            {
                string ruta = "";
                if (person.IdRol == 2)
                {
                    ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor;
                }
                else if (person.IdRol == 3)
                {
                    ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageClient;
                }
                else
                {
                    ruta = AppState.pathDestinationFolder;
                }
                ruta += "\\" + person.AvatarUrl;
                gorilla_avatar.BackgroundImage = System.Drawing.Image.FromFile(ruta);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                gorilla_avatar.BackgroundImage = Resources.gorilla_avatar;
            }
        }

        Usuario ISettingView.person
        {
            get { return person; }
            set { person = value; }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {

            panelError.Visible = false;

            // Validate textbox is not null
            List<TextBox> textBoxList = new List<TextBox>()
            {
                TbFirstName, TbLastName, /*TbCBU,*/ TbPhone
            };
            if (!this.ValidateTextBox(textBoxList)) return;

            // Update global state
            this.person.Nombre = TbFirstName.Text;
            this.person.Apellido = TbLastName.Text;
            //this.person.CBU = TbCBU.Text;
            this.person.NumeroTelefono = TbPhone.Text;
            if (this.person.AvatarUrl != TBRutaImagen.Text)
            {
                this.person.AvatarUrl = SaveImage(TBRutaImagen.Text);
            }


            try
            {

                DialogResult confirmAction = MessageBox.Show("Estas seguro de actualizar cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's choice
                if (confirmAction == DialogResult.Yes)
                {
                    updatedDbDataUser();
                    //PimagenPerson
                    gorilla_avatar.Image = System.Drawing.Image.FromFile(TBRutaImagen.Text);
                }

            }
            catch (Exception ex)
            {
                panelError.Visible = true;

            }


        }
        private string SaveImage(string imagePath)
        {
            try
            {

                //Ruta completa para guardar la imagen en la carpeta
                //string pathDestinationFolder = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor;

                string pathDestinationFolder = "";
                if (person.IdRol == 2)
                {
                    pathDestinationFolder = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor;
                }
                else if (person.IdRol == 3)
                {
                    pathDestinationFolder = AppState.pathDestinationFolder + AppState.nameCarpetImageClient;
                }
                else
                {
                    pathDestinationFolder = AppState.pathDestinationFolder;
                }



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
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            panelError.Visible = false;

            List<TextBox> textBoxList = new List<TextBox>()
            {
                tbCurrentPassword, tbNewPassword
            };

            // Validate textbox password is not null
            if (!ValidateTextBox(textBoxList)) return;

            try
            {

                DialogResult confirmAction = MessageBox.Show("Estas seguro de actualizar cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's choice
                if (confirmAction == DialogResult.Yes)
                {
                    updateDbPasswordUser();
                }

            }
            catch (Exception ex)
            {
                panelError.Visible = true;
            }
        }

        // Change avatar user
        private void BtnEditAvatar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxAvatar.Text);
        }

        // Validate text box not null
        private bool ValidateTextBox(List<TextBox> textBoxList)
        {
            foreach (TextBox textBoxCurrent in textBoxList)
            {
                if (!Utility.IsValidTextBox(textBoxCurrent, panelError))
                {
                    return false;
                }
            }
            return true;
        }

        // Close panel error
        private void PanelErrorBtnClose_Click(object sender, EventArgs e)
        {
            panelError.Visible = false;
        }

        private void updatedDbDataUser()
        {
            try
            {
                var personUpdated = this.dbContext.Usuarios
                                .Where(people => people.IdUsuario == this.person.IdUsuario)
                                .First();
                personUpdated = this.person;
                this.dbContext.SaveChanges();

                MessageBox.Show("Actualizo Correctamente");
            }
            catch (Exception ex)
            {
                panelError.Visible = true;
                panelErrorText.Text = ex.Message;
            }

        }

        private void updateDbPasswordUser()
        {
            try
            {
                var personUpdated = this.dbContext.Usuarios
                               .Where(people => people.IdUsuario == this.person.IdUsuario)
                               .First();

                if (personUpdated != null)
                {
                    if (Bcrypt.ComparePassowrd(tbCurrentPassword.Text, personUpdated.Contrasena))
                    {
                        string encryptNewPass = Bcrypt.HashPassoword(tbNewPassword.Text);
                        personUpdated.Contrasena = encryptNewPass;

                        this.dbContext.SaveChanges();

                        MessageBox.Show("Actualizo Correctamente tu Clave :)");
                    }
                    else
                    {
                        LbErrorChangePass.Text = "Contraseña Incorrecta :(";
                        LbErrorChangePass.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                panelError.Visible = true;
                panelErrorText.Text = ex.Message;
            }

        }

        private void comboBoxAvatar_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        gorilla_avatar.Image = System.Drawing.Image.FromFile(rutaImagen);
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

        private void back_Click(object sender, EventArgs e)
        {
            MainView.navigationControl.Display(0);
        }
    }
}
