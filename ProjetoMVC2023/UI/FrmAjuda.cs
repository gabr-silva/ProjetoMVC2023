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
    public partial class FrmAjuda : Form
    {
        public FrmAjuda()
        {
            InitializeComponent();
        }

        private void FrmAjuda_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form frmAberto in Application.OpenForms)
            {
                if (frmAberto is FrmMenu)
                {
                    frmAberto.Show();
                    break;
                }

            }
        }
    }
}
