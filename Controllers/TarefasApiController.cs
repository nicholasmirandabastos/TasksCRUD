using Microsoft.AspNetCore.Mvc;
using TasksCRUD.Models;
using TasksCRUD.Data;

namespace TasksCRUD.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tarefas
        [HttpGet]
        public IActionResult GetAll()
        {
            var tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }

        // GET: api/tarefas/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        // POST: api/tarefas

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var erro in erros)
                {
                    Console.WriteLine(erro.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            tarefa.Status = StatusTarefa.Fila;

            await _context.Tarefas.AddAsync(tarefa);
            int affectedRows = await _context.SaveChangesAsync();

            Console.WriteLine("Linhas afetadas: " + affectedRows);

            return CreatedAtAction(nameof(GetById), new { id = tarefa.ID }, tarefa);
        }


        // PUT: api/tarefas/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.ID)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = _context.Tarefas.Find(id);
            if (existente == null)
                return NotFound();

            existente.Titulo = tarefa.Titulo;
            existente.Descricao = tarefa.Descricao;
            existente.DataVencimento = tarefa.DataVencimento;
            existente.Status = tarefa.Status;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/tarefas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
