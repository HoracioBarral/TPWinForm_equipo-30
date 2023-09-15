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

        List<Imagen> imagenes = new List<Imagen>();
        Articulo nuevo = new Articulo();

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

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            ListaArticulos aux = new ListaArticulos();
            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.NombreMarca = (Marca)cmbMarcas.SelectedItem;
                nuevo.TipoCategoria = (Categoria)cmbCategorias.SelectedItem;
                aux.AgregarArticulo(nuevo);
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnImagenExtra_Click(object sender, EventArgs e)
        {
            Imagen imagen = new Imagen();
            try
            {
                imagen.Url = txtImagen.Text;
                imagenes.Add(imagen);
                nuevo.UrlImagen = imagenes;
                txtImagen.Text = string.Empty;
                MessageBox.Show("Imagen agregada al articulo");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
