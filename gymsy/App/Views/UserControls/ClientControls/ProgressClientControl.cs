using gymsy.Modelos;
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

        public void updateProgressActive(EstadoFisico DataFisicActive)
        {
            TBRegDescription.Text = DataFisicActive.Notas;
            TBRegFecha.Text = "Datos " + DataFisicActive.FechaCreacion.ToString("dd/MM/yyyy");
            if (DataFisicActive.ImagenUrl != null)
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string rutaImagen = Path.GetFullPath(Path.Combine(directory, @"..\..\..\App\Public\" + DataFisicActive.ImagenUrl.First()));
                System.Drawing.Image imagen = System.Drawing.Image.FromFile(rutaImagen);

                PhotoActive.Image = imagen;
            }
            else
            {
                PhotoActive.Image = PhotoActive.InitialImage;
            }

            if (DataFisicActive.EstadoFisicoInactivo)
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
                Usuario clienteBuscado = ClientePresenter.BuscarCliente(AppState.auxIdClient);
                List<EstadoFisico> Estado = AddProgressClientPresenter.getProgress(AppState.auxIdClient);
                int edad = DateTime.Now.Year - clienteBuscado.FechaCreacion.Year;
                //TimeSpan TimeTraning = clienteBuscado.IdPersonNavigation.CreatedAt - DateTime.Now;

                TBDescripcionClient.Text = $"{clienteBuscado.Nombre + " " + clienteBuscado.Apellido}, " +
                $"{edad} años comenzo a enrenarse, " +
                $"cuenta con {clienteBuscado.PlanEntrenamientos.Count()} registros guardados";


                if (clienteBuscado.PlanEntrenamientos.Count() > 0)
                {
                    PanelMessageCount.Visible = false;

                    foreach (var DataFisic in Estado)
                    {
                        TimeSpan diferencia = DateTime.Now - DataFisic.FechaCreacion;
                        String formart = $"Hace {diferencia.Days} dias";
                        dataGridProgress.Rows.Add(DataFisic.IdEstadoFisico, formart, null, $"{DataFisic.Peso} KG", DataFisic.Titulo);
                    }

                    updateProgressActive(Estado.First());
                }
                else
                {
                    PanelMessageCount.Visible = true;
                }

            } else
            {
                int edad = DateTime.Now.Year - AppState.ClientActive.FechaNacimiento.Year;
               // int edad = 18;
                TimeSpan TimeTraning = AppState.ClientActive.FechaCreacion - DateTime.Now;
                List<EstadoFisico> Estado = AddProgressClientPresenter.getProgress
                 (AppState.ClientActive.IdUsuario);
                TBDescripcionClient.Text = $"{AppState.ClientActive.Nombre + " " + AppState.ClientActive.Apellido}, " +
                $"{edad} años comenzo a enrenarse hace {TimeTraning.Days * -1} días, "
                + $"cuenta con {Estado.Count()} registros guardados";

                if (Estado.Count() > 0)
                {
                    PanelMessageCount.Visible = false;

                    foreach (var DataFisic in Estado)
                    {
                        TimeSpan diferencia = DateTime.Now - DataFisic.FechaCreacion;
                        String formart = $"Hace {diferencia.Days} dias";
                        dataGridProgress.Rows.Add(DataFisic.IdEstadoFisico, formart, null, $"{DataFisic.Peso} KG", DataFisic.Titulo);
                    }

                    updateProgressActive(Estado.First());
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

                var ListDataFisics =AddProgressClientPresenter.getProgress(AppState.ClientActive.IdUsuario);

                EstadoFisico DataFisicSelected = ListDataFisics.Find(df => IdDfSelected.Equals(df.IdEstadoFisico));

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
