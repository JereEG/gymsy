using gymsy.App.Models;
using gymsy.App.Presenters;
using gymsy.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymsy.UserControls.ClientControls
{
    public partial class AboutClientControl : UserControl
    {

        Person person;

        private ClientPresenter presenter;
        public AboutClientControl()
        {
            presenter = new ClientPresenter();
            this.person = AppState.person;
            InitializeComponent();
            InitializeDataClient();
        }

        private void InitializeDataClient()
        {

            //this.dbContext.TrainingPlans.ToList();
            
            var client = presenter.getClient(this.person.IdPerson);
            LbName.Text = $"{this.person.LastName}, {this.person.FirstName}";


            LbIngreso.Text = this.person.CreatedAt.ToString("dd/MM/yyyy");
            BeforeIngreso.Text = this.person.CreatedAt.ToString("dd/MM/yyyy");

            LbCuotaExp.Text = client.LastExpiration.ToString("dd/MM/yyyy");
            LbPlanActual.Text = client.IdTrainingPlanNavigation.Description;
            LbTimeActivo.Text = $"Hace {(this.person.CreatedAt - DateTime.Now).Days * -1} dias";
            LbRegistros.Text = $"{client.DataFisics.Count()} registros";


            if (client.DataFisics.Count() > 0)
            {
                BeforeAltura.Text = $"{client.DataFisics.First().Height}cm";
                LbAltura.Text = $"{client.DataFisics.Last().Height}cm";

                BeforePeso.Text = $"{client.DataFisics.First().Weight}kg";
                BeforePeso.Text = $"{client.DataFisics.Last().Weight}kg";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
