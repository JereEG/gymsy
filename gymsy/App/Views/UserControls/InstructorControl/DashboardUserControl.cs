using gymsy.App.Models;
using gymsy.App.Presenters;
using gymsy.Context;
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
using System.Windows.Forms.DataVisualization.Charting;
using Twilio.TwiML.Voice;
using Twilio.Types;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace gymsy.UserControls
{
    public partial class DashboardUserControl : UserControl
    {

        private GymsyDbContext dbContext;

        public DashboardUserControl()
        {
            this.dbContext = GymsyContext.GymsyContextDB;
            InitializeComponent();
            InitializeData();
        }

        public void InitializeData()
        {
            InitializeGrid();
            InitilizeChar();
            InitializeChartTorta();
        }

        public void InitilizeChar()
        {
            // Busca la serie existente por su nombre
            Series series = chartInstructor.Series.FindByName("Ganancia");

            if (series != null)
            {
                // Limpia la serie (elimina todos los puntos de datos actuales)
                series.Points.Clear();
                series.LegendText = "Clientes por Mes";
                series.BorderColor = Color.DarkCyan;
                series.BorderWidth = 3;
                series.BackSecondaryColor = Color.White;
                series.BorderDashStyle = ChartDashStyle.Solid; // punteado o solido ...
                series.Color = Color.Transparent;

                List<string> listMonths = new List<string>
        {
            "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nob", "Dec"
        };

                // Llamar al método del Presenter para obtener los datos
                var pagosAgrupadosPorMes = DashboardInstructorPresenter.ObtenerPagosAgrupadosPorMes();

                foreach (var data in pagosAgrupadosPorMes)
                {
                    series.Points.AddXY(listMonths[data.Mes - 1], data.Cantidad);
                }
            }
        }

        public void InitializeGrid()
        {

            List<int> ListIdPlans = new List<int>();

            foreach (TrainingPlan plan in AppState.Instructor.TrainingPlans)
            {
                ListIdPlans.Add(plan.IdTrainingPlan);
            }

            var ClientsFound = DashboardInstructorPresenter.BuscarClientesActivosDelInstructor(ListIdPlans);


            if (ClientsFound.Count > 0)
            {
                PanelMsg.Visible = false;
                foreach (App.Models.Client cl in ClientsFound)
                {
                    dataGridView2.Rows.Add(cl.IdClient,
                                            $"{cl.IdPersonNavigation.LastName}, {cl.IdPersonNavigation.FirstName}",
                                            string.Format("{0:yyyy-MM-dd}", cl.LastExpiration),
                                            null);
                }
            }

        }


        public void InitializeChartTorta()
        {

            Series seriesTorta = ChartClientsxPlan.Series.FindByName("SerieTorta");

            if (seriesTorta != null)
            {



                // Limpia la serie (elimina todos los puntos de datos actuales)
                seriesTorta.Points.Clear();
                seriesTorta.LabelForeColor = Color.White;
                seriesTorta.LabelBackColor = Color.Transparent;
                seriesTorta.BorderColor = Color.White;
                seriesTorta.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                seriesTorta.MarkerStyle = MarkerStyle.Cross;

                foreach (TrainingPlan plan in AppState.Instructor.TrainingPlans)
                {
                    if (!plan.Inactive && plan.Clients.Count > 0)
                    {
                        seriesTorta.Points.AddXY("", plan.Clients.Count());
                        seriesTorta.LegendText = $"{plan.Description} - {plan.Clients.Count()} Clientes.";
                    }
                }

            }
        }


        public void InitializeChartTortaCuotas()
        {

            Series TortaCuota = ChartCuotasClientes.Series.FindByName("ChartCuotasClientes");

            TortaCuota.Points.Clear();

            int Expirados = DashboardInstructorPresenter.ContarExpiradosONoExp(true);
            int NoExpirados = DashboardInstructorPresenter.ContarExpiradosONoExp(false);

            TortaCuota.Points.AddXY($"Al dia {NoExpirados}", NoExpirados);
            TortaCuota.Points.AddXY($"Vencidos {Expirados}", Expirados);
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            InitializeChartTortaCuotas();
            ExportarGraficoAHTML();
        }

        private void ExportarGraficoAHTML()
        {
            try
            {

                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ChartClientsxPlan.SaveImage(Path.Combine(downloadsFolder, "grafico_torta.png"), ChartImageFormat.Png); ;
                chartInstructor.SaveImage(Path.Combine(downloadsFolder, "grafico_fun.png"), ChartImageFormat.Png);
                ChartCuotasClientes.SaveImage(Path.Combine(downloadsFolder, "grafico_cuotas.png"), ChartImageFormat.Png);



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
                            <img class='ImgGraficoFun' src='grafico_fun.png' alt='Gráfico'>
                        </div>

                         <div  class='graficoTorta'>
                            <h2 style='color:white; text-align:center'>Cantidad de clientes por planes</h2>
                            <img src='grafico.png' alt='Gráfico'>
                        </div>

                        <div class='listClients'>
                            <h2 style='color:white; text-align:center'>Activos/Vencimientos ultimos 7 dias</h2>
                            <img src='grafico_cuotas.png' alt='Gráfico'>
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