using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC2023.DAL
{
    class UtilsDAL
    {
        public static MySqlConnection GetConnection()

        {

            // objeto "builder" que contém dados de conexão

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder

            {

                Server = "localhost",

                Database = "cad_usuarios",

                UserID = "root",

                Password = "",

                Port = 3307

            };

            // criar a conexão

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            connection.Open();

            return connection;

        }
    }
}
