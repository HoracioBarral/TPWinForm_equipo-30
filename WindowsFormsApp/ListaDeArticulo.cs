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


        public void CargarImagen(List<Imagen> imagenes)
        {
            
             try
                 {
                   ptbImagen.Load(imagenes[indice].Url);

                 }
             catch (Exception)
                  {
                    ptbImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                   }
            finally
            {
                indice++;
                if(indice >= imagenes.Count)
                {
                    btnCambiarImagen.Enabled = false;
                }
            }
        }

        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            
            if (seleccion.UrlImagen != null)
             {
                CargarImagen(seleccion.UrlImagen);
             }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            indice = 0;
            btnCambiarImagen.Enabled = true;
            seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (seleccion.UrlImagen != null)
            {
                CargarImagen(seleccion.UrlImagen);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (ModificarArticulo ventanaMArticulo = new ModificarArticulo(seleccion))
                ventanaMArticulo.ShowDialog();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Usted quiere eliminar este articulo?" , "Eliminando",MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminarArticulo(seleccionado.Id);
                }
                
                
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());

                throw;
            }
        }

        private void ListadoDeArticulo_Load(object sender, EventArgs e)
        {
            ListarArticulos();
        }
    }
}
