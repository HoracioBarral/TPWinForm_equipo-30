using negocio;
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

namespace WindowsFormsApp
{
    public partial class AgregarArticulo : Form
    {
        Articulo articuloNuevo;
        List<Imagen> imagenes = new List<Imagen>();

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
            MarcaNegocio listadoMarcas = new MarcaNegocio();
            CategoriaNegocio listadoCategorias = new CategoriaNegocio();
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
            ArticuloNegocio aux = new ArticuloNegocio();
            try
            {

                if (!ValidarDatos())
                {
                    articuloNuevo = new Articulo();
                    articuloNuevo.Nombre = txtNombre.Text;
                    articuloNuevo.Codigo = txtCodigo.Text;
                    articuloNuevo.Precio = decimal.Parse(txtPrecio.Text);
                    articuloNuevo.Descripcion = txtDescripcion.Text;
                    articuloNuevo.NombreMarca = (Marca)cmbMarcas.SelectedItem;
                    articuloNuevo.TipoCategoria = (Categoria)cmbCategorias.SelectedItem;
                    articuloNuevo.UrlImagen = imagenes;
                    aux.AgregarArticulo(articuloNuevo);
                    MessageBox.Show("Agregado exitosamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("Faltan datos por ingresar o estan mal cargados");
                    return;
                }
                
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
                if(txtImagen.Text.Length != 0)
                {
                    imagenes.Add(imagen);
                    txtImagen.Text = string.Empty;
                    MessageBox.Show("Imagen agregada al articulo");
                }
                else
                {
                    MessageBox.Show("Por favor complete con una imagen y luego presione el boton");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool ValidarDatos()
        {
            if (cmbCategorias.SelectedIndex < 0)

                return true;


            if (cmbMarcas.SelectedIndex < 0)

                return true;

            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text))
                return true;
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
                return true;
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                return true;
            }
            if (!VerificarNumeros())
            {
                return true;
            }

            return false;
        }


        private bool VerificarNumeros()
        {
            foreach (char c in txtPrecio.Text)
            {
                if (!(char.IsNumber(c)))
                    return false;
            }
            return true;
        }
    }
}
