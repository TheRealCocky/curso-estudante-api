using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CursoModelDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int DuracaoMeses { get; set; }
    }

}