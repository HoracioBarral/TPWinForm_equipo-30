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
    }
}
