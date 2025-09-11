using exemploCrud.Models;

namespace exemploCrud.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private static List<AlunoDTO> alunos = new List<AlunoDTO>();

        public List<AlunoDTO> ObterTodos()
        {
            return alunos;
        }

        public AlunoDTO? ObterPorCpf(string cpf)
        {
            return alunos.FirstOrDefault(a => a.cpf == cpf);
        }

        public void Adicionar(AlunoDTO novoAluno)
        {
            alunos.Add(novoAluno);
        }

        public void Atualizar(string cpf,AlunoDTO alunoDTO)
        {
            var aluno = ObterPorCpf(cpf);
            if (aluno != null)
            {
                aluno.nome = aluno.nome;
                aluno.idade = aluno.idade;                
            }
        }
        public void Remover(string cpf)
        {
            var aluno = ObterPorCpf(cpf);
            if (aluno != null)
            {
                alunos.Remove(aluno);
            }
        }
    }
}
