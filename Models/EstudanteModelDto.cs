using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EstudanteModelDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public int CursoId { get; set; }
    }

}