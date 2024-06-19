using CustomControls.RJControls;
using gymsy.Modelos;
using gymsy.Context;
using gymsy.utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using gymsy.App.Presenters;


namespace gymsy.App.Views.UserControls.ClientControls
{
    public partial class AddProgressClientControl : UserControl
    {

        //private GymsyDbContext gymsydb = GymsyContext.GymsyContextDB;
        private OpenFileDialog fileDialog = new OpenFileDialog();

        public AddProgressClientControl()
        {
            InitializeComponent();
        }

        private void JustNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.TextBoxOnlyNumbersWithDecimal(sender, e);
        }

        private void ClearTextBox()
        {
            TbAltura.Text = "";
            TbPeso.Text = "";
            TbTitle.Text = "";
            TbNotes.Text = "";
            this.fileDialog = new OpenFileDialog();
            PictureBoxImg.Image = PictureBoxImg.InitialImage;
        }

        private void BtnAddImgProgress_Click(object sender, EventArgs e)
        {
            System.Drawing.Image File;

            fileDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png; *.jfif";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File = System.Drawing.Image.FromFile(fileDialog.FileName);
                PictureBoxImg.Image = File;
            }
        }


        private bool ValidateTextBox(List<RJTextBox> textBoxList)
        {
            foreach (RJTextBox textBoxCurrent in textBoxList)
            {
                if (!Utility.IsValidTextBoxRJ(textBoxCurrent, labelError))
                {
                    MessageBox.Show("Verifique que los campos esten correctos.");
                    return false;
                }
            }
            return true;
        }
        


        private void BtnSaveProgress_Click(object sender, EventArgs e)
        {
            

            string extension_imagen = System.IO.Path.GetExtension(fileDialog.FileName).ToLower();
          

            this.guardarProgreso(TbTitle.Text, TbNotes.Text, TbPeso.Text, TbAltura.Text, fileDialog.FileName,extension_imagen);         
        }
        private void guardarProgreso(string title_dataFisic,string notes_dataFisic,string weight_dataFisic,string height_dataFisic,string ruta_imagen,string extension_imagen)
        {
            try
            {

                labelError.Visible = false;

                List<RJTextBox> textBoxList = new List<RJTextBox>()
                {
                    TbTitle, TbAltura, TbPeso, TbNotes
                };

                // Validar texts box
                if (!ValidateTextBox(textBoxList)) return;


                // Verifica la extensión del archivo seleccionado
                
                if (AddProgressClientPresenter.TituloUnico(TbTitle.Text))
                {
                    if (!(extension_imagen == ".jpg" || extension_imagen == ".jpeg" || extension_imagen == ".png" || extension_imagen == ".jfif"))
                    {
                        MessageBox.Show("Agrega una imagen al registro!");
                        return;
                    }

                    float weight = float.Parse(weight_dataFisic);
                     float height = float.Parse(height_dataFisic);
                    if (AddProgressClientPresenter.guardarProgreso(title_dataFisic, notes_dataFisic, weight, height, ruta_imagen, extension_imagen))
                    {
                        MessageBox.Show("Se agrego Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("A ocurrido un Error inesperado!");
                    }


                    this.ClearTextBox();
                    MainView.navigationControl.Display(7, true);
                }
                else
                {
                    MessageBox.Show("Ya existe un progreso con ese titulo.");
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
    }
}
