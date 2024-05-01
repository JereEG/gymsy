using gymsy.App.Models;
using gymsy.App.Presenters;
using gymsy.Context;
using gymsy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymsy.UserControls.AdminControls
{
    public partial class InstructorsAdminControl : UserControl
    {
        private GymsyDbContext dbContext;
        private int indexRowSelect = 0;
        private bool isModeVerNoDelete = true;
        private AdminPresenter presenter;
        public InstructorsAdminControl()
        {
            //Se trae el contexto de la base de datos

            InitializeComponent();
            presenter=new AdminPresenter();
            this.cargarPersonas();
            //se muestran los activos
            this.mostrar(false);
        }
        private void cargarPersonas()
        {
            if (DGInstructors.IsHandleCreated)
            {
                DGInstructors.Rows.Clear();

            }
            //Se limpia la lista de personas

            // Limpia cualquier ordenación previa en el DataGridView
            DGInstructors.Sort(DGInstructors.Columns[0], ListSortDirection.Ascending);


            var instructors = presenter.GetInstructors();
            int cantidad_clientes = 0;
            double ingreso = 0.0;

            foreach (var instructor in instructors)
            {

                //Deben ser los activos, y en un cierto periodo
               
                cantidad_clientes = presenter.InstructorCantClientes(instructor);
                ingreso = presenter.ingresoClientes(instructor);
                
                try
                {
                    string ruta = AppState.pathDestinationFolder + AppState.nameCarpetImageInstructor + "\\" + instructor.IdPersonNavigation.Avatar;


                    DGInstructors.Rows.Add(
                    System.Drawing.Image.FromFile(ruta),
                    instructor.IdPersonNavigation.FirstName + " " + instructor.IdPersonNavigation.LastName,
                    instructor.IdPersonNavigation.NumberPhone,
                    cantidad_clientes,
                    ingreso,
                    instructor.IdInstructor,
                    instructor.IdPersonNavigation.Inactive);
                }
                catch (Exception e)
                {
                    DGInstructors.Rows.Add(
                    Resources.instructor,
                    instructor.IdPersonNavigation.FirstName + " " + instructor.IdPersonNavigation.LastName,
                    instructor.IdPersonNavigation.NumberPhone,
                    cantidad_clientes,
                    ingreso,
                    instructor.IdInstructor,
                    instructor.IdPersonNavigation.Inactive);
                }
            }

            // Actualiza la vista del DataGridView.
            DGInstructors.Refresh();


        }

        private void mostrar(bool verEliminados)
        {
            // Limpia cualquier ordenación previa en el DataGridView
            DGInstructors.Sort(DGInstructors.Columns[0], ListSortDirection.Ascending);

            foreach (DataGridViewRow row in DGInstructors.Rows)
            {

                row.Visible = bool.Parse(row.Cells["delete"].Value.ToString()) == verEliminados;

            }

            // Actualiza la vista del DataGridView.
            DGInstructors.Refresh();


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
                DGInstructors.Sort(DGInstructors.Columns[0], ListSortDirection.Ascending);
                // Recorre todas las filas del DataGridView y oculta aquellas que no coincidan con el texto buscado
                foreach (DataGridViewRow row in DGInstructors.Rows)
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

                    //row.Visible = (this.isModeVerNoDelete && !deleteValue) || (!this.isModeVerNoDelete && deleteValue);
                    row.Visible = coincide && !this.isModeVerNoDelete == deleteValue;


                }
            }
            else
            {
                // Si el TextBox está vacío, muestra todas las filas
                this.mostrar(!this.isModeVerNoDelete);
            }
        }

        private void BCancelarBusqueda_Click(object sender, EventArgs e)
        {
            LModoBusqueda.Visible = false;
            BCancelarBusqueda.Visible = false;
            TBBusqueda.Clear();

            // Limpia cualquier ordenación previa en el DataGridView
            DGInstructors.Sort(DGInstructors.Columns[0], ListSortDirection.Ascending);

            mostrar(!this.isModeVerNoDelete);

        }

        private void BAgregarCliente_Click(object sender, EventArgs e)
        {
            AppState.isModeAdd = true;
            MainView.navigationControl.Display(4, true);
        }

        private void BEditarCliente_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila seleccionada en el DataGridView.
            if (DGInstructors.SelectedRows.Count > 0)
            {
                //se guarda su indice
                this.indexRowSelect = DGInstructors.SelectedRows[0].Index;

                // Accede a la celda "id" del cliente

                int idInstructorSelected = int.Parse(DGInstructors.Rows[this.indexRowSelect].Cells["id_instructor"].Value.ToString());

                var instructorSelected = this.dbContext.Instructors.Where(i => i.IdInstructor == idInstructorSelected).FirstOrDefault();

                AppState.InstructorActive = instructorSelected;
                AppState.isModeEdit = true;

                MainView.navigationControl.Display(7, true);

            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editarlo.");
            }
        }

        private void BEliminarCliente_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila seleccionada en el DataGridView.
            if (DGInstructors.SelectedRows.Count > 0)
            {
                //Se crearan las variables
                string pregunta = "";
                bool deleteOrActive;
                //Se procede a cetear tanto los mensajes como las busquedas que se haran
                if (this.isModeVerNoDelete)
                {
                    pregunta = "¿Desea eliminar este usuario?";
                    deleteOrActive = true; // true is inactive

                }
                else
                {
                    pregunta = "¿Desea activar este usuario?";
                    deleteOrActive = false;//of inactive false
                }

                DialogResult resultado = MessageBox.Show(pregunta, "Por favor confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {

                    //se guarda su indice
                    this.indexRowSelect = DGInstructors.SelectedRows[0].Index;

                    // Accede a la celda "Eliminado" de la fila seleccionada y actualiza su valor
                    DGInstructors.Rows[this.indexRowSelect].Cells["delete"].Value = deleteOrActive;

                    int idInstructor = int.Parse(DGInstructors.Rows[this.indexRowSelect].Cells["id_instructor"].Value.ToString());

                    var InstructorUpdated = this.dbContext.Instructors
                    .Where(i => i.IdInstructor == idInstructor)
                    .First();

                    if (InstructorUpdated != null)
                    {
                        InstructorUpdated.IdPersonNavigation.Inactive = deleteOrActive;

                        this.dbContext.SaveChanges();
                    }



                    //Se actualiza el datagrid con el 
                    this.mostrar(!this.isModeVerNoDelete);

                    //MessageBox.Show("Se elimino correctamente el Cliente.");


                    MessageBox.Show("El usuario ha sido eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {


                    MessageBox.Show("La eliminación del usuario ha sido cancelada.", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }

        private void BVerClients_Click(object sender, EventArgs e)
        {
            this.isModeVerNoDelete = true;
            BEliminarCliente.Text = "Eliminar";
            BEliminarCliente.BackColor = Color.FromArgb(192, 0, 0);
            BEliminarCliente.IconChar = FontAwesome.Sharp.IconChar.Trash;
            //Se mostraran los no inactivos
            this.mostrar(false);
        }

        private void BVerClientDelete_Click(object sender, EventArgs e)
        {

            this.isModeVerNoDelete = false;
            BEliminarCliente.Text = "Activar";
            BEliminarCliente.BackColor = Color.FromArgb(255, 140, 0);
            BEliminarCliente.IconChar = FontAwesome.Sharp.IconChar.User;
            //se cargan los inactivos
            mostrar(true);
        }
        public override void Refresh()
        {
            if (AppState.needRefreshClientsUserControl)
            {
                this.cargarPersonas();
                this.isModeVerNoDelete = true;
                BEliminarCliente.Text = "Eliminar";
                BEliminarCliente.BackColor = Color.FromArgb(192, 0, 0);
                BEliminarCliente.IconChar = FontAwesome.Sharp.IconChar.Trash;
                //Se mostraran los no inactivos
                this.mostrar(false);
                AppState.needRefreshClientsUserControl = false;
            }
        }
    }
}
