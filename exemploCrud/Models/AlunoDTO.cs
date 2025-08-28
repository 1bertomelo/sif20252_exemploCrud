using exemploCrud.Validations;
using System.ComponentModel.DataAnnotations;

namespace exemploCrud.Models
{
    public class AlunoDTO
    {
        [CpfValidation(ErrorMessage = "Digite um cpf valido")]
        [Required(ErrorMessage ="Cpf Obrigatório")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Cpf Obrigatório")]
        [MinLength(3, ErrorMessage ="Digite no minimo 3 letras")]
        [MaxLength(20, ErrorMessage ="Digite no maximo 20 letras")]
        public string nome { get; set; }

        [Range(18,80,ErrorMessage ="Digite idade entre 18 e 80 anos")]
        public int idade { get; set; }

   
    }
}
