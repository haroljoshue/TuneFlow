using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Tuneflow.Media;

namespace API.TUNEFLOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReproduccionesController : ControllerBase
    {
        private readonly TUNEFLOWContext _context;

        public ReproduccionesController(TUNEFLOWContext context)
        {
            _context = context;
        }

        // GET: api/Reproducciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reproduccion>>> GetReproduccion()
        {
            return await _context.Reproducciones.ToListAsync();
        }

        // GET: api/Reproducciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reproduccion>> GetReproduccion(int id)
        {
            var reproduccion = await _context.Reproducciones.FindAsync(id);

            if (reproduccion == null)
            {
                return NotFound();
            }

            return reproduccion;
        }

        // PUT: api/Reproducciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReproduccion(int id, Reproduccion reproduccion)
        {
            if (id != reproduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(reproduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReproduccionExists(id))
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

        // POST: api/Reproducciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reproduccion>> PostReproduccion(Reproduccion reproduccion)
        {
            _context.Reproducciones.Add(reproduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReproduccion", new { id = reproduccion.Id }, reproduccion);
        }

        // DELETE: api/Reproducciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReproduccion(int id)
        {
            var reproduccion = await _context.Reproducciones.FindAsync(id);
            if (reproduccion == null)
            {
                return NotFound();
            }

            _context.Reproducciones.Remove(reproduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReproduccionExists(int id)
        {
            return _context.Reproducciones.Any(e => e.Id == id);
        }
    }
}
