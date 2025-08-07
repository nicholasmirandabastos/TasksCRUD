using Microsoft.AspNetCore.Mvc;
using TasksCRUD.Models;

namespace TasksCRUD.Controllers
{
    public class TarefaController : Controller
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();

        public IActionResult Index()
        {
            return View(tarefas);
        }
    }
}
