using MySqlConnector;
using ProjetoMVC2023.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMVC2023.DAL
{
    class LoginDAL
    {
        //verificar o login no bd
        public bool GetLoginDAL(LoginDTO dadosLogin)
        {
            //conectar ao BD
            try
            {
                // criar a conexão
                MySqlConnection conn = UtilsDAL.GetConnection();

                // testar se deu ok na conexão
                if (conn.State == ConnectionState.Open)
                {
                    // pesquisar no banco se o usuario existe
                    string sql = $"SELECT * FROM usuarios WHERE " +
                    $"email = '{dadosLogin.Email}' " +
                    $"AND senha = '{dadosLogin.Senha}'";

                    MySqlCommand retorno = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = retorno.ExecuteReader();

                    if (reader.Read())
                    {
                        conn.Close();
                        return true;
                    }
                    conn.Close();
                    return false;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no Login" + erro.Message);
                return false;
            }
            return false;
        }
    }    
}

