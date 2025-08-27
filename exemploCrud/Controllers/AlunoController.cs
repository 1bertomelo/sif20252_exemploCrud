using exemploCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace exemploCrud.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private static List<AlunoDTO> alunos = new List<AlunoDTO>();

        [HttpGet("alunos")]
        public ActionResult<List<Models.AlunoDTO>> GetAlunos()
        {
            return Ok(alunos);
        }
        [HttpGet("alunos/{cpf}")]
        public ActionResult<Models.AlunoDTO> GetAlunoByCpf(string cpf)
        {
            var aluno = alunos.FirstOrDefault(a => a.cpf == cpf);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost("alunos")]
        public ActionResult<Models.AlunoDTO> CreateAluno([FromBody] Models.AlunoDTO novoAluno)
        {


            if (alunos.Any(a => a.cpf == novoAluno.cpf))
            {
                return Conflict("Aluno com este CPF já existe.");
            }
            alunos.Add(novoAluno);
            return CreatedAtAction(nameof(GetAlunoByCpf), new { cpf = novoAluno.cpf }, novoAluno);
        }
        [HttpPut("alunos/{cpf}")]
        public ActionResult<Models.AlunoDTO> UpdateAluno(string cpf, [FromBody] Models.AlunoDTO alunoAtualizado)
        {
            var aluno = alunos.FirstOrDefault(a => a.cpf == cpf);
            if (aluno == null)
            {
                return NotFound();
            }
            aluno.nome = alunoAtualizado.nome;
            return Ok(aluno);
        }
        [HttpDelete("alunos/{cpf}")]
        public ActionResult DeleteAluno(string cpf)
        {
            var aluno = alunos.FirstOrDefault(a => a.cpf == cpf);
            if (aluno == null)
            {
                return NotFound();
            }
            alunos.Remove(aluno);
            return NoContent();
        }
    }
}
