using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EstudanteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do estudante é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória")]
        [Range(10, 100)]
        public int Idade { get; set; }

        // FK para Curso
        [ForeignKey("Curso")]
        public int CursoId { get; set; }

        public CursoModel Curso { get; set; }
    }
}