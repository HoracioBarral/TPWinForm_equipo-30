using administrador_datos;
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

namespace WindowsFormsApp
{
    public partial class AgregarArticulo : Form
    {
        public AgregarArticulo()
        {
            InitializeComponent();
        }

        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void AgregarArticulo_Load(object sender, EventArgs e)
        {
            ListaMarcas listadoMarcas = new ListaMarcas();
            ListaCategorias listadoCategorias = new ListaCategorias();
            try
            {
                cmbMarcas.DataSource = listadoMarcas.Listar();
                cmbCategorias.DataSource = listadoCategorias.Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
