using gymsy.App.Models;
using gymsy.Context;
using gymsy.Properties;
using gymsy.App.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymsy.App.Views.UserControls.receptionist
{
    public partial class addPay : UserControl
    {

        //private GymsyDbContext dbContext;
        private int indexRowSelect = 0;

        public addPay()
        {
            //Se trae el contexto de la base de datos
            //this.dbContext = GymsyContext.GymsyContextDB;

            InitializeComponent();


            this.cargarPersonas();

            //this.mostrar(false);

        }


        private void BBuscar_Click(object sender, EventArgs e)
        {
            // Obtén el texto actual del TextBox sin espacios al principio ni al final
            string textoBuscado = TBBusqueda.Text.Trim();



            // Comprueba si el TextBox está vacío
            if (!string.IsNullOrEmpty(textoBuscado))
            {
                LModoBusqueda.Visible = true;
                BCancelarBusqueda.Visible = true;

                // Limpia cualquier ordenación previa en el DataGridView
                DGUsers.Sort(DGUsers.Columns[0], ListSortDirection.Ascending);
                // Recorre todas las filas del DataGridView y oculta aquellas que no coincidan con el texto buscado
                foreach (DataGridViewRow row in DGUsers.Rows)
                {

                    bool coincide = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Contains(textoBuscado, StringComparison.OrdinalIgnoreCase))
                        {
                            coincide = true;
                            break;
                        }
                    }
                    // Ahora, verifica si la columna "delete" es false y this.isModoVerNoDelete es true antes de mostrar la fila
                    bool deleteValue = Convert.ToBoolean(row.Cells["delete"].Value);
                    
                    row.Visible = coincide;


                }
            }
            else
            {
                // Si el TextBox está vacío, muestra todas las filas
                this.mostrar(true);
            }
        }

        private void BCancelarBusqueda_Click(object sender, EventArgs e)
        {
            LModoBusqueda.Visible = false;
            BCancelarBusqueda.Visible = false;
            TBBusqueda.Clear();

            // Limpia cualquier ordenación previa en el DataGridView
            DGUsers.Sort(DGUsers.Columns[0], ListSortDirection.Ascending);

            mostrar(true);
        }

        private void cargarPersonas()
        {
            if (DGUsers.IsHandleCreated)
            {
                DGUsers.Rows.Clear();

            }
            //Se limpia la lista de personas

            // Limpia cualquier ordenación previa en el DataGridView
            DGUsers.Sort(DGUsers.Columns[0], ListSortDirection.Ascending);

            foreach (TrainingPlan plan in AppState.planes)
            {
                foreach (Client client in plan.Clients.ToArray())
                {
                    if(client.IdPersonNavigation.Inactive)
                    {
                        // Expiration 
                        TimeSpan diferencia = client.LastExpiration - DateTime.Now;

                        string ColumnExpirationMsg = diferencia.Days > 0 ?
                            ("En " + diferencia.Days + " días") : ("Hace " + diferencia.Days * -1 + " días");

                        /*
                            try
                            {
                                string ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageClient + "\\" + client.IdPersonNavigation.Avatar;

                                using (var image = System.Drawing.Image.FromFile(ruta))

                                    DGUsers.Rows.Add(
                                    image,
                                    client.IdPersonNavigation.FirstName + " " + client.IdPersonNavigation.LastName,
                                    client.IdTrainingPlanNavigation.Description,
                                    ColumnExpirationMsg,
                                    client.IdClient,
                                    client.IdPersonNavigation.Inactive);
                            }
                            catch (Exception e)
                            {

                        */
                        DGUsers.Rows.Add(
                        //Resources.vector_fitness_couple_doing_exercise,
                        client.IdPersonNavigation.FirstName + " " + client.IdPersonNavigation.LastName,
                        client.IdTrainingPlanNavigation.Description,
                        ColumnExpirationMsg,
                        client.IdClient,
                        client.IdPersonNavigation.Inactive);
                        //}
                    }



                }
            }

            // Actualiza la vista del DataGridView.
            DGUsers.Refresh();


        }


        private void mostrar(bool verEliminados)
        {
            // Limpia cualquier ordenación previa en el DataGridView
            DGUsers.Sort(DGUsers.Columns[0], ListSortDirection.Ascending);

            foreach (DataGridViewRow row in DGUsers.Rows)
            {

                row.Visible = bool.Parse(row.Cells["delete"].Value.ToString()) == verEliminados;

            }

            // Actualiza la vista del DataGridView.
            DGUsers.Refresh();


        }
        private void eliminar(int idClient)
        {

            foreach (DataGridViewRow row in DGUsers.Rows)
            {
                if (int.TryParse(row.Cells["IdClient"].Value?.ToString(), out int clientValue))
                {
                    if (clientValue == idClient)
                    {
                        DGUsers.Rows.Remove(row);
                        break;
                    }
                }
            }

            // Actualiza la vista del DataGridView.
            DGUsers.Refresh();

        }

        private void BEditarCliente_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila seleccionada en el DataGridView.
            if (DGUsers.SelectedRows.Count > 0)
            {
                //se guarda su indice
                this.indexRowSelect = DGUsers.SelectedRows[0].Index;

                int idClient = int.Parse(DGUsers.Rows[this.indexRowSelect].Cells["IdClient"].Value.ToString());

                var clientSelected = AddPayPresenter.BuscarCliente(idClient);

                //&& clientSelected.IdTrainingPlanNavigation != null && AppState.Instructor.IdPersonNavigation != null
                if (clientSelected != null)
                {
                    Lid_client.Text = clientSelected.IdClient.ToString();
                    LClientFullName.Text = clientSelected.IdPersonNavigation.FirstName + " " + clientSelected.IdPersonNavigation.LastName;
                    LPlan.Text = clientSelected.IdTrainingPlanNavigation.Description;
                    LInstructorFullName.Text = clientSelected.IdTrainingPlanNavigation.IdInstructorNavigation.IdPersonNavigation.FirstName + " " + clientSelected.IdTrainingPlanNavigation.IdInstructorNavigation.IdPersonNavigation.LastName;

                    TbAmount.Text = clientSelected.IdTrainingPlanNavigation.Price.ToString();
                    try
                    {
                        string ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageClient + "\\" + clientSelected.IdPersonNavigation.Avatar;
                        PimagenPerson.BackgroundImage = System.Drawing.Image.FromFile(ruta);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        PimagenPerson.BackgroundImage = Resources.gorilla_avatar;
                    }
                    //this.dbContext.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila.");
            }
        }

        private void BAgregarCliente_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Lid_client.Text, out int clientId))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea agregar un nuevo pago?", "Por favor confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    generarPagos(clientId);
                    vaciarLabels();


                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente.");
            }

        }

        private void vaciarLabels()
        {
            Lid_client.Text = "";
            LClientFullName.Text = "nombre...";
            LPlan.Text = "descripcion...";
            LInstructorFullName.Text = "nombre...";
            TbAmount.Text = "";
            PimagenPerson.BackgroundImage = Resources.gorilla_avatar;
        }

        private void generarPagos(int idClient)
        {
            try
            {
                float monto = float.Parse(TbAmount.Text);

                AddPayPresenter.AgregarPago(idClient, monto);

                //this.mostrar(false);
                eliminar(idClient);
                    MessageBox.Show("Pago realizado con éxito.");
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al realizar el pago: " + e.Message);
            }
        }

    }
}