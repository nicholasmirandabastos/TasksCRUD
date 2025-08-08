using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TasksCRUD.Models
{
    public class Tarefa : IValidatableObject
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Fila;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataVencimento.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "A data de vencimento não pode estar no passado.",
                    new[] { nameof(DataVencimento) });
            }
        }
    }

}
