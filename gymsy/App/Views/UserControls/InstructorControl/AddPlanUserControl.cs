﻿using CustomControls.RJControls;
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
    public partial class AddPlanUserControl : UserControl
    {
        private int idPlan = 0;
        private bool isEditMode = false;
        private int indexRowSelect = 0;

        //private DataGridViewRow selectedRow; // Declara una variable para mantener la fila seleccionada.
        public AddPlanUserControl()
        {
            InitializeComponent();
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
        {
            //en numeroIngresado se guarda el valor ingresado en el textbox de ser un numero valido
            if (float.TryParse(TBPrecio.Text, out float numeroIngresado) && numeroIngresado >= 0)
            {
                //Se verifica que se hay ingresado una descripcion
                if (!string.IsNullOrWhiteSpace(TBDescripcion.Text))
                {
                    // Aquí puedes realizar la acción que necesites con el número ingresado
                    LPrecioRequerido.Visible = false;
                    LDescripcionRequerido.Visible = false;

                    if (isEditMode)
                    {
                        // Actualiza el valor en tu fuente de datos original.
                        // Por ejemplo, si usas un DataTable:


                        DataGridViewRow selectedRow = DGPlan.Rows[this.indexRowSelect];
                        selectedRow.Cells["Precio"].Value = TBPrecio.Text;
                        selectedRow.Cells["Descripcion"].Value = TBDescripcion.Text;

                        // Actualiza la vista del DataGridView.
                        DGPlan.Refresh();


                        //MessageBox.Show("Se Edito correcetamente el plan con un precio de: $" + numeroIngresado.ToString() + "\nDescripcion: " + TBDescripcion.Text);

                        selectedRow = null;
                        this.isEditMode = false;

                        //Se cambia el boton para que ahora se pueda eliminar planes
                        BEliminarPlan.IconChar = FontAwesome.Sharp.IconChar.Trash;
                        BEliminarPlan.Text = "Eliminar Plan";

                        LModoEditOrAdd.Text = "Modo Agregar";
                    }
                    else
                    {
                        // Agregar una nueva fila al DataGridView con los valores


                        this.idPlan++;
                        DGPlan.Rows.Add(this.idPlan, TBPrecio.Text, TBDescripcion.Text);

                        //MessageBox.Show("Se Ingreso correcetamente el plan con un precio de: $" + numeroIngresado.ToString() + "\nDescripcion: " + TBDescripcion.Text);

                    }



                    // Limpiar los TextBox después de agregar la fila
                    TBPrecio.Clear();
                    TBDescripcion.Clear();


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
        }

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
            if (this.isEditMode)
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
                //Se pregunta si desea eliminar el plan
                // Crear un cuadro de diálogo personalizado con los botones que desees
                MessageBoxButtons botones = MessageBoxButtons.YesNo;
                MessageBoxDefaultButton botonPredeterminadoNo = MessageBoxDefaultButton.Button2; // Button2 se refiere al botón "No"


                DialogResult v_dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el plan?", "Eliminar Plan", botones, MessageBoxIcon.Question, botonPredeterminadoNo);

                if (v_dialogResult == DialogResult.Yes)
                {
                    // Verifica si hay al menos una fila seleccionada en el DataGridView.
                    if (DGPlan.SelectedRows.Count > 0)
                    {

                        //se guarda su indice
                        this.indexRowSelect = DGPlan.SelectedRows[0].Index;

                        //Se elimina la fila
                        DGPlan.Rows.RemoveAt(this.indexRowSelect);

                        //Se limpia el indice
                        this.indexRowSelect = 0;

                        //MessageBox.Show("Se elimino correctamente el plan.");
                    }
                    else
                    {
                        MessageBox.Show("Por favor, seleccione una fila para eliminar.");
                    }
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
                    row.Visible = coincide;
                }
            }
            else
            {
                // Si el TextBox está vacío, muestra todas las filas
                foreach (DataGridViewRow row in DGPlan.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BCancelarBusqueda_Click(object sender, EventArgs e)
        {
            LModoBusqueda.Visible = false;
            BCancelarBusqueda.Visible = false;
            TBBusqueda.Clear();

            // Limpia cualquier ordenación previa en el DataGridView
            DGPlan.Sort(DGPlan.Columns[0], ListSortDirection.Ascending);

            // Si el TextBox está vacío, muestra todas las filas
            foreach (DataGridViewRow row in DGPlan.Rows)
            {
                row.Visible = true;
            }

        }

    
    }
}