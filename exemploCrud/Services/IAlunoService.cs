using exemploCrud.Models;

namespace exemploCrud.Services
{
    public interface IAlunoService
    {
        public List<AlunoDTO> ObterTodos();
        public AlunoDTO? ObterPorCpf(string cpf);
        public void Adicionar(AlunoDTO novoAluno);
        public void Atualizar(string cpf, AlunoDTO alunoDTO);
        public void Remover(string cpf);
    }
}
