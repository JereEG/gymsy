using gymsy.Models;
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

namespace gymsy.UserControls
{
    public partial class PaymentsUserControl : UserControl
    {
        private IEnumerable<Pago> PaysList;
       // private GymsyDbContext dbContext;

        public PaymentsUserControl()
        {
            //this.dbContext = GymsyContext.GymsyContextDB;
            InitializeComponent();
            InitializeGridProgress();
        }

        private void InitializeGridProgress()
        {
            if (AppState.person != null)
            {
                this.PaysList = AppState.person.PayDestinatarios.ToArray()
                   .Concat(AppState.person.PayRemitentes.ToArray());
            }

            if (this.PaysList.Count() > 0)
            {
                PanelMsg.Visible = false;
                foreach (Pago pay in this.PaysList)
                {
                    TimeSpan diferencia = (DateTime.Now - pay.FechaCreacion);
                    String formart = $"Hace {diferencia.Days} dias";
                    String descripcion = pay.DestinatarioId == AppState.person.IdUsuario ? $"Recibiste" : $"Pagaste";
                    dataGridPayments.Rows.Add(pay.IdPago, formart, pay.IdTipoPagoNavigation.Nombre, pay.Monto, descripcion);
                }
            }

        }

        private void dataGridPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {

                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;


                int IdPaySelected = int.Parse(dataGridPayments.Rows[rowIndex].Cells["ID"].Value.ToString());

                var PaySelected = PaymentsPresenter.BuscarPago(IdPaySelected);

                // Navigate to training history
                if (PaySelected != null)
                {
                    string rutaArchivo = utilities.GenarateComprobante.GeneratePdfComprobante(PaySelected);
                    MessageBox.Show("Archivo HTML generado exitosamente en: " + rutaArchivo);
                }
            }
        }
    }
}