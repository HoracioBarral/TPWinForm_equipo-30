using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            datos.SetConsulta("select a.id,a.Codigo,a.Nombre,a.Descripcion,a.Precio,c.Descripcion Tipo,m.Descripcion Marca from articulos a left join categorias c on a.IdCategoria=c.Id inner join marcas m on a.IdMarca=m.Id");
            try
            {
                datos.Consulta_A_DB();
                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Precio = (decimal)datos.Lector["Precio"];
                    art.TipoCategoria = new Categoria();

                    if (!(datos.Lector["Tipo"] is DBNull))
                    {
                        art.TipoCategoria.Descripcion = (string)datos.Lector["Tipo"];
                    }
                    else
                        art.TipoCategoria.Descripcion = "No tiene";

                    art.NombreMarca = new Marca();
                    art.NombreMarca.Descripcion = (string)datos.Lector["Marca"];
                    art.Url = new List<Imagen>();
                    art.Url = obtenerImagenes(art.Id);
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
            datos2.SetConsulta("select i.id,i.imagenUrl,a.Id articulo from imagenes i, articulos a where a.Id=i.IdArticulo");
            try
            {
                datos2.Consulta_A_DB();
                while (datos2.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    int articulo = (int)datos2.Lector["articulo"];
                    if (articulo==id)
                    {
                        aux.Id = (int)datos2.Lector["id"];
                        aux.IdArticulo = articulo;
                        aux.UrlImagen = (string)datos2.Lector["imagenUrl"];
                        imagenes.Add(aux);
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
