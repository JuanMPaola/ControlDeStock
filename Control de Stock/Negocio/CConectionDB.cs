using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class CConectionDB
    {
        SqlConnection conex = new SqlConnection();

        static string servidor = "C2_15";
        static string bd = "Otra";
        
        string cadenaConexion = "Data Source=" + servidor +";" + "Initial Catalog=" + bd + ";" + "Integrated Security =true";

        public bool establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("No se logró conectar a la Base de Datos: " + e.ToString());
                return false;
            }
        }

        public DataSet traerTabla()
        {
            var consulta = "SELECT * FROM detalle"; // Asegúrate de que esta consulta sea correcta
            var adaptador = new SqlDataAdapter(consulta, conex);

            var commandBuilder = new SqlCommandBuilder(adaptador);
            var ds = new DataSet();
            adaptador.Fill(ds);

            return ds;
        }


    }
}