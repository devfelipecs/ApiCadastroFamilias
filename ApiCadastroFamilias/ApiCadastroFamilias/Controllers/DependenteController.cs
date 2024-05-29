using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastroFamilias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependenteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DependenteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dependente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependentes>>> GetDependente()
        {
            return await _context.Dependentes.ToListAsync();
        }

        // GET: api/Dependente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dependentes>> GetDependente(int id)
        {
            var dependente = await _context.Dependentes.FindAsync(id);

            if (dependente == null)
            {
                return NotFound();
            }

            return dependente;
        }

        // POST: api/Dependentes
        [HttpPost]
        public async Task<ActionResult<Dependentes>> PostDependente([FromBody] Dependentes dependente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dependentes.Add(dependente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDependente), new { id = dependente.Id }, dependente);
        }

        // PUT: api/Dependente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependente(int id, [FromBody] Dependentes dependente)
        {
            if (id != dependente.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(dependente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Dependente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependente(int id)
        {
            var dependente = await _context.Dependentes.FindAsync(id);
            if (dependente == null)
            {
                return NotFound();
            }

            _context.Dependentes.Remove(dependente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DependenteExists(int id)
        {
            return _context.Dependentes.Any(e => e.Id == id);
        }
    }
}
