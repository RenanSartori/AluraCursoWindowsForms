using CursoWindowsFormsBiblioteca;
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
        int ControleArquivoImagem = 0;
        int ControleCadastroClientes = 0;



        public Frm_Principal_Menu_UC()
        {
            InitializeComponent();

            novoToolStripMenuItem.Enabled = false;
            apagarAbaToolStripMenuItem.Enabled = false;
            abrirImagemToolStripMenuItem.Enabled = false;
            desconectarToolStripMenuItem.Enabled = false;
            cadastroToolStripMenuItem.Enabled = false;


        }
        private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleDemosntracaoKey++;
            UserControl u = new Frm_DemonstracaoKey_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Demonstração Key " + ControleDemosntracaoKey;
            tb.Text = "Demonstração Key " + ControleDemosntracaoKey;
            tb.ImageIndex = 0;
            tb.Controls.Add(u);
            Tbc_aplicacoes.TabPages.Add(tb);

        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleHelloWorld++;
            UserControl u = new Frm_HelloWorld_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Hello World " + ControleHelloWorld;
            tb.Text = "Hello World " + ControleHelloWorld;
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
            tb.Name = "Máscara " + ControleMascara;
            tb.Text = "Máscara " + ControleMascara;
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
            tb.Name = "Valida CPF " + ControleValidaCPF;
            tb.Text = "Valida CPF " + ControleValidaCPF;
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
            tb.Name = "Valida CPF 2 " + ControleValidaCPF2;
            tb.Text = "Valida CPF 2 " + ControleValidaCPF2;
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
            tb.Name = "Valida Senha " + ControleValidaSenha;
            tb.Text = "Valida Senha " + ControleValidaSenha;
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
                ApagaAba(Tbc_aplicacoes.SelectedTab);
            }
        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Db = new OpenFileDialog();
            Db.InitialDirectory = "C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\CursoWindowsForms\\Imagens";
            Db.Filter = "PNG|*.PNG";
            Db.Title = "Escolha a Imagem";

            if (Db.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImagem = Db.FileName;


                ControleArquivoImagem++;
                UserControl u = new Frm_ArquivoImagem_UC(nomeArquivoImagem);
                u.Dock = DockStyle.Fill;
                TabPage tb = new TabPage();
                tb.Name = "Arquivo Imagem " + ControleArquivoImagem;
                tb.Text = "Arquivo Imagem " + ControleArquivoImagem;
                tb.ImageIndex = 6;
                tb.Controls.Add(u);
                Tbc_aplicacoes.TabPages.Add(tb);
            }
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {

                string senha = f.senha;
                string login = f.login;

                if (Cls_Uteis.validaSenhaLogin(senha) == true)
                {
                    novoToolStripMenuItem.Enabled = true;
                    apagarAbaToolStripMenuItem.Enabled = true;
                    abrirImagemToolStripMenuItem.Enabled = true;
                    conectarToolStripMenuItem.Enabled = false;
                    desconectarToolStripMenuItem.Enabled = true;
                    cadastroToolStripMenuItem.Enabled = true;
                    MessageBox.Show("Bem vindo " + login + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Senha Inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Questao Db = new Frm_Questao("icons8_question_1001", "Você deseja se desconectar?");
            Db.ShowDialog();

            if (Db.DialogResult == DialogResult.Yes)
            {

                Tbc_aplicacoes.TabPages.Clear();

                novoToolStripMenuItem.Enabled = false;
                apagarAbaToolStripMenuItem.Enabled = false;
                abrirImagemToolStripMenuItem.Enabled = false;
                conectarToolStripMenuItem.Enabled = true;
                desconectarToolStripMenuItem.Enabled = false;
                cadastroToolStripMenuItem.Enabled = false;

            }



        }

        private void Tbc_aplicacoes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //var PosicaoX = (int)e.X;
                //var PosicaoY = (int)e.Y;

                //MessageBox.Show("Direita. A posição relativa foi ("
                //    + PosicaoX.ToString()
                //    + "," + PosicaoY.ToString()
                //    + ")");

                var ContextMenu = new ContextMenuStrip();
                var vToolTip001 = DesenhaItemMenu("Apagar a Aba", "DeleteTab");
                var vToolTip002 = DesenhaItemMenu("Apagar todas a Esquerda", "DeleteLeft");
                var vToolTip003 = DesenhaItemMenu("Apagar todas a Direita", "DeleteRight");
                var vToolTip004 = DesenhaItemMenu("Apagar todas menos esta", "DeleteAll");
                ContextMenu.Items.Add(vToolTip001);
                ContextMenu.Items.Add(vToolTip002);
                ContextMenu.Items.Add(vToolTip003);
                ContextMenu.Items.Add(vToolTip004);
                ContextMenu.Show(this, new Point(e.X, e.Y));
                vToolTip001.Click += new EventHandler(vToolTip001_Click);
                vToolTip002.Click += new EventHandler(vToolTip002_Click);
                vToolTip003.Click += new EventHandler(vToolTip003_Click);
                vToolTip004.Click += new EventHandler(vToolTip004_Click);



            }


        }


        void vToolTip001_Click(object sender1, EventArgs e1)
        {
            if (!(Tbc_aplicacoes.SelectedTab == null))
            {
                ApagaAba(Tbc_aplicacoes.SelectedTab);
            }
        }

        void vToolTip002_Click(object sender1, EventArgs e1)
        {
            if (!(Tbc_aplicacoes.SelectedTab == null))
            {
                ApagaEsquerda(Tbc_aplicacoes.SelectedIndex);
            }
        }

        void vToolTip003_Click(object sender1, EventArgs e1)
        {
            if (!(Tbc_aplicacoes.SelectedTab == null))
            {
                ApagaDireita(Tbc_aplicacoes.SelectedIndex);
            }
        }
        void vToolTip004_Click(object sender1, EventArgs e1)
        {
            if (!(Tbc_aplicacoes.SelectedTab == null))
            {
                ApagaEsquerda(Tbc_aplicacoes.SelectedIndex);
                ApagaDireita(Tbc_aplicacoes.SelectedIndex);
            }
        }


        ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var vToolTip = new ToolStripMenuItem();
            vToolTip.Text = text;

            Image myImage = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);

            vToolTip.Image = myImage;

            return vToolTip;
        }

        void ApagaDireita(int itemSelecionado)
        {
            for (int i = Tbc_aplicacoes.TabCount - 1; i > itemSelecionado; i--)
            {
                ApagaAba(Tbc_aplicacoes.TabPages[i]);
            }
        }

        void ApagaEsquerda(int itemSelecionado)
        {
            for (int i = itemSelecionado - 1; i >= 0; i--)
            {
                ApagaAba(Tbc_aplicacoes.TabPages[i]);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControleCadastroClientes == 0)
            {
                ControleCadastroClientes++;
                UserControl u = new Frm_CadastroClientes_UC();
                u.Dock = DockStyle.Fill;
                TabPage tb = new TabPage();
                tb.Name = "Cadastro de Clientes";
                tb.Text = "Cadastro de Clientes";
                tb.ImageIndex = 7;
                tb.Controls.Add(u);
                Tbc_aplicacoes.TabPages.Add(tb);
            }
            else
            {
                MessageBox.Show("Não posso abrir o Cadastro de Clientes porque já está aberto!",
                    "Banco ByteBank", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            

        }

        void ApagaAba(TabPage tb)
        {
            if (tb.Name == "Cadastro de Clientes")
            {
                ControleCadastroClientes = 0;
            }
            Tbc_aplicacoes.TabPages.Remove(tb);
        }


    }

}
