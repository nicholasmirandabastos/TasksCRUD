using System.Data.Entity;

namespace TasksCRUD.Models
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("MeuContexto") 
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
