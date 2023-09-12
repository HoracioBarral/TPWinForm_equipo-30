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

        private List<Articulo> articulos;

        private void btnListar_Click(object sender, EventArgs e)
        {
            
            ListaArticulos art = new ListaArticulos();
            try
            {
                articulos = art.listar();
                dgvArticulos.DataSource = articulos;
                CargarImagen(articulos[0].Url[0]);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void CargarImagen(string urlImagen)
        {
            try
            {
                ptbImagen.Load(urlImagen);
            }
            catch (Exception)
            {

                ptbImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
            
        }
    }
}
