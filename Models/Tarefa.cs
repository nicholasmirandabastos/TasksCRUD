using System.ComponentModel.DataAnnotations;

namespace TasksCRUD.Models
{
    public class Tarefa
    {
        [Key]
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Fila;
    }

}
