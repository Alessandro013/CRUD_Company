using CRUD_Company.Respository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Company
{
    public partial class Form1 : Form
    {
        private UserRepository repo = new UserRepository();
        private int idSeleccionado = 0;

        public Form1()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void CargarGrid()
        {
            dgvProductos.DataSource = repo.ObtenerProductos();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textNombre.Text = "";
            textDescription.Text = "";
            idSeleccionado = 0;
        }

        // EVENTO AL SELECCIONAR UNA FILA DEL DATAGRIDVIEW
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                textNombre.Text = row.Cells["Name"].Value.ToString();
                textDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // GUARDAR
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text) || string.IsNullOrWhiteSpace(textDescription.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            repo.Create(textNombre.Text.Trim(), textDescription.Text.Trim());
            MessageBox.Show("Producto guardado correctamente.");
            CargarGrid();
        }

        // UPDATE
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un Producto de la tabla para actualizar.");
                return;
            }

            repo.Update(idSeleccionado, textNombre.Text.Trim(), textDescription.Text.Trim());
            MessageBox.Show("Producto actualizado correctamente.");
            CargarGrid();
        }

        // ELIMINAR
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un Producto de la tabla para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de eliminar este Producto?", "Confirmación", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                repo.Delete(idSeleccionado);
                MessageBox.Show("Producto eliminado.");
                CargarGrid();
            }
        }
    }
}
