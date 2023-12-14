using CadastrodePessoas.ViewModel;
using Dapper;
using System.Data.SqlClient;

namespace CadastrodPessoaApi.Data
{
    public class Repository //mapeamento do Dapper dentro do repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True";//Criando uma variavel que vai receber o caminho para conexão com o banco de dados
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "SELECT TOP 1000 * FROM PESSOAS";// Adicionando a uma variavel um comando usado no banco de dados 
            using (SqlConnection con = new SqlConnection(conexao))//Usada para fazer mapeamento do proprio banco
            {
                return con.Query<PessoaViewModel>(query);//Retorna nosssa solicitação ao banco de dados
            }
        }
        public PessoaViewModel GetById(int pessoaId)// retorna apenas a pessoa que foi atrelada ao id inserido
        {
            string query = "SELECT * FROM PESSOAS WHERE pessoaId= @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId });
            }
        }
        public IEnumerable<PessoaViewModel> GetByprimeiroNome(string primeiroNome)
        {
            string query = "SELECT * FROM PESSOAS WHERE primeiroNome= @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query, new { primeiroNome = primeiroNome });
            }
        }
        public void update(int pessoaId, string primeiroNome) //para atualizar o nome no banco de dados usando o id 
        {
            string query = "  UPDATE PESSOAS SET primeiroNome =@primeiroNome WHERE  pessoaId= @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                con.Execute(query, new { primeiroNome = primeiroNome, pessoaId = pessoaId });//vai atualizar mas não vai retornar 
            }

        }
        public string Create(PessoaViewModel pessoa)
        {
            try
            {
                string query = "INSERT INTO PESSOAS(primeiroNome, nomeMeio, ultimoNome, CPF) VALUES(@primeiroNome, @nomeMeio, @ultimoNome, @CPF)";
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    _ = con.Execute(query, new
                    {
                        primeiroNome = pessoa.PrimeiroNome,
                        nomeMeio = pessoa.NomeMeio,
                        cpf = pessoa.CPF,
                        ultimoNome = pessoa.UltimoNome,
                    });
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}