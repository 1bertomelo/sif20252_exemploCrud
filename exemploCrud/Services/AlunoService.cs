using exemploCrud.Models;
using exemploCrud.Repository;

namespace exemploCrud.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Adicionar(AlunoDTO novoAluno)
        {
            var resultado = _alunoRepository.ObterPorCpf(novoAluno.cpf);
            if (resultado is not null)
            {
                throw new Exception("Aluno com este CPF já existe.");
            }

            _alunoRepository.Adicionar(novoAluno);
        }

        public void Atualizar(string cpf, AlunoDTO alunoDTO)
        {
           var resultado = _alunoRepository.ObterPorCpf(cpf);
            if (resultado is null)
            {
                throw new Exception("Aluno não encontrado");
            }
            _alunoRepository.Atualizar(cpf, alunoDTO);
        }

        public AlunoDTO? ObterPorCpf(string cpf)
        {
            return _alunoRepository.ObterPorCpf(cpf);
        }

        public List<AlunoDTO> ObterTodos()
        {
           return _alunoRepository.ObterTodos();
        }

        public void Remover(string cpf)
        {
            var resultado = _alunoRepository.ObterPorCpf(cpf);
            if (resultado is null)
            {
                throw new Exception("Aluno não encontrado");
            }

            _alunoRepository.Remover(cpf);
        }
    }
}
