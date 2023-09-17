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
                cmbCategorias.DataSource = listadoCategorias.Listar();
                if (articulo.UrlImagen != null)
                {
                    advertencia.Text = string.Empty;
                    imagenes = articulo.UrlImagen;
                    CargarImagenes();
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
                MessageBox.Show(ex.ToString());
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
                            btnSiguiente.Enabled = false;
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

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CargarImagenes(true);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            CargarImagenes(false);
        }
    }
}
