﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsFormsBiblioteca.Classes;
using CursoWindowsFormsBiblioteca.Databases;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using CursoWindowsFormsBiblioteca;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace CursoWindowsForms
{
    public partial class Frm_CadastroClientes_UC : UserControl
    {
        public Frm_CadastroClientes_UC()
        {
            InitializeComponent();

            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Outros.Text = "Outros";
            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Lbl_Cidade.Text = "Cidade";
            Chk_TemPai.Text = "Pai desconhecido";
            Rdb_Feminino.Text = "Feminino";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Indefinido.Text = "Indefinido";
            Grp_Genero.Text = "Gênero";
            Btn_Busca.Text = "Buscar";
            Grp_DataGrid.Text = "Clientes";


            Cmb_Estados.Items.Clear();
            Cmb_Estados.Items.Add("Acre (AC)");
            Cmb_Estados.Items.Add("Alagoas(AL)");
            Cmb_Estados.Items.Add("Amapá(AP)");
            Cmb_Estados.Items.Add("Amazonas(AM)");
            Cmb_Estados.Items.Add("Bahia(BA)");
            Cmb_Estados.Items.Add("Ceará(CE)");
            Cmb_Estados.Items.Add("Distrito Federal(DF)");
            Cmb_Estados.Items.Add("Espírito Santo(ES)");
            Cmb_Estados.Items.Add("Goiás(GO)");
            Cmb_Estados.Items.Add("Maranhão(MA)");
            Cmb_Estados.Items.Add("Mato Grosso(MT)");
            Cmb_Estados.Items.Add("Mato Grosso do Sul(MS)");
            Cmb_Estados.Items.Add("Minas Gerais(MG)");
            Cmb_Estados.Items.Add("Pará(PA)");
            Cmb_Estados.Items.Add("Paraíba(PB)");
            Cmb_Estados.Items.Add("Paraná(PR)");
            Cmb_Estados.Items.Add("Pernambuco(PE)");
            Cmb_Estados.Items.Add("Piauí(PI)");
            Cmb_Estados.Items.Add("Rio de Janeiro(RJ)");
            Cmb_Estados.Items.Add("Rio Grande do Norte(RN)");
            Cmb_Estados.Items.Add("Rio Grande do Sul(RS)");
            Cmb_Estados.Items.Add("Rondônia(RO)");
            Cmb_Estados.Items.Add("Roraima(RR)");
            Cmb_Estados.Items.Add("Santa Catarina(SC)");
            Cmb_Estados.Items.Add("São Paulo(SP)");
            Cmb_Estados.Items.Add("Sergipe(SE)");
            Cmb_Estados.Items.Add("Tocantins(TO)");


            Tls_Principal.Items[0].ToolTipText = "Incluir na base de dados um novo cliente";
            Tls_Principal.Items[1].ToolTipText = "Capturar um cliente já cadastrado";
            Tls_Principal.Items[2].ToolTipText = "Atualizar cliente existente";
            Tls_Principal.Items[3].ToolTipText = "Apagar cliente selecionado";
            Tls_Principal.Items[4].ToolTipText = "Limpa dados na tela de entrada de dados";

            LimparFormulario();
            AtualizaGrid();
        }


        private void LimparFormulario()
        {
            Txt_Bairro.Text = "";
            Txt_CEP.Text = "";
            Txt_Complemento.Text = "";
            Txt_CPF.Text = "";
            Cmb_Estados.SelectedIndex = -1;
            Txt_Logradouro.Text = "";
            Txt_NomeCliente.Text = "";
            Txt_NomeMae.Text = "";
            Txt_NomePai.Text = "";
            Txt_Profissao.Text = "";
            Txt_RendaFamiliar.Text = "";
            Txt_Telefone.Text = "";
            Txt_Cidade.Text = "";
            Txt_Codigo.Text = "";
            Chk_TemPai.Checked = false;
            Rdb_Masculino.Checked = true;
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_TemPai.Checked == true)
            {
                Txt_NomePai.Enabled = false;
            }
            else
            {
                Txt_NomePai.Enabled = true;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit C = new Cliente.Unit();
                C = LeituraFormulario();
                C.ValidaClasse();
                C.ValidaComplemento();
                //C.IncluirFichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                //C.IncluirFicharioDB("Cliente");
                //C.IncluirFicharioSQL("Cliente");
                C.IncluirFicharioSQLRel();
                MessageBox.Show("OK: Identificador incluído com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizaGrid();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código do Cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit c = new Cliente.Unit();
                    //c = c.BuscarFichario(Txt_Codigo.Text, "C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                    //c = c.BuscarFicharioDB(Txt_Codigo.Text, "Cliente");
                    //c = c.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                    c = c.BuscarFicharioSQLRel(Txt_Codigo.Text);
                    EscreveFormulario(c);

                    //Fichario f = new Fichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                    //if (f.status)
                    //{
                    //    string clienteJson = f.Buscar(Txt_Codigo.Text);
                    //    if (f.status)
                    //    {
                    //        Cliente.Unit c = new Cliente.Unit();
                    //        c = Cliente.DesSerializedClassUnit(clienteJson);
                    //        EscreveFormulario(c);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }

                    //}
                    //else
                    //{
                    //    MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código do Cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit C = new Cliente.Unit();
                    C = LeituraFormulario();
                    C.ValidaClasse();
                    C.ValidaComplemento();
                    //C.AlterarFichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                    //C.AlterarFicharioDB("Cliente");
                    //C.AlterarFicharioSQL("Cliente");
                    C.AlterarFicharioSQLRel();
                    MessageBox.Show("OK: Identificador alterado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizaGrid();

                    //string clienteJson = Cliente.SerializedClassUnit(C);

                    //Fichario f = new Fichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");

                    //if (f.status)
                    //{
                    //    f.Alterar(C.Id, clienteJson);
                    //    if (f.status)
                    //    {

                    //        MessageBox.Show("OK: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //    }

                    //}
                    //else
                    //{
                    //    MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }



        }

        private void apagaToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código do Cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    Cliente.Unit c = new Cliente.Unit();
                    //c = c.BuscarFichario(Txt_Codigo.Text, "C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                    //c = c.BuscarFicharioDB(Txt_Codigo.Text, "Cliente");
                    //c = c.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                    c = c.BuscarFicharioSQLRel(Txt_Codigo.Text);
                    EscreveFormulario(c);
                    Frm_Questao Db = new Frm_Questao("icons8_question_1001", "Você quer excluir o cliente?");
                    Db.ShowDialog();
                    if (Db.DialogResult == DialogResult.Yes)
                    {
                        //c.ApagarFichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                        //c.ApagarFicharioDB("Cliente");
                        //c.ApagarFicharioSQL("Cliente");
                        c.ApagarFicharioSQLRel();
                        MessageBox.Show("OK: Identificador apagado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFormulario();
                        AtualizaGrid();
                    }

                    //Fichario f = new Fichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                    //if (f.status)
                    //{
                    //    string clienteJson = f.Buscar(Txt_Codigo.Text);
                    //    if (f.status)
                    //    {
                    //        Cliente.Unit c = new Cliente.Unit();
                    //        c = Cliente.DesSerializedClassUnit(clienteJson);
                    //        EscreveFormulario(c);
                    //        Frm_Questao Db = new Frm_Questao("icons8_question_1001", "Você quer excluir o cliente?");
                    //        Db.ShowDialog();
                    //        if (Db.DialogResult == DialogResult.Yes)
                    //        {

                    //            f.Apagar(Txt_Codigo.Text);
                    //            if (f.status)
                    //            {
                    //                MessageBox.Show("OK: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                LimparFormulario();
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limparToolStripButton1_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit C = new Cliente.Unit();
            C.Id = Txt_Codigo.Text;
            C.Nome = Txt_NomeCliente.Text;
            C.NomeMae = Txt_NomeMae.Text;
            C.NomePai = Txt_NomePai.Text;
            if (Chk_TemPai.Checked)
            {
                C.NaoTemPai = true;
            }
            else
            {
                C.NaoTemPai = false;
            }
            if (Rdb_Masculino.Checked)
            {
                C.Genero = 0;
            }
            if (Rdb_Feminino.Checked)
            {
                C.Genero = 1;
            }
            if (Rdb_Indefinido.Checked)
            {
                C.Genero = 2;
            }
            C.Cpf = Txt_CPF.Text;
            C.Cep = Txt_CEP.Text;
            C.Logradouro = Txt_Logradouro.Text;
            C.Complemento = Txt_Complemento.Text;
            C.Cidade = Txt_Cidade.Text;
            C.Bairro = Txt_Bairro.Text;
            if (Cmb_Estados.SelectedIndex < 0)
            {
                C.Estado = "";
            }
            else
            {
                C.Estado = Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString();
            }
            C.Telefone = Txt_Telefone.Text;
            C.Profissao = Txt_Profissao.Text;

            if (Information.IsNumeric(Txt_RendaFamiliar.Text))
            {
                double vRenda = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if (vRenda < 0)
                {
                    C.RendaFamiliar = 0;
                }
                else
                {
                    C.RendaFamiliar += vRenda;
                }
            }
            return C;
        }

        private void EscreveFormulario(Cliente.Unit C)
        {
            Txt_Codigo.Text = C.Id;
            Txt_NomeCliente.Text = C.Nome;
            Txt_NomeMae.Text = C.NomeMae;

            if (C.NaoTemPai)
            {
                Chk_TemPai.Checked = true;
                Txt_NomePai.Text = "";
            }
            else
            {
                Chk_TemPai.Checked = false;
                Txt_NomePai.Text = C.NomePai;
            }

            if (C.Genero == 0)
            {
                Rdb_Masculino.Checked = true;
            }
            if (C.Genero == 1)
            {
                Rdb_Feminino.Checked = true;
            }
            if (C.Genero == 2)
            {
                Rdb_Indefinido.Checked = true;
            }

            Txt_CPF.Text = C.Cpf;
            Txt_CEP.Text = C.Cep;
            Txt_Logradouro.Text = C.Logradouro;
            Txt_Complemento.Text = C.Complemento;
            Txt_Cidade.Text = C.Cidade;
            Txt_Bairro.Text = C.Bairro;



            if (C.Estado == "")
            {
                C.Estado = "";
                Cmb_Estados.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i < Cmb_Estados.Items.Count - 1; i++)
                {
                    if (C.Estado == Cmb_Estados.Items[i].ToString())
                    {
                        Cmb_Estados.SelectedIndex = i;
                    }
                }
            }

            Txt_Telefone.Text = C.Telefone;
            Txt_Profissao.Text = C.Profissao;
            Txt_RendaFamiliar.Text = C.RendaFamiliar.ToString();
        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            string vCep = Txt_CEP.Text;
            if (vCep != "")
            {
                if (vCep.Length == 8)
                {
                    if (Information.IsNumeric(vCep))
                    {
                        var vJson = Cls_Uteis.GeraJSONCEP(vCep);
                        Cep.Unit CEP = new Cep.Unit();
                        CEP = Cep.DesSerializedClassUnit(vJson);
                        Txt_Logradouro.Text = CEP.logradouro;
                        Txt_Bairro.Text = CEP.bairro;
                        Txt_Cidade.Text = CEP.localidade;

                        Cmb_Estados.SelectedIndex = -1;

                        for (int i = 0; i < Cmb_Estados.Items.Count; i++)
                        {
                            var vPos = Strings.InStr(Cmb_Estados.Items[i].ToString(), "(" + CEP.uf + ")");
                            if (vPos > 0)
                            {
                                Cmb_Estados.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Btn_Busca_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                List<string> list = new List<string>();
                //list = c.ListarFicharios("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                //list = c.ListarFichariosDB("Cliente");
                //list = c.ListarFichariosSQL("Cliente");
                var listaBusca = c.ListarFichariosSQLRel();
                //for (int i = 0; i < list.Count; i++)
                //{
                //    c = Cliente.DesSerializedClassUnit(list[i]);
                //    listaBusca.Add(new List<string> { c.Id, c.Nome });

                //}
                Frm_Busca fForm = new Frm_Busca(listaBusca);
                fForm.ShowDialog();

                if (fForm.DialogResult == DialogResult.OK)
                {
                    var idSelect = fForm.idSelect;

                    //c = c.BuscarFichario(idSelect, "C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
                    //c = c.BuscarFicharioDB(idSelect, "Cliente");
                    //c = c.BuscarFicharioSQL(idSelect, "Cliente");
                    c = c.BuscarFicharioSQLRel(idSelect);

                    EscreveFormulario(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            //Fichario f = new Fichario("C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\Fichario");
            //if (f.status)
            //{
            //    List<string> list = new List<string>();
            //    list = f.BuscarTodos();
            //    if (f.status)
            //    {
            //        List<List<string>> listaBusca = new List<List<string>>();
            //        for (int i = 0; i < list.Count; i++)
            //        {
            //            Cliente.Unit c = Cliente.DesSerializedClassUnit(list[i]);
            //            listaBusca.Add(new List<string> { c.Id, c.Nome });

            //        }
            //        Frm_Busca fForm = new Frm_Busca(listaBusca);
            //        fForm.ShowDialog();


            //        if (fForm.DialogResult == DialogResult.OK)
            //        {
            //            var idSelect = fForm.idSelect;

            //            string clienteJson = f.Buscar(idSelect);
            //            if (f.status)
            //            {
            //                Cliente.Unit c = new Cliente.Unit();
            //                c = Cliente.DesSerializedClassUnit(clienteJson);
            //                EscreveFormulario(c);
            //            }
            //            else
            //            {
            //                MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }



            //}
            //else
            //{
            //    MessageBox.Show("ERR: " + f.mensagem, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



        }

        private void AtualizaGrid()
        {
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                Dg_Clientes.Rows.Clear();
                var listaBusca = c.ListarFichariosSQLRel();
                for (int i = 0; i < listaBusca.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(Dg_Clientes);
                    row.Cells[0].Value = listaBusca[i][0].ToString();
                    row.Cells[1].Value = listaBusca[i][1].ToString();
                    Dg_Clientes.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dg_Clientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = Dg_Clientes.SelectedRows[0];
                string id = row.Cells[0].Value.ToString();

                Cliente.Unit c = new Cliente.Unit();
                c = c.BuscarFicharioSQLRel(id);
                EscreveFormulario(c);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
