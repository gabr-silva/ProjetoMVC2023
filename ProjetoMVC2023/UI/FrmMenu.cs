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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastrarUsuario frmCadastrarUsuario = new FrmCadastrarUsuario();
            frmCadastrarUsuario.Show();
            this.Hide();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAjuda frmAjuda = new FrmAjuda();
            frmAjuda.Show();
            this.Hide();
        }
    }
}
