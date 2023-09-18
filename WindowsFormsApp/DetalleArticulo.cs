using dominio;
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
    public partial class DetalleArticulo : Form
    {
        private Articulo articulo;
        private int indice;
        private List<Articulo> art;
        private List<Imagen> imagenes;
        public DetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void DetalleArticulo_Load_1(object sender, EventArgs e)
        {
            if (articulo != null)
            {
                lblNombreDA.Text = articulo.Nombre;
                lblCodigoDA.Text = articulo.Codigo;
                lblPrecioDA.Text = articulo.Precio.ToString();
                lblDescripcionDA.Text = articulo.Descripcion;
                if (articulo.NombreMarca != null)
                {
                    lblMarcaDA.Text = articulo.NombreMarca.Descripcion;
                }
                else
                {
                    lblMarcaDA.Text = "Desconocida";
                }

                if (articulo.TipoCategoria != null)
                {
                    lblCategoriaDA.Text = articulo.TipoCategoria.Descripcion;
                }
                else
                {
                    lblCategoriaDA.Text = "Desconocida";
                }

                if (articulo.UrlImagen != null && articulo.UrlImagen.Count > 0)
                {
                    ptbImagenDA.Load(articulo.UrlImagen[0].Url);
                }
                else
                {
                    ptbImagenDA.Image = null;
                }
            }
        }

        private void btnVolverDA_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
