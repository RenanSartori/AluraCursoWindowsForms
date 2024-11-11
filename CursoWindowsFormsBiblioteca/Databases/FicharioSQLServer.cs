using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class FicharioSQLServer
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public SQLServerClass db;

        public FicharioSQLServer(string tabela)
        {
            this.tabela = tabela;
            status = true;

            try
            {
                db = new SQLServerClass();
                mensagem = "Conexão com a tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com a tabela com erro: " + ex.Message;
            }
        }


        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                //INSERT INTO CLIENTE (ID, JSON) VALUES (id, jsonUnit);

                var sql = "INSERT INTO " + tabela + " (ID, JSON) VALUES ('" + id + "','" + jsonUnit + "')";
                db.SQLCommand(sql);

                status = true;
                mensagem = "Inclusão efetuada com sucesso. Identificador: " + id;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro: " + ex.Message;
            }

        }


        public string Buscar(string id)
        {
            status = true;
            try
            {
                var sql = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + id + "'";

                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = "Conteúdo lido com com sucesso. Identificador: " + id;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existente: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";

        }


        public List<string> BuscarTodos()
        {
            status = true;
            List<string> list = new List<string>();
            try
            {
                var sql = "SELECT ID, JSON FROM " + tabela;

                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        list.Add(conteudo);
                    }

                    return list;

                }
                else
                {
                    status = false;
                    mensagem = "Não existem clientes na base de dados";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar clientes na base de dados: " + ex.Message;
            }
            return list;
        }

        public void Apagar(string id)
        {
            status = true;
            try
            {

                var sql = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + id + "'";

                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    sql = "DELETE FROM " + tabela + " WHERE ID = '" + id + "'";
                    db.SQLCommand(sql);
                    status = true;
                    mensagem = "Exlusão efetuada com sucesso. Identificador: " + id;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existente: " + id;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }

        public void Alterar(string id, string jsonUnit)
        {
            status = true;
            try
            {

                var sql = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + id + "'";

                var dt = db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    sql = "UPDATE " + tabela + " SET JSON = '" + jsonUnit + "' WHERE ID = '" + id + "'";
                    db.SQLCommand(sql);
                    status = true;
                    mensagem = "Alteração efetuada com sucesso. Identificador: " + id;
                }
                else
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o identificador não existe:" + id;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro: " + ex.Message;
            }

        }



    }
}
