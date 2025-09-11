using exemploCrud.Models;
using exemploCrud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exemploCrud.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet("alunos")]
        public ActionResult<List<Models.AlunoDTO>> ObterAlunos()
        {
            return Ok(_alunoRepository.ObterTodos());
        }
        [HttpGet("alunos/{cpf}")]
        public ActionResult<Models.AlunoDTO> ObterAlunoByCpf(string cpf)
        {
            var resultado = _alunoRepository.ObterPorCpf(cpf);
           
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpPost("alunos")]
        public ActionResult<Models.AlunoDTO> CriarAluno([FromBody] Models.AlunoDTO novoAluno)
        {

            var resultado = _alunoRepository.ObterPorCpf(novoAluno.cpf);

            if (resultado is not null)
            {
                return BadRequest("Aluno com este CPF já existe.");
            }
            _alunoRepository.Adicionar(novoAluno);

            return Ok("Aluno criado com sucesso");
        }
        [HttpPut("alunos/{cpf}")]
        public ActionResult<Models.AlunoDTO> UpdateAluno(string cpf, [FromBody] Models.AlunoDTO alunoAtualizado)
        {        
            var alunoExistente = _alunoRepository.ObterPorCpf(cpf);

            if (alunoExistente == null)
            {
                return NotFound("Aluno não encontrado");
            }
            _alunoRepository.Atualizar(cpf, alunoAtualizado);

            return Ok("Aluno atualizado com sucesso");
        }
        [HttpDelete("alunos/{cpf}")]
        public ActionResult DeleteAluno(string cpf)
        {
            var alunoExistente = _alunoRepository.ObterPorCpf(cpf);

            if (alunoExistente == null)
            {
                return NotFound("Aluno não encontrado");
            }
            _alunoRepository.Remover(cpf);

            return NoContent();
        }
    }
}
