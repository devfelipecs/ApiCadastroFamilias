using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastroFamilias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepresentanteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RepresentanteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Representante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Representantes>>> GetRepresentante()
        {
            return await _context.Representantes.ToListAsync();
        }

        // GET: api/Representante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Representantes>> GetRepresentante(int id)
        {
            var representante = await _context.Representantes.FindAsync(id);

            if (representante == null)
            {
                return NotFound();
            }

            return representante;
        }

        // POST: api/Representante
        [HttpPost]
        public async Task<ActionResult<Representantes>> PostRepresentante([FromBody] Representantes representante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Representantes.Add(representante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRepresentante), new { id = representante.Id }, representante);
        }

        // PUT: api/Representantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepresentante(int id, [FromBody] Representantes representante)
        {
            if (id != representante.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(representante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepresentanteExists(id))
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

        // DELETE: api/Representante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepresentante(int id)
        {
            var representante = await _context.Representantes.FindAsync(id);
            if (representante == null)
            {
                return NotFound();
            }

            _context.Representantes.Remove(representante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepresentanteExists(int id)
        {
            return _context.Representantes.Any(e => e.Id == id);
        }
    }
}
