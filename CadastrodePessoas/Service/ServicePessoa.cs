using CadastrodePessoas.ViewModel;
using CadastrodPessoaApi.Data;

namespace CadastrodPessoaApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();// chamando os metodos dentro da classe Repository
            return repository.GetAll().ToList();//Retorna nosso repository
        }

        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        }
        public IEnumerable<PessoaViewModel> GetByprimeiroNome(string primeiroNome)
        {
            var repository = new Repository();
            return repository.GetByprimeiroNome(primeiroNome);
        }
        public void update(int pessoaId, string primeiroNome)
        {
            if (pessoaId > 0 && !string.IsNullOrEmpty(primeiroNome))// Regra para o id ser maior que zero, e o primeiro nome vazio 
            {
                var repository = new Repository();
                repository.update(pessoaId, primeiroNome);//Não tem retorno pois ele não retorna nada
            }
        }
        public string Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "os dados sao obrigatorios";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.NomeMeio))
                return "o campo nome do meio é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.UltimoNome))
                return "o campo ultimo nome é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "o campo CPFe é obrigatório";
            var repository = new Repository();
            return repository.Create(pessoa);
        }
    }
}