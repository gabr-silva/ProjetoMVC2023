using ProjetoMVC2023.DTO;
using ProjetoMVC2023.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoMVC2023.UI;

namespace ProjetoMVC2023
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            LoginDTO dadosLogin = new LoginDTO

            {
                Email = "admin@gmail.com",

                Senha = "admin"

            };

            // chamar o controle

            LoginBLL login = new LoginBLL();

            bool retorno = login.GetLoginBLL(dadosLogin);

            if (retorno)

            {
                // carregar o Formulario de menu

                FrmMenu frmMenu = new FrmMenu();
                frmMenu.Show();

                // ocultar o Formulario login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Erro de Login");
            }
        }
    }
}
