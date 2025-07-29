using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CursoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(250)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória")]
        [Range(1, 48)]
        public int DuracaoMeses { get; set; }

        // Relacionamento: Um curso pode ter vários estudantes
        public ICollection<EstudanteModel> Estudantes { get; set; }
    }
}