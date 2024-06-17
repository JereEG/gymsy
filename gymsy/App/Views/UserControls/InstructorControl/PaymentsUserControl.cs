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

                this.PaysList = ControlPagosAlumnoPresenter.listarTodasTransferencias(AppState.person.IdUsuario);
            }

            if (this.PaysList.Count() > 0)
            {
                PanelMsg.Visible = false;
                foreach (Pago pay in this.PaysList)
                {
                    TimeSpan diferencia = DateTime.Now - pay.FechaCreacion;
                    string formart = $"Hace {diferencia.Days} días";

                    // Determinar si el pago fue recibido o realizado
                    //string descripcion = pay.CbuDestino == AppState.person.Cbu ? "Recibiste" : "Pagaste";
                    string descripcion = "Pendiente!";
                    // Añadir la fila al DataGridView
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