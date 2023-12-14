using CadastrodePessoas.ViewModel;

namespace CadastroPessoaApi.Service
{
    internal interface IRepository
    {
        IEnumerable<PessoaViewModel> GetAll();
        PessoaViewModel GetById(int pessoaId);
        void Update(PessoaViewModel pessoa);
    }
}