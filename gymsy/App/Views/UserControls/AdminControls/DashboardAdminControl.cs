using gymsy.App.Models;
using gymsy.App.Presenters;
using gymsy.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gymsy.UserControls.AdminControls
{
    public partial class DashboardAdminControl : UserControl
    {

        private GymsyDbContext dbContext;
        private AdminPresenter presenter;
        public DashboardAdminControl()
        {
            presenter= new AdminPresenter();
            InitializeComponent();
            InitilizeChar();
            InitilizeCharPie();
            InitializeDataGridPays();
        }

        private void InitializeDataGridPays()
        {

            DataGridViewRow row = this.DataGridPays.RowTemplate;
            row.Height = 35;
            row.MinimumHeight = 20;

            DataGridPays= presenter.DatagridPay(DataGridPays);

        }

        public void InitilizeChar()
        {
            Series series = ChartAdmin.Series.FindByName("Ganancia");

            if (series != null)
            {
                // Limpia la serie (elimina todos los puntos de datos actuales)
                series.Points.Clear();
                series.LegendText = "Ganacia por Mes";
                series.BorderColor = Color.DarkOrange;
                series.BorderWidth = 3;
                series.BackSecondaryColor = Color.White;
                series.BorderDashStyle = ChartDashStyle.Solid; // punteado o solido ...
                series.Color = Color.Transparent;

                List<string> listMonths = new List<string>
                {
                    "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nob", "Dec"
                };


                // Crear un arreglo con todos los meses del año y establecer el monto en 0 para aquellos meses sin pagos
                //                var mesesCompletos = presenter.mes();

                // Trabaja con 'resultado' según sea necesario
                series = presenter.mes(listMonths, series);
            }
        }

        public void InitilizeCharPie()
        {
            Series series = chartInstructorXClientes.Series.FindByName("Series1");

            if (series != null)
            {
                // Limpia la serie (elimina todos los puntos de datos actuales)
                series.Points.Clear();
                series.LabelForeColor = Color.White;
                series.LabelBackColor = Color.Transparent;
                series.BorderColor = Color.White;
                series.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                series.MarkerStyle = MarkerStyle.Cross;
                series = presenter.InstructorCant(series);


                // Agrega los nuevos datos a la serie
            
            }

        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {

                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                chartInstructorXClientes.SaveImage(Path.Combine(downloadsFolder, "grafico_torta_admin.png"), ChartImageFormat.Png); ;
                ChartAdmin.SaveImage(Path.Combine(downloadsFolder, "grafico_fun_admin.png"), ChartImageFormat.Png);

                // Crear el contenido HTML
                string htmlContent = $@"
                <html>
                <head>
                    <title>Gráfico GYMSY</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            height: 95vh;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            background-image: linear-gradient(to right, #6a11cb 0%, #2575fc 100%);
                        }}

                        h3{{    
                            text-align: center:
                            color: white;
                        }}

                        .graficos {{
                            width: 80%;
                            margin: 0 auto;
                            padding: 30px;
                            border-radius: 5px;
                            background-color: rgb(255, 255, 255, .15);
                            box-shadow: 2px 1px 34px 2px rgba(255,255,255,0.5);
                            display: grid;
                            grid-template-columns: repeat(2, 1fr);
                            grid-template-rows: auto;
                            grid-gap: 20px;
        
                        }}
                        
                        .graficoFun{{
                            grid-column: 1 / 3;

                        }}

                        .ImgGraficoFun{{
                            width: 100%;
                            max-height: 400px;
                            object-fit: contain;
                        }}

                        .graficoTorta{{
                            border: 1px solid #ccc;
                            padding: 15px;
                        }}

                        .listClients{{
                            border: 1px solid #ccc;
                            padding: 15px;
                        }}
                    </style>
                </head>
                <body>
                    
                    
                    <div class='graficos'>
                       
                         <div class='graficoFun'>
                            <h2 style='color:white; text-align:center'>Cantidad de clientes por mes</h2>
                            <img class='ImgGraficoFun' src='grafico_fun_admin.png' alt='Gráfico'>
                        </div>

                         <div  class='graficoTorta'>
                            <h2 style='color:white; text-align:center'>Clientes por Instructor</h2>
                            <img src='grafico_torta_admin.png' alt='Gráfico'>
                        </div>

                        <div class='listClients'>
                            <h2 style='color:white; text-align:center'>Grafico ...</h2>
                            <-
                        </div>
                    </div>
                   
                </body>
                </html>";

                string htmlFilePath = Path.Combine(downloadsFolder, "grafico.html");

                // Guardar el contenido HTML en un archivo
                System.IO.File.WriteAllText(htmlFilePath, htmlContent);

                MessageBox.Show("Se ha generado un HTML en Documentos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

