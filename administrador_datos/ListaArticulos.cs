using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using moldes_clases;

namespace administrador_datos
{
    public class ListaArticulos
    {
        public List<Articulo> listar()
        {
            List<Articulo> listaArt = new List<Articulo>();
            AccesoDatos datos= new AccesoDatos();
            datos.SetConsulta("select a.id,a.codigo,a.nombre,a.descripcion,a.precio,m.Descripcion marca,c.Descripcion tipo from articulos a, marcas m, categorias c where a.IdMarca=m.Id and a.IdCategoria=c.Id");
            try
            {
                datos.Consulta_A_DB();
                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["id"];
                    art.Codigo = (string)datos.Lector["codigo"];
                    art.Nombre = (string)datos.Lector["nombre"];
                    art.Descripcion = (string)datos.Lector["descripcion"];
                    //art.Precio = (float)datos.Lector["precio"];
                    art.NombreMarca = new Marca();
                    art.NombreMarca.Descripcion = (string)datos.Lector["marca"];
                    art.TipoCategoria = new Categoria();
                    art.TipoCategoria.Descripcion = (string)datos.Lector["tipo"];
                    art.Imagen = new List<Imagen>();
                    art.Imagen=obtenerImagenes(art.Id);
                    listaArt.Add(art);
                }
                return listaArt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            
        }

        public List<Imagen> obtenerImagenes(int id)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos2 = new AccesoDatos();
            datos2.SetConsulta("select i.id,i.imagenUrl,a.Id articulo from imagenes i, articulo a where a.Id=i.IdArticulo ");
            try
            {
                datos2.Consulta_A_DB();
                while (datos2.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    
                    if (datos2.Lector["articulo"].Equals(id))
                    {
                        imagen.Url=(string)datos2.Lector["imagenUrl"];
                        imagenes.Add(imagen);
                    }
                }
                return imagenes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.CerrarConexion();
            }
        }
    }
}
