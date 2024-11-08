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
    public partial class Frm_Busca : Form
    {

        private List<List<string>> _listaBusca = new List<List<string>>();

        public string idSelect { get; set; }

        public Frm_Busca(List<List<string>> listaBusca)
        {
            InitializeComponent();
            this.Text = "Busca";
            _listaBusca = listaBusca;
            Tls_Principal.Items[0].ToolTipText = "Salvar a seleção";
            Tls_Principal.Items[1].ToolTipText = "Fechar a seleção";
            PreencherLista();
        }

        private void apagaToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PreencherLista()
        {
            Lst_Busca.Items.Clear();
            for (int i = 0; i < _listaBusca.Count; i++)
            {
                Lst_Busca.Items.Add(_listaBusca[i][1]);

            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            idSelect = _listaBusca[Lst_Busca.SelectedIndex][0];
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
