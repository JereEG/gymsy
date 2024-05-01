using gymsy.App.Models;
using gymsy.App.Presenters;
using gymsy.App.Views.Interfaces;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymsy.UserControls.ClientControls
{
    public partial class ProgressClientControl : UserControl
    {

       
  
        public ProgressClientControl()
        {
            InitializeComponent();
            /*
            if (AppState.person.RolId == 3)
            {
                btnAddProgress.Visible = false;
                rjButton1.Visible = false;
            }
             */

            PhotoActive.InitialImage = PhotoActive.Image;
        }

        public void updateProgressActive(DataFisic DataFisicActive)
        {
            TBRegDescription.Text = DataFisicActive.Notes;
            TBRegFecha.Text = "Datos " + DataFisicActive.CreatedAt.ToString("dd/MM/yyyy");
            if (DataFisicActive.Images.Count > 0)
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string rutaImagen = Path.GetFullPath(Path.Combine(directory, @"..\..\..\App\Public\" + DataFisicActive.Images.First().ImageUrl));
                System.Drawing.Image imagen = System.Drawing.Image.FromFile(rutaImagen);

                PhotoActive.Image = imagen;
            }
            else
            {
                PhotoActive.Image = PhotoActive.InitialImage;
            }

            if (DataFisicActive.Inactive)
            {
                BtnInactiveReg.BackColor = Color.Green;
            }
            else
            {
                BtnInactiveReg.BackColor = Color.Crimson;
            }
        }

        public void UpdateComponent()
        {
            if(AppState.auxIdClient > 0)
            {
                Client clienteBuscado = ClientePresenter.BuscarCliente(AppState.auxIdClient);

                int edad = DateTime.Now.Year - clienteBuscado.IdPersonNavigation.Birthday.Year;
                TimeSpan TimeTraning = clienteBuscado.IdPersonNavigation.CreatedAt - DateTime.Now;

                TBDescripcionClient.Text = $"{clienteBuscado.IdPersonNavigation.FirstName + " " + clienteBuscado.IdPersonNavigation.LastName}, " +
                $"{edad} años comenzo a enrenarse hace {TimeTraning.Days * -1} días, " +
                $"cuenta con {clienteBuscado.DataFisics.Count()} registros guardados";


                if (clienteBuscado.DataFisics.Count() > 0)
                {
                    PanelMessageCount.Visible = false;

                    foreach (var DataFisic in clienteBuscado.DataFisics)
                    {
                        TimeSpan diferencia = DateTime.Now - DataFisic.CreatedAt;
                        String formart = $"Hace {diferencia.Days} dias";
                        dataGridProgress.Rows.Add(DataFisic.IdDataFisic, formart, null, $"{DataFisic.Weight} KG", DataFisic.Title);
                    }

                    updateProgressActive(clienteBuscado.DataFisics.First());
                }
                else
                {
                    PanelMessageCount.Visible = true;
                }

            } else
            {
                int edad = DateTime.Now.Year - AppState.ClientActive.IdPersonNavigation.Birthday.Year;
                TimeSpan TimeTraning = AppState.ClientActive.IdPersonNavigation.CreatedAt - DateTime.Now;

                TBDescripcionClient.Text = $"{AppState.ClientActive.IdPersonNavigation.FirstName + " " + AppState.ClientActive.IdPersonNavigation.LastName}, " +
                $"{edad} años comenzo a enrenarse hace {TimeTraning.Days * -1} días, " +
                $"cuenta con {AppState.ClientActive.DataFisics.Count()} registros guardados";


                if (AppState.ClientActive.DataFisics.Count() > 0)
                {
                    PanelMessageCount.Visible = false;

                    foreach (var DataFisic in AppState.ClientActive.DataFisics)
                    {
                        TimeSpan diferencia = DateTime.Now - DataFisic.CreatedAt;
                        String formart = $"Hace {diferencia.Days} dias";
                        dataGridProgress.Rows.Add(DataFisic.IdDataFisic, formart, null, $"{DataFisic.Weight} KG", DataFisic.Title);
                    }

                    updateProgressActive(AppState.ClientActive.DataFisics.First());
                }
                else
                {
                    PanelMessageCount.Visible = true;
                }
            }
            

        }

        public override void Refresh()
        {
            if (AppState.ClientActive != null)
            {
                dataGridProgress.Rows.Clear();
                this.UpdateComponent();
            }
        }

        private void btnAddProgress_Click(object sender, EventArgs e)
        {
            if(AppState.auxIdClient == 0)
            {
                MainView.navigationControl.Display(4);
                
            } else
            {
                MainView.navigationControl.Display(8);
            }
            
        }

        private void dataGridProgress_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                // Se ha hecho clic en una celda válida
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                object IdDfSelected = dataGridProgress.Rows[rowIndex].Cells[0].Value;

                var ListDataFisics = AppState.ClientActive.DataFisics.ToList();

                DataFisic DataFisicSelected = ListDataFisics.Find(df => IdDfSelected.Equals(df.IdDataFisic));

                if (DataFisicSelected != null)
                {
                    updateProgressActive(DataFisicSelected);
                }
            }
        }

        private void BtnInactiveReg_Click(object sender, EventArgs e)
        {
           // UPDATE
        }
    }
}
