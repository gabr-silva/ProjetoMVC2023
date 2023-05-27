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
    class CadastrarDAL
    {
        public bool Cadastrar_DAL(CadastrarDTO dadosCadastrar)
        {
            //conectar ao BD

            // criar a conexão
            MySqlConnection conn = UtilsDAL.GetConnection();
            try
            {

                // testar se deu ok na conexão
                if (conn.State == ConnectionState.Open)
                {
                    // pesquisar o id do nível
                    string sqlId = $"select id_nivel from nivel where " +
                    $"nome = '{dadosCadastrar.Nivel}'";

                    MySqlCommand retornoId = new MySqlCommand(sqlId, conn);

                    MySqlDataReader readerId = retornoId.ExecuteReader();

                    if (readerId.Read())
                    {
                        int id = (int)readerId[0];
                        readerId.Close(); // fechar / encerrar o componente pois ele carrega a conexão com o BD

                        MessageBox.Show(id.ToString());

                        // salvar no bd o usuario
                        string sql = $"INSERT INTO usuarios (nome, email, senha, nivel) " +
                        $"VALUES ('{dadosCadastrar.Nome}', " +
                        $"'{dadosCadastrar.Email}', " +
                        $"'{dadosCadastrar.Senha}', " +
                        $"'{id}')";
                        MySqlCommand retorno = new MySqlCommand(sql, conn);

                        MySqlDataReader reader = retorno.ExecuteReader();

                        // conn.Close();

                    }

                }
            }
            catch (Exception error)
            {
                {

                    MessageBox.Show("Erro ao Cadastrar " + error.Message);

                    //conn.Close();

                    return false;

                }
            }finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
