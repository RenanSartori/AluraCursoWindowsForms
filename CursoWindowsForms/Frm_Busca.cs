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
            Lst_Busca.Sorted = true;
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
                ItemBox x = new ItemBox();
                x.id = _listaBusca[i][0];
                x.nome = _listaBusca[i][1];

                Lst_Busca.Items.Add(x);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            ItemBox itemSelecionado = (ItemBox)Lst_Busca.SelectedItem;
            if (itemSelecionado != null)
            {
                idSelect = itemSelecionado.id;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ItemBox
        {
            public string id { get; set; }
            public string nome { get; set; }

            public override string ToString()
            {
                return nome;
            }

        }
    }
}
