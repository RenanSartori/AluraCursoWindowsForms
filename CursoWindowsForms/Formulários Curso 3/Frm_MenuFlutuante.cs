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
    public partial class Frm_MenuFlutuante : Form
    {
        public Frm_MenuFlutuante()
        {
            InitializeComponent();
        }

        private void Frm_MenuFlutuante_MouseDown(object sender, MouseEventArgs e)
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
                var vToolTip001 = DesenhaItemMenu("Item menu 1", "key");
                var vToolTip002 = DesenhaItemMenu("Item menu 2", "Frm_ValidaSenha");
                ContextMenu.Items.Add(vToolTip001);
                ContextMenu.Items.Add(vToolTip002); 
                ContextMenu.Show(this, new Point(e.X, e.Y));
                vToolTip001.Click += new EventHandler(vToolTip001_Click);
                vToolTip002.Click += new EventHandler(vToolTip002_Click);



            }

            void vToolTip001_Click(object sender1, EventArgs e1)
            {
                MessageBox.Show("Selecionei o menu 1");
            }

            void vToolTip002_Click(object sender1, EventArgs e1)
            {
                MessageBox.Show("Selecionei o menu 2");
            }


            ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
            {
                var vToolTip = new ToolStripMenuItem();
                vToolTip.Text = text;
                
                Image myImage = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);

                vToolTip.Image = myImage;

                return vToolTip;
            }

        }
    }
}
