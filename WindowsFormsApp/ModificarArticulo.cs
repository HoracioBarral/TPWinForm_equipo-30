using administrador_datos;
using moldes_clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ModificarArticulo : Form
    {
        private Articulo articulo;
        public ModificarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio listadoMarcas = new MarcaNegocio();
            CategoriaNegocio listadoCategorias = new CategoriaNegocio();
            try
            {
                txtNombre.Text = articulo.Nombre;
                txtCodigo.Text = articulo.Codigo;
                txtPrecio.Text = articulo.Precio.ToString();
                txtDescripcion.Text = articulo.Descripcion;
                cmbMarcas.DataSource = listadoMarcas.Listar();
                cmbCategorias.DataSource = listadoCategorias.Listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

        }
    }
}
