using CustomControls.RJControls;
using gymsy.App.Models;
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
using System.Linq;
using gymsy.App.Presenters;

namespace gymsy.UserControls
{
    public partial class AddPlanUserControl : UserControl
    {
        private bool isModeVerNoDelete = true;
        //private int idPlan = 0;
        private bool isEditMode = false;
        private int indexRowSelect = 0;
        //private GymsyDbContext dbContext;


        //private DataGridViewRow selectedRow; // Declara una variable para mantener la fila seleccionada.
        public AddPlanUserControl()
        {
            //Se trae el contexto de la base de datos
            //this.dbContext = GymsyContext.GymsyContextDB;

            InitializeComponent();
            InitializeGridPlanes();

            //Muestra lo que no estan eliminados

            this.mostrar(false);
        }

        private void InitializeGridPlanes()
        {
            var trainingPlans = AddPlanUserPresenter.listarPlanesInstructor();

            if (trainingPlans != null)
            {
                foreach (TrainingPlan plan in trainingPlans)
                {
                    DGPlan.Rows.Add(plan.IdTrainingPlan, plan.Price, plan.Description, plan.Inactive);

                }
            }



        }

        private void TBPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Verificar si la tecla presionada es un número, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Si no es un carácter válido, se ignora
            }

            // Asegurarse de que solo haya un punto decimal

