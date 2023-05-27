using MySqlConnector;
using ProjetoMVC2023.BLL;
using ProjetoMVC2023.DAL;
using ProjetoMVC2023.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMVC2023.UI
{
    public partial class FrmCadastrarUsuario : Form
    {
        public FrmCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarDTO dadosCadastrar = new CadastrarDTO
            {
                Nome = txtNome.Text,

                Email = txtEmail.Text,

                Senha = txtSenha.Text,

                Nivel = cmbNivel.Text,

                ConfirSenha = txtConfirSenha.Text,
            };
            // chamar o controle

            CadastrarBLL cadastrar = new CadastrarBLL();

            bool retorno = cadastrar.GetCadastrarBLL(dadosCadastrar);
            if (retorno)
            {
                MessageBox.Show("Cadastro OK");

                // carregar o FrmMenu criando primeiro um obj

                //FrmMenu frmMenu = new FrmMenu();

                // Carregar o menu na tela

                //frmMenu.Show();

                // ocultar o FrmLogin

                //this.Hide();

            }
            else
            {
                MessageBox.Show("Erro de Cadastro");
            }
        }

        private void FrmCadastrarUsuario_Load(object sender, EventArgs e)
        {
            // conectar ao banco
            var conn = UtilsDAL.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    // definimos a variável sql com a query de inserção de dados
                    string sql = $"SELECT * FROM nivel";
                   
                    MySqlCommand comando = new MySqlCommand(sql, conn);
                    
                    MySqlDataReader data = comando.ExecuteReader();

                    //cria uma tabela com os dados
                    DataTable table = new DataTable();

                    //carrega a tabela
                    table.Load(data);

                    //informa qual ira ser mostrada
                    cmbNivel.DisplayMember = "nome";

                    cmbNivel.DataSource = table;

                    // Fecha a conexão com o banco
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco de dados FormCadastrarUsuario! {ex.Message}");
            }
        }
    }
}
