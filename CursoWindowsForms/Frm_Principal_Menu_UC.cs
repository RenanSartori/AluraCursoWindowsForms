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
    public partial class Frm_Principal_Menu_UC : Form
    {

        int ControleHelloWorld = 0;
        int ControleDemosntracaoKey = 0;
        int ControleMascara = 0;
        int ControleValidaCPF = 0;
        int ControleValidaCPF2 = 0;
        int ControleValidaSenha = 0;



        public Frm_Principal_Menu_UC()
        {
            InitializeComponent();
        }
        private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleDemosntracaoKey++;
            UserControl u = new Frm_DemonstracaoKey_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Demonstração Key" + ControleDemosntracaoKey;
            tb.Text = "Demonstração Key" + ControleDemosntracaoKey;
            tb.ImageIndex = 0;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);

        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleHelloWorld++;
            UserControl  u = new Frm_HelloWorld_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Hello World" + ControleHelloWorld;
            tb.Text = "Hello World" + ControleHelloWorld;
            tb.ImageIndex = 1;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);
            
        }

        private void máscaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleMascara++;
            UserControl u = new Frm_Mascara_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Máscara" + ControleMascara;
            tb.Text = "Máscara" + ControleMascara;
            tb.ImageIndex = 2;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);
        }

        private void validaCPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleValidaCPF++;
            UserControl u = new Frm_ValidaCPF_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida CPF" + ControleValidaCPF;
            tb.Text = "Valida CPF" + ControleValidaCPF;
            tb.ImageIndex = 3;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);
        }

        private void validaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleValidaCPF2++;
            UserControl u = new Frm_ValidaCPF2_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida CPF 2" + ControleValidaCPF2;
            tb.Text = "Valida CPF 2" + ControleValidaCPF2;
            tb.ImageIndex = 4;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);
        }

        private void validaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleValidaSenha++;
            UserControl u = new Frm_ValidaSenha_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida Senha" + ControleValidaSenha;
            tb.Text = "Valida Senha" + ControleValidaSenha;
            tb.ImageIndex = 5;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void apagarAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(Tbc_aplicacoes.SelectedTab == null))
            {
                Tbc_aplicacoes.TabPages.Remove(Tbc_aplicacoes.SelectedTab);
            }
        }
    }
}
