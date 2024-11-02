using System;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_HelloWord : Form
    {
        public Frm_HelloWord()
        {
            InitializeComponent();
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_ModificaLabel_Click(object sender, EventArgs e)
        {
            lbl_Titulo.Text = Txt_ConteudoLabel.Text;
        }
    }
}
