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
        private int indice;
        private List<Imagen> imagenes;
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
            indice = 0;
            MarcaNegocio listadoMarcas = new MarcaNegocio();
            CategoriaNegocio listadoCategorias = new CategoriaNegocio();
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            try
            {
                txtNombre.Text = articulo.Nombre;
                txtCodigo.Text = articulo.Codigo;
                txtPrecio.Text = articulo.Precio.ToString();
                txtDescripcion.Text = articulo.Descripcion;
                cmbMarcas.DataSource = listadoMarcas.Listar();
                cmbCategorias.DataSource = listadoCategorias.Listar();
                if (articulo.UrlImagen != null)
                {
                    advertencia.Text = string.Empty;
                    imagenes = articulo.UrlImagen;
                    CargarImagenes();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        private void CargarImagenes()
        {
            if (indice >= imagenes.Count)
            {
                btnSiguiente.Enabled = false;
            }
            try
            {
                txtImagen.Text = imagenes[indice].Url.ToString();
                ptbImagen.Load(imagenes[indice].Url);
                indice++;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indice >= imagenes.Count)
            {
                btnSiguiente.Enabled = false;
            }
            else
            {
                btnSiguiente.Enabled = true;
                indice++;
                CargarImagenes();
            }
        }
    }
}
