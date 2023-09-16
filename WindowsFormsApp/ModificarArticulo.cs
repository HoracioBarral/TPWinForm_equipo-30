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
        private Articulo articuloAmodificar;
        public ModificarArticulo(Articulo articuloAmodificar)
        {
            InitializeComponent();
            this.articuloAmodificar = articuloAmodificar;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarArticulo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

        }
    }
}
