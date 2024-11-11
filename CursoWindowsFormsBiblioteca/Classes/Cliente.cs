using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using CursoWindowsFormsBiblioteca.Databases;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Classes
{
    public class Cliente
    {
        public class Unit
        {
            [Required(ErrorMessage = "Código do cliente é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do cliente somente aceita valores numéricos")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Código do cliente deve ter 6 dígitos")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Nome do cliente é obrigatório")]
            [StringLength(50, ErrorMessage = "Nome do cliente deve ter no máximo 50 caracteres")]
            public string Nome { get; set; }

            [StringLength(50, ErrorMessage = "Nome do pai deve ter no máximo 50 caracteres")]
            public string NomePai { get; set; }

            [Required(ErrorMessage = "Nome da mãe é obrigatório")]
            [StringLength(50, ErrorMessage = "Nome da mãe deve ter no máximo 50 caracteres")]
            public string NomeMae { get; set; }

            public bool NaoTemPai { get; set; }

            [Required(ErrorMessage = "CPF é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CPF somente aceita valores numéricos")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos")]
            public string Cpf { get; set; }


            [Required(ErrorMessage = "Gênero é obrigatório")]
            public int Genero { get; set; }

            [Required(ErrorMessage = "CEP é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CEP somente aceita valores numéricos")]
            [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP deve ter 8 dígitos")]
            public string Cep { get; set; }


            [Required(ErrorMessage = "Logradouro é obrigatório")]
            [StringLength(100, ErrorMessage = "Logradouro deve ter no máximo 100 caracteres")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "Complemento é obrigatório")]
            [StringLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres")]
            public string Complemento { get; set; }

            [Required(ErrorMessage = "Bairro é obrigatório")]
            [StringLength(50, ErrorMessage = "Bairro deve ter no máximo 50 caracteres")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "Cidade é obrigatória")]
            [StringLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres")]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "Estado é obrigatório")]
            [StringLength(50, ErrorMessage = "Estado deve ter no máximo 50 caracteres")]
            public string Estado { get; set; }

            [Required(ErrorMessage = "Número do telefone é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Número do telefone somente aceita valores numéricos")]
            public string Telefone { get; set; }

            public string Profissao { get; set; }

            [Required(ErrorMessage = "Renda familiar é obrigatória")]
            [Range(0, Double.MaxValue, ErrorMessage = "Renda familiar deve ser uma valor positivo")]
            public double RendaFamiliar { get; set; }


            public void ValidaClasse()
            {
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (isValid == false)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }
            }

            public void ValidaComplemento()
            {
                if (this.NomePai == this.NomeMae)
                {
                    throw new Exception("Nome do pai e da mãe não podem ser iguais");
                }

                if (this.NaoTemPai == false)
                {
                    if (this.NomePai == "")
                    {
                        throw new Exception("Nome do pai não pode estar vazia quando a propriedade Pai desconhecido não estiver marcado");
                    }
                }

                bool validaCPF = Cls_Uteis.Valida(this.Cpf);
                if (validaCPF == false)
                {
                    throw new Exception("CPF Inválido");
                }

            }


            #region "CRUD do Fichario"

            public void IncluirFichario(string conexao)
            {
                string clienteJson = SerializedClassUnit(this);
                Fichario f = new Fichario(conexao);
                if (f.status)
                {
                    f.Incluir(this.Id, clienteJson);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public Unit BuscarFichario(string id, string conexao)
            {
                Fichario f = new Fichario(conexao);
                if (f.status)
                {
                    string clienteJson = f.Buscar(id);
                    if (f.status)
                    {
                        return DesSerializedClassUnit(clienteJson);
                    }
                    else
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void AlterarFichario(string conexao)
            {
                string clienteJson = SerializedClassUnit(this);

                Fichario f = new Fichario(conexao);

                if (f.status)
                {
                    f.Alterar(this.Id, clienteJson);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }


            public void ApagarFichario(string conexao)
            {

                Fichario f = new Fichario(conexao);

                if (f.status)
                {
                    f.Apagar(this.Id);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<string> ListarFicharios(string conexao)
            {
                Fichario f = new Fichario(conexao);

                if (f.status)
                {
                    List<string> todosJson = f.BuscarTodos();
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                    return todosJson;
                }
                else
                {
                    throw new Exception(f.mensagem);
                }

            }

            #endregion


            #region "CRUD do FicharioDB LocalDB"

            public void IncluirFicharioDB(string conexao)
            {
                string clienteJson = SerializedClassUnit(this);
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    f.Incluir(this.Id, clienteJson);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public Unit BuscarFicharioDB(string id, string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                if (f.status)
                {
                    string clienteJson = f.Buscar(id);
                    if (f.status)
                    {
                        return DesSerializedClassUnit(clienteJson);
                    }
                    else
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void AlterarFicharioDB(string conexao)
            {
                string clienteJson = SerializedClassUnit(this);

                FicharioDB f = new FicharioDB(conexao);

                if (f.status)
                {
                    f.Alterar(this.Id, clienteJson);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }


            public void ApagarFicharioDB(string conexao)
            {

                FicharioDB f = new FicharioDB(conexao);

                if (f.status)
                {
                    f.Apagar(this.Id);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<string> ListarFichariosDB(string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);

                if (f.status)
                {
                    List<string> todosJson = f.BuscarTodos();
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                    return todosJson;
                }
                else
                {
                    throw new Exception(f.mensagem);
                }

            }

            #endregion

            #region "CRUD do Fichario SQL Server"

            public void IncluirFicharioSQL(string conexao)
            {
                string clienteJson = SerializedClassUnit(this);
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    f.Incluir(this.Id, clienteJson);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public Unit BuscarFicharioSQL(string id, string conexao)
            {
                FicharioSQLServer f = new FicharioSQLServer(conexao);
                if (f.status)
                {
                    string clienteJson = f.Buscar(id);
                    if (f.status)
                    {
                        return DesSerializedClassUnit(clienteJson);
                    }
                    else
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public void AlterarFicharioSQL(string conexao)
            {
                string clienteJson = SerializedClassUnit(this);

                FicharioSQLServer f = new FicharioSQLServer(conexao);

                if (f.status)
                {
                    f.Alterar(this.Id, clienteJson);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }


            public void ApagarFicharioSQL(string conexao)
            {

                FicharioSQLServer f = new FicharioSQLServer(conexao);

                if (f.status)
                {
                    f.Apagar(this.Id);
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                }
                else
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<string> ListarFichariosSQL(string conexao)
            {
                FicharioSQLServer f = new FicharioSQLServer(conexao);

                if (f.status)
                {
                    List<string> todosJson = f.BuscarTodos();
                    if (!f.status)
                    {
                        throw new Exception(f.mensagem);
                    }
                    return todosJson;
                }
                else
                {
                    throw new Exception(f.mensagem);
                }

            }

            #endregion

            #region "CRUD do Fichario DB SQL Server Relacional"

            #region "Funções auxiliares

            public string ToInsert()
            {
                string sql;
                sql = @"INSERT INTO TB_Cliente
                                        (Id,
                                        Nome,
                                        NomePai,
                                        NomeMae,
                                        NaoTemPai,
                                        Cpf,
                                        Genero,
                                        Cep,
                                        Logradouro,
                                        Complemento,
                                        Bairro,
                                        Cidade,
                                        Estado,
                                        Telefone,
                                        Profissao,
                                        RendaFamiliar) VALUES  ";

                sql += "('" + this.Id + "'";
                sql += ",'" + this.Nome + "'";
                sql += ",'" + this.NomePai + "'";
                sql += ",'" + this.NomeMae + "'";
                sql += ",'" + this.NaoTemPai.ToString() + "'";
                sql += ",'" + this.Cpf + "'";
                sql += "," + this.Genero.ToString();
                sql += ",'" + this.Cep + "'";
                sql += ",'" + this.Logradouro + "'";
                sql += ",'" + this.Complemento + "'";
                sql += ",'" + this.Bairro + "'";
                sql += ",'" + this.Cidade + "'";
                sql += ",'" + this.Estado + "'";
                sql += ",'" + this.Telefone + "'";
                sql += ",'" + this.Profissao + "'";
                sql += "," + this.RendaFamiliar.ToString() + ");";

                return sql;
            }

            public string ToUpdate(string id)
            {
                string sql;

                sql = @"UPDATE TB_Cliente SET";
                sql += " Id='" + this.Id + "'";
                sql += ",Nome='" + this.Nome + "'";
                sql += ",NomePai='" + this.NomePai + "'";
                sql += ",NomeMae='" + this.NomeMae + "'";
                sql += ",NaoTemPai='" + this.NaoTemPai.ToString() + "'";
                sql += ",Cpf='" + this.Cpf + "'";
                sql += ",Genero=" + this.Genero.ToString();
                sql += ",Cep='" + this.Cep + "'";
                sql += ",Logradouro='" + this.Logradouro + "'";
                sql += ",Complemento='" + this.Complemento + "'";
                sql += ",Bairro='" + this.Bairro + "'";
                sql += ",Cidade='" + this.Cidade + "'";
                sql += ",Estado='" + this.Estado + "'";
                sql += ",Telefone='" + this.Telefone + "'";
                sql += ",Profissao='" + this.Profissao + "'";
                sql += ",RendaFamiliar=" + this.RendaFamiliar.ToString();
                sql += " WHERE Id='" + id + "';";

                return sql;
            }

            public Unit DataRowToUnit(DataRow dr)
            {
                Unit u = new Unit();

                u.Id = dr["Id"].ToString();
                u.Nome = dr["Nome"].ToString();
                u.NomePai = dr["NomePai"].ToString();
                u.NomeMae = dr["NomeMae"].ToString();
                u.NaoTemPai = Convert.ToBoolean(dr["NaoTemPai"]);
                u.Cpf = dr["Cpf"].ToString();
                u.Genero = Convert.ToInt32(dr["Genero"]);
                u.Cep = dr["Cep"].ToString();
                u.Logradouro = dr["Logradouro"].ToString();
                u.Complemento = dr["Complemento"].ToString();
                u.Bairro = dr["Bairro"].ToString();
                u.Cidade = dr["Cidade"].ToString();
                u.Estado = dr["Estado"].ToString();
                u.Telefone = dr["Telefone"].ToString();
                u.Profissao = dr["Profissao"].ToString();
                u.RendaFamiliar = Convert.ToDouble(dr["RendaFamiliar"]);

                return u;
            }




            #endregion

            public void IncluirFicharioSQLRel()
            {
                try
                {
                    string sql;
                    sql = this.ToInsert();
                    var db = new SQLServerClass();
                    db.SQLCommand(sql);
                    db.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Inclusão não permitida: " + this.Id + ", erro: " + ex.Message);
                }
            }

            public Unit BuscarFicharioSQLRel(string id)
            {
                try
                {
                    string sql;
                    sql = "SELECT * FROM TB_Cliente WHERE Id = '" + id + "'";
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(sql);
                    db.Close();
                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception("Identificador não existente: " + id);
                    }
                    else
                    {
                        Unit u = this.DataRowToUnit(dt.Rows[0]);
                        return u;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar conteúdo do identificador: " + this.Id + ", erro: " + ex.Message);
                }
            }

            public void AlterarFicharioSQLRel()
            {
                try
                {
                    string sql;
                    sql = "SELECT * FROM TB_Cliente WHERE Id = '" + Id + "'";
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(sql);
                    if (dt.Rows.Count == 0)
                    {
                        db.Close();
                        throw new Exception("Identificador não existente: " + Id);
                    }
                    else
                    {
                        sql = ToUpdate(Id);
                        db.SQLCommand(sql);
                        db.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao alterar conteúdo do identificador: " + this.Id + ", erro: " + ex.Message);
                }
            }

            public void ApagarFicharioSQLRel()
            {
                try
                {
                    string sql;
                    sql = "SELECT * FROM TB_Cliente WHERE Id = '" + Id + "'";
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(sql);
                    if (dt.Rows.Count == 0)
                    {
                        db.Close();
                        throw new Exception("Identificador não existente: " + Id);
                    }
                    else
                    {
                        sql = "DELETE FROM TB_Cliente WHERE Id = '" + Id + "'";
                        db.SQLCommand(sql);
                        db.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao excluir conteúdo do identificador: " + this.Id + ", erro: " + ex.Message);
                }
            }

            public List<List<string>> ListarFichariosSQLRel()
            {
                List<List<string>> listaBusca = new List<List<string>>();
                try
                {
                    string sql;
                    sql = "SELECT * FROM TB_Cliente";
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(sql);
                    db.Close();
                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception("Não existem clientes na base de dados");
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            listaBusca.Add(new List<string> { dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Nome"].ToString() });
                        }
                        return listaBusca;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro na conexao com a base de dados: " + ex.Message);
                }

            }



        }



        #endregion

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }

        public static Unit DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Unit>(vJson);
        }

        public static string SerializedClassUnit(Unit unit)
        {
            return JsonConvert.SerializeObject(unit);
        }
    }
}