            if (e.KeyChar == '.' && TBPrecio.Contains("."))
            {
                e.Handled = true;
            }


        }

        private void BAgregarPlan_Click(object sender, EventArgs e)
        {  try
            {
                //en numeroIngresado se guarda el valor ingresado en el textbox de ser un numero valido
                if (float.TryParse(TBPrecio.Text, out float numeroIngresado) && numeroIngresado >= 0)
                {
                    //Se verifica que se ha ingresado una descripcion
                    if (!string.IsNullOrWhiteSpace(TBDescripcion.Text))
                    {
                        // Aquí puedes realizar la acción que necesites con el número ingresado
                        LPrecioRequerido.Visible = false;
                        LDescripcionRequerido.Visible = false;

                        if (isEditMode)
                        {



                            DataGridViewRow selectedRow = DGPlan.Rows[this.indexRowSelect];
                            selectedRow.Cells["Precio"].Value = TBPrecio.Text;
                            selectedRow.Cells["Descripcion"].Value = TBDescripcion.Text;

                            int idPlan = int.Parse(selectedRow.Cells["id_plan"].Value.ToString());


                            if (AddPlanUserPresenter.DescripcionUnica(TBDescripcion.Text, idPlan))
                            {



                                float precio = float.Parse(TBPrecio.Text);

                                AddPlanUserPresenter.modificarPlan(idPlan, TBDescripcion.Text, precio);

                                // Actualiza la vista del DataGridView.
                                DGPlan.Refresh();


                                //MessageBox.Show("Se Edito correcetamente el plan con un precio de: $" + numeroIngresado.ToString() + "\nDescripcion: " + TBDescripcion.Text);

                                selectedRow = null;
                                this.isEditMode = false;

                                //Se cambia el boton para que ahora se pueda eliminar planes
                                BEliminarPlan.IconChar = FontAwesome.Sharp.IconChar.Trash;
                                BEliminarPlan.Text = "Eliminar Plan";

                                LModoEditOrAdd.Text = "Modo Agregar";

                                // Limpiar los TextBox después de agregar la fila
                                TBPrecio.Clear();
                                TBDescripcion.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un plan con esa descripcion.");
                            }

                        }
                        else
                        {

                            if (AddPlanUserPresenter.DescripcionUnica(TBDescripcion.Text))
                            {
                                float precio_a_guardar = float.Parse(TBPrecio.Text);

                                TrainingPlan plan_guardado = AddPlanUserPresenter.guardarPlan(TBDescripcion.Text, precio_a_guardar);

                                DGPlan.Rows.Add(plan_guardado.IdTrainingPlan, TBPrecio.Text, TBDescripcion.Text, false);

                                MessageBox.Show("Plan guardado correctamente.");

                                // Limpiar los TextBox después de agregar la fila
                                TBPrecio.Clear();
                                TBDescripcion.Clear();


                            }
                            else
                            {
                                MessageBox.Show("Ya existe un plan con esa descripcion.");
                            }

                        }






                    }
                    else
                    {
                        LDescripcionRequerido.Visible = true;
                    }

                }
                else
                {
                    LPrecioRequerido.Visible = true;
                    MessageBox.Show("Por favor, verifique que haya ingresado correctamente todos los campos.");
                }
            } catch
            {
                MessageBox.Show("Error al guardar el plan.");
            }
        }

        /**
         * Solo se encarga de traer los datos de la fila seleccionada y ponerlos en los textbox
         */
        private void BEditarPlan_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila seleccionada en el DataGridView.
            if (DGPlan.SelectedRows.Count > 0)
            {
                this.isEditMode = true;
                LModoEditOrAdd.Text = "Modo Editar";
                // Accede a la fila seleccionada.
                DataGridViewRow selectedRow = DGPlan.SelectedRows[0];
                //se guarda su indice
                this.indexRowSelect = DGPlan.SelectedRows[0].Index;


                //Se mandan a los texbox el valor de la celdas
                TBPrecio.Text = selectedRow.Cells["Precio"].Value.ToString();
                TBDescripcion.Text = selectedRow.Cells["Descripcion"].Value.ToString();

                //Se cambia el boton de eliminar por el de cancelar edicion
                BEliminarPlan.IconChar = FontAwesome.Sharp.IconChar.Ban;
                BEliminarPlan.Text = "Cancelar";

            }
        }

        private void DGPlan_VisibleChanged(object sender, EventArgs e)
        {
            /*
            if (this.isEditMode)
            {
                DGPlan.Rows[this.indexRowSelect].Selected = true;
                // Hace que la fila seleccionada sea visible en la vista del DataGridView.
                DGPlan.FirstDisplayedScrollingRowIndex = this.indexRowSelect;
            }
            */
        }

        private void BEliminarPlan_Click(object sender, EventArgs e)
        {

            if (this.isEditMode) //SE CANCELA LA EDICION
            {

                LModoEditOrAdd.Text = "Modo Agregar";

                //Se cambia el boton para que ahora se pueda eliminar planes
                BEliminarPlan.IconChar = FontAwesome.Sharp.IconChar.Trash;
                BEliminarPlan.Text = "Eliminar Plan";

                this.isEditMode = false;

                this.indexRowSelect = 0;


                // Limpiar los TextBox después de agregar la fila
                TBPrecio.Clear();
                TBDescripcion.Clear();
            }
            else
            {
                // Verifica si hay al menos una fila seleccionada en el DataGridView.
                if (DGPlan.SelectedRows.Count > 0)
                {
                    //Se crearan las variables
                    string pregunta = "";
                    bool deleteOrAcitive = false;
                    //Se procede a cetear tanto los mensajes como las busquedas que se haran
                    if (this.isModeVerNoDelete)
                    {
                        pregunta = "¿Desea eliminar este Plan?";
                        deleteOrAcitive = true; //Si se va a eleminar a alguien, primero debe estar no eleiminado

                    }
                    else
                    {
                        pregunta = "¿Desea activar este Plan?";
                        deleteOrAcitive = false;
                    }

                    DialogResult resultado = MessageBox.Show(pregunta, "Por favor confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {

                        if (this.isModeVerNoDelete)
                        {

                            //Se pregunta si desea eliminar el plan
                            // Crear un cuadro de diálogo personalizado con los botones que desees
                            MessageBoxButtons botones = MessageBoxButtons.YesNo;
                            MessageBoxDefaultButton botonPredeterminadoNo = MessageBoxDefaultButton.Button2; // Button2 se refiere al botón "No"


                            DialogResult v_dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el plan?", "Eliminar Plan", botones, MessageBoxIcon.Question, botonPredeterminadoNo);



                            //se guarda su indice
                            this.indexRowSelect = DGPlan.SelectedRows[0].Index;

                            DGPlan.SelectedRows[0].Cells["delete"].Value = deleteOrAcitive;

                            var idPlan = int.Parse(DGPlan.SelectedRows[0].Cells["id_plan"].Value.ToString());

                            AddPlanUserPresenter.EliminarOActivarPlan(idPlan, deleteOrAcitive);

                            //Se limpia el indice
                            this.indexRowSelect = 0;

                            MessageBox.Show("Se elimino correctamente el plan.");
                            mostrar(!this.isModeVerNoDelete);

                        }
                        else //Se procede a Activar el plan
                        {
                            //Se pregunta si desea eliminar el plan
                            // Crear un cuadro de diálogo personalizado con los botones que desees
                            MessageBoxButtons botones = MessageBoxButtons.YesNo;
                            MessageBoxDefaultButton botonPredeterminadoNo = MessageBoxDefaultButton.Button2; // Button2 se refiere al botón "No"


                            DialogResult v_dialogResult = MessageBox.Show("¿Esta seguro que desea activar el plan?", "Activar Plan", botones, MessageBoxIcon.Question, botonPredeterminadoNo);



                            //se guarda su indice
                            this.indexRowSelect = DGPlan.SelectedRows[0].Index;

                            DGPlan.SelectedRows[0].Cells["delete"].Value = deleteOrAcitive;

                            var idPlan = int.Parse(DGPlan.SelectedRows[0].Cells["id_plan"].Value.ToString());

                            AddPlanUserPresenter.EliminarOActivarPlan(idPlan, deleteOrAcitive);


                            //Se limpia el indice
                            this.indexRowSelect = 0;

                            MessageBox.Show("Se Activo correctamente el plan.");
                            mostrar(!this.isModeVerNoDelete);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar.");
                }

            }

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
                DGPlan.Sort(DGPlan.Columns[0], ListSortDirection.Ascending);
                // Recorre todas las filas del DataGridView y oculta aquellas que no coincidan con el texto buscado
                foreach (DataGridViewRow row in DGPlan.Rows)
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

            // Si el TextBox está vacío, muestra todas las filas
            this.mostrar(!this.isModeVerNoDelete);

        }

        private void BVerPlanes_Click(object sender, EventArgs e)
        {
            if (this.isEditMode)
            {
                MessageBox.Show("Por favor, termine de editar.");
            }
            else
            {
                this.isModeVerNoDelete = true;
                BEliminarPlan.Text = "Eliminar Plan";
                BEliminarPlan.BackColor = Color.FromArgb(192, 0, 0);
                BEliminarPlan.IconChar = FontAwesome.Sharp.IconChar.Trash;

                this.mostrar(false);
            }
        }

        private void mostrar(bool verEliminados)
        {
            // Limpia cualquier ordenación previa en el DataGridView
            DGPlan.Sort(DGPlan.Columns[0], ListSortDirection.Ascending);

            foreach (DataGridViewRow row in DGPlan.Rows)
            {

                row.Visible = bool.Parse(row.Cells["delete"].Value.ToString()) == verEliminados;

            }

            // Actualiza la vista del DataGridView.
            DGPlan.Refresh();

        }


        private void BVerPlanesEliminados_Click(object sender, EventArgs e)
        {
            if (this.isEditMode)
            {
                MessageBox.Show("Por favor, termine de editar.");
            }
            else
            {
                this.isModeVerNoDelete = false;
                BEliminarPlan.Text = "Activar Plan";
                BEliminarPlan.BackColor = Color.FromArgb(255, 140, 0);
                BEliminarPlan.IconChar = FontAwesome.Sharp.IconChar.Dumbbell;


                //Cargar DataGrid
                mostrar(true);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
