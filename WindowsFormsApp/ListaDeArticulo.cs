using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using moldes_clases;
using administrador_datos;

namespace WindowsFormsApp
{
    public partial class ListadoDeArticulo : Form
    {
        public ListadoDeArticulo()
        {
            InitializeComponent();
            ListarArticulos();
        }
        private int indice = 0;
        private List<Articulo> articulos;
        private Articulo seleccion;
        private int i;

        private void ListarArticulos()
        {
            ArticuloNegocio art = new ArticuloNegocio();
            try
            {
                articulos = art.listar();
                dgvArticulos.DataSource = articulos;
                dgvArticulos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }


        private void CargarImagen(Articulo aux)
        {
            List<Imagen> imagenes = aux.UrlImagen;
            i = imagenes.Count;
            if (indice < i)
            {
                btnCambiarImagen.Enabled = true;
                try
                {
                    ptbImagen.Load(imagenes[indice].Url);

                }
                catch (Exception)
                {

                    ptbImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                }
            }
            else
            {
               btnCambiarImagen.Enabled = false;
            }
        }

        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            indice++;
            CargarImagen(seleccion);
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            indice = 0;
            seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            CargarImagen(seleccion);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
