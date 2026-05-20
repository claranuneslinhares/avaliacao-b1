using avaliacao_b1.Data;
using avaliacao_b1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace avaliacao_b1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlunosController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunosController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> Get()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> Get(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                return NotFound();

            return aluno;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);

            await _context.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Aluno aluno)
        {
            if (id != aluno.Id)
                return BadRequest();

            _context.Entry(aluno).State =
                EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                return NotFound();

            _context.Alunos.Remove(aluno);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
