using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Btn_DemonstracaoKey_Click(object sender, EventArgs e)
        {
            Form f = new Frm_DemonstracaoKey();
            f.ShowDialog();
        }

        private void Btn_HelloWorld_Click(object sender, EventArgs e)
        {
            Form f = new Frm_HelloWord();
            f.ShowDialog();
        }

        private void Btn_Mascara_Click(object sender, EventArgs e)
        {
            Form f = new Frm_Mascara();
            f.ShowDialog();
        }

        private void Btn_ValidaCPF_Click(object sender, EventArgs e)
        {
            Form f = new Frm_ValidaCPF();
            f.ShowDialog();
        }

        private void Btn_ValidaCPF2_Click(object sender, EventArgs e)
        {
            Form f = new Frm_ValidaCPF2();
            f.ShowDialog();
        }

        private void Btn_ValidaSenha_Click(object sender, EventArgs e)
        {
            Form f = new Frm_ValidaSenha();
            f.ShowDialog();
        }
    }
}
