using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa novaTarefa)
        {
            _context.Tarefas.Add(novaTarefa);
            _context.SaveChanges();
            return Ok(novaTarefa);
        }

        [HttpGet]
        public IActionResult ListarTarefas()
        {
            var tarefas = _context.Tarefas;
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult ObterTarefaPeloID(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return NotFound();

            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return NotFound();

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Concluida = tarefaAtualizada.Concluida;

            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpPatch("{id}")]
        public IActionResult ConcluirTarefa(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return NotFound();

            tarefa.Concluida = true;
            _context.SaveChanges();

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return NotFound();

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
