using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TasksCRUD.Data;
using TasksCRUD.Models;

namespace TasksCRUD.Controllers
{
    public class TarefasController : Controller
    {
        private readonly AppDbContext _context;

        private void PopularStatusList(StatusTarefa statusSelecionado)
        {
            ViewBag.StatusList = new SelectList(
                Enum.GetValues(typeof(StatusTarefa))
                    .Cast<StatusTarefa>()
                    .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
                "Value", "Text", (int)statusSelecionado
            );
        }

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList(); // listar tarefas do banco de dados
            return View(tarefas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.ID == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }


        // GET: Tarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarefa tarefa)
        {
            if (tarefa.DataVencimento.Date < DateTime.Today)
            {
                ModelState.AddModelError("DataVencimento", "A data de vencimento não pode estar no passado.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // GET: Tarefas/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();

            ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(StatusTarefa)));

            return View(tarefa);
        }

        // POST: Tarefas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tarefa tarefa)
        {
            if (id != tarefa.ID) return NotFound();

            if (tarefa.DataVencimento.Date < DateTime.Today)
            {
                ModelState.AddModelError("DataVencimento", "A data de vencimento não pode estar no passado.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tarefas.Any(e => e.ID == tarefa.ID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            PopularStatusList(tarefa.Status);

            return View(tarefa);
        }

        // GET: Tarefas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tarefa == null) return NotFound();

            return View(tarefa);
        }

        // POST: Tarefas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefa!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
