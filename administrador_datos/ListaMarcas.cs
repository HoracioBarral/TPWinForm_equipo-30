using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moldes_clases;

namespace administrador_datos
{
    public class ListaMarcas
    {
        public void Listar()
        {
            List<Marca> listadoMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            datos.SetConsulta("select id,Descripcion from marcas");

            datos.Consulta_A_DB();
            while (datos.Lector != null)
            {
                Marca marca = new Marca();
                marca.Id = (int)datos.Lector["id"];
                marca.Descripcion = (string)datos.Lector["Descripcion"];
            }
        }

    }
}
