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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int indice = 0;
        private List<Articulo> articulos;
        private Articulo seleccion;
        private int i;

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaArticulos art = new ListaArticulos();
                articulos = art.listar();
                dgvArticulos.DataSource = articulos;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void CargarImagen(Articulo aux)
        {
            List<Imagen> imagenes = aux.Url;
            i = imagenes.Count;
            if (indice < i)
            {
                btnCambiarImagen.Enabled = Enabled;
                try
                {
                    ptbImagen.Load(imagenes[indice].UrlImagen);

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

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            indice = 0;
            seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            CargarImagen(seleccion);
        }

        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            indice++;
            CargarImagen(seleccion);
        }
    }
}
