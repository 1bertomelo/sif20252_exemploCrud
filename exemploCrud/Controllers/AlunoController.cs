using exemploCrud.Models;
using exemploCrud.Repository;
using exemploCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace exemploCrud.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("alunos")]
        public ActionResult<List<Models.AlunoDTO>> ObterAlunos()
        {
            return Ok(_alunoService.ObterTodos());
        }
        [HttpGet("alunos/{cpf}")]
        public ActionResult<Models.AlunoDTO> ObterAlunoByCpf(string cpf)
        {
            var resultado = _alunoService.ObterPorCpf(cpf);
           
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpPost("alunos")]
        public ActionResult<Models.AlunoDTO> CriarAluno([FromBody] Models.AlunoDTO novoAluno)
        {          
            _alunoService.Adicionar(novoAluno);

            return Ok("Aluno criado com sucesso");
        }
        [HttpPut("alunos/{cpf}")]
        public ActionResult<Models.AlunoDTO> UpdateAluno(string cpf, [FromBody] Models.AlunoDTO alunoAtualizado)
        {        
            var alunoExistente = _alunoService.ObterPorCpf(cpf);

            if (alunoExistente == null)
            {
                return NotFound("Aluno não encontrado");
            }
            _alunoService.Atualizar(cpf, alunoAtualizado);

            return Ok("Aluno atualizado com sucesso");
        }
        [HttpDelete("alunos/{cpf}")]
        public ActionResult DeleteAluno(string cpf)
        {
            var alunoExistente = _alunoService.ObterPorCpf(cpf);

            if (alunoExistente == null)
            {
                return NotFound("Aluno não encontrado");
            }
            _alunoService.Remover(cpf);

            return NoContent();
        }
    }
}
