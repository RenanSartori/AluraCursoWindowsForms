using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class Fichario
    {
        public string diretorio;
        public string mensagem;
        public bool status;

        public Fichario(string diretorio)
        {
            status = true;
            try
            {
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                this.diretorio = diretorio;
                mensagem = "Conexão com o fichario criada com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro: " + ex.Message;
            }
        }


        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                if (File.Exists(diretorio + "\\" + id + ".json"))
                {
                    status = false;
                    mensagem = "Inclusão não permitida porque o identificador já existe:" + id;
                }
                else
                {
                    File.WriteAllText(diretorio + "\\" + id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. Identificador: " + id;
                }

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
                if (!File.Exists(diretorio + "\\" + id + ".json"))
                {
                    status = false;
                    mensagem = "Identificador não existente: " + id;
                    return "";
                }
                else
                {
                    string conteudo = File.ReadAllText(diretorio + "\\" + id + ".json");
                    status = true;
                    mensagem = "Conteúdo lido com com sucesso. Identificador: " + id;
                    return conteudo;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";

        }

        public void Apagar(string id)
        {
            status = true;
            try
            {
                if (!File.Exists(diretorio + "\\" + id + ".json"))
                {
                    status = false;
                    mensagem = "Identificador não existente: " + id;
                }
                else
                {
                    File.Delete(diretorio + "\\" + id + ".json");
                    status = true;
                    mensagem = "Exlusão efetuada com sucesso. Identificador: " + id;
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
                if (!File.Exists(diretorio + "\\" + id + ".json"))
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o identificador não existe:" + id;
                }
                else
                {
                    File.Delete(diretorio + "\\" + id + ".json");
                    File.WriteAllText(diretorio + "\\" + id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Alteração efetuada com sucesso. Identificador: " + id;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro: " + ex.Message;
            }

        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> list = new List<string>();
            try
            {
                var arquivos = Directory.GetFiles(diretorio, "*.json");
                for (int i = 0; i <= arquivos.Length -1; i++)
                {
                    string conteudo = File.ReadAllText(arquivos[i]);
                    list.Add(conteudo);
                }

                return list;

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return list;

        }



    }
}
