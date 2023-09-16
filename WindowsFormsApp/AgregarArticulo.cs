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
        Articulo articuloNuevo = null;
        List<Imagen> imagenes = new List<Imagen>();
        //Articulo aux = new Articulo();

        public AgregarArticulo()
        {
            InitializeComponent();
        }

        public AgregarArticulo(Articulo articuloNuevo)
        {
            InitializeComponent();
            this.articuloNuevo = articuloNuevo;
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
                if (articuloNuevo == null)
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
    }
}
