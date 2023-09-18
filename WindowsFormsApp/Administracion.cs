using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace WindowsFormsApp
{
    public partial class Administracion : Form
    {

        string nombre_usuario;


        public Administracion(string nombre)
        {
            InitializeComponent();
            nombre_usuario = nombre;
        }
        private void Administracion_load(object sender, EventArgs e)
        {
            saludo.Text+= nombre_usuario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            using (AgregarArticulo ventanaArticulo = new AgregarArticulo())
                ventanaArticulo.ShowDialog();
        }


        private void btnListaArticulo_Click(object sender, EventArgs e)
        {
            using (ListadoDeArticulo ventanaListado = new ListadoDeArticulo())
                ventanaListado.ShowDialog();
        }

        
    }
}
