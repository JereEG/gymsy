using gymsy.App.Models;
using gymsy.App.Presenters;
using gymsy.Context;
using gymsy.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace gymsy.App.Views.UserControls.AdminControls
{
    public partial class adminControl : UserControl
    {

        private AdminPresenter presenter;
        public adminControl()
        {
            presenter = new AdminPresenter();
            InitializeComponent();
        }

        private void BAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta=presenter.backup();
                
                MessageBox.Show($"Copia de seguridad creada exitosamente.\nLo puede encontrar en {ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la copia de seguridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void RealizarRestauracion(string backupPath)
        {
            

            try
            {
                presenter.restore(backupPath);
                

                MessageBox.Show("Restauración completada con éxito.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al restaurar la base de datos: " + ex.Message);
            }
        }

        private void BBuscarArchivo_Click_1(object sender, EventArgs e)
        {
            TBRutaArchivo.Text= presenter.buscar();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TBRutaArchivo.Text))
            {
                MessageBox.Show("Por favor, cargue la ruta del archivo.");
            }
            else
            {
                this.RealizarRestauracion(TBRutaArchivo.Text);
            }
        }
    }
}
