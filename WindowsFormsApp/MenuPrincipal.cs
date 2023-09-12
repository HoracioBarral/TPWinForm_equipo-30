using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            btningresarNombre.Enabled = false;
        }
        private void controlbotones()
        {
            if (Nombre.Text.Trim() != string.Empty && Nombre.Text.All(Char.IsLetter))
            {
                btningresarNombre.Enabled = true;
                errorProvider1.SetError(Nombre, "");
            }
            else
            {
                if (!(Nombre.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(Nombre, "El nombre sólo debe contener letras");
                }
                else
                {
                    errorProvider1.SetError(Nombre, "Debe introducir su nombre");
                }
                btningresarNombre.Enabled = false;
                Nombre.Focus();
            }
        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {
            controlbotones();
        }
    }
}
