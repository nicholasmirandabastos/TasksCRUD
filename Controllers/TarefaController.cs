using Microsoft.AspNetCore.Mvc;
using TasksCRUD.Data;
using TasksCRUD.Models;

namespace TasksCRUD.Controllers
{
    public class TarefaController : Controller
    {
        private readonly AppDbContext _context;

        public TarefaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList(); // <-- busca do banco
            return View(tarefas);
        }
    }
}
