using administrador_datos;
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
        private Articulo articulo;
        private int indice;
        private List<Imagen> imagenes;
        public ModificarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarArticulo_Load(object sender, EventArgs e)
        {
            indice = 0;
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            MarcaNegocio listadoMarcas = new MarcaNegocio();
            CategoriaNegocio listadoCategorias = new CategoriaNegocio();
            try
            {
                txtNombre.Text = articulo.Nombre;
                txtCodigo.Text = articulo.Codigo;
                txtPrecio.Text = articulo.Precio.ToString();
                txtDescripcion.Text = articulo.Descripcion;
                cmbMarcas.DataSource = listadoMarcas.Listar();
                cmbMarcas.ValueMember = "id";
                cmbMarcas.DisplayMember = "Descripcion";
                if (articulo.NombreMarca != null)
                    cmbMarcas.SelectedValue = articulo.NombreMarca.Id;
                else
                    cmbMarcas.SelectedValue = "";
                cmbCategorias.DataSource = listadoCategorias.Listar();
                cmbCategorias.ValueMember = "id";
                cmbCategorias.DisplayMember = "Descripcion";
                if (articulo.TipoCategoria != null)
                    cmbCategorias.SelectedValue = articulo.TipoCategoria.Id;
                else
                    cmbCategorias.SelectedValue = "";
                if (articulo.UrlImagen != null)
                {
                    advertencia.Text = string.Empty;
                    imagenes = articulo.UrlImagen;
                    CargarImagenes();
                }
                else
                {
                    btnEliminarImagen.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        private void CargarImagenes()
        {
            
            if (imagenes.Count > 1)
            {
                btnSiguiente.Enabled = true;
            }
            try
            {
                ptbImagen.Load(imagenes[0].Url);
            }
            catch (Exception ex)
            {
                ptbImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
            finally
            {
                indice++;
            }
        }   

        private void CargarImagenes(bool i)
        {
            
                try
                {
                    if (i == false)
                        indice--;
                    else
                        indice++;
                    if (indice > imagenes.Count-1)
                        {
                            indice = imagenes.Count - 1;
                        }
                   ptbImagen.Load(imagenes[indice].Url);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (indice >= imagenes.Count-1)
                    
                       btnSiguiente.Enabled = false;
                    
                    else 
                        btnSiguiente.Enabled = true;
                     

                    if (indice > 0)
                    
                    btnAnterior.Enabled = true;
                    
                    else
                    
                    btnAnterior.Enabled = false;
                       

                }
        }

        

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CargarImagenes(true);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            Imagen nueva = new Imagen();
            ArticuloNegocio negocio = new ArticuloNegocio();
            string agregada;
            agregada = txtImagen.Text;
            if(agregada.Length == 0)
            {
                MessageBox.Show("Ingrese una URL antes de seleccionar el boton de agregar Imagen");
            }
            else
            {
                try
                {
                    nueva.Url = agregada;
                    nueva.IdArticulo = articulo.Id;
                    imagenes.Add(nueva);
                    negocio.InsertarImagenes(nueva,articulo.Id);
                    txtImagen.Text = string.Empty;
                    MessageBox.Show("Imagen Agregada");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            CargarImagenes(false);
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            
        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                
                if (!ValidarDatos())
                {
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Precio = Decimal.Parse(txtPrecio.Text);
                    articulo.NombreMarca = (Marca)cmbMarcas.SelectedItem;
                    articulo.TipoCategoria = (Categoria)cmbCategorias.SelectedItem;
                    negocio.modificarArticulo(articulo);
                }
                else
                {
                    MessageBox.Show("Faltan datos por ingresar o estan mal cargados");
                    return;
                }
                MessageBox.Show("Articulo Modificado");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }


        private bool ValidarDatos()
        {
            if(cmbCategorias.SelectedIndex <0)
            
                return true;
            
            
            if(cmbMarcas.SelectedIndex < 0)
            
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
