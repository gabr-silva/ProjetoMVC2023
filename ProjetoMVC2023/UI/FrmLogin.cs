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

namespace ProjetoMVC2023
{
    public partial class FrmLogin : Form
    {
        LoginDTO usuario = new LoginDTO();
        LoginBLL Login = new LoginBLL();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            usuario.Nome = txtBoxNome.Text;
            usuario.Senha = txtBoxSenha.Text;

            bool retorno = Login.GetLoginBLL(usuario);


            if (retorno)
            {
                MessageBox.Show("Acessando Sistema");
            }
            else
            {
                MessageBox.Show("Nome e Senha invalido");
            }
        }
    }
}
