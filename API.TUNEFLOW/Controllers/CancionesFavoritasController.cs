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
    public class CancionesFavoritasController : ControllerBase
    {
        private readonly TUNEFLOWContext _context;

        public CancionesFavoritasController(TUNEFLOWContext context)
        {
            _context = context;
        }

        // GET: api/CancionesFavoritas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancionFavorita>>> GetCancionFavorita()
        {
            return await _context.CancionesFavoritas.ToListAsync();
        }

        // GET: api/CancionesFavoritas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CancionFavorita>> GetCancionFavorita(int id)
        {
            var cancionFavorita = await _context.CancionesFavoritas.FindAsync(id);

            if (cancionFavorita == null)
            {
                return NotFound();
            }

            return cancionFavorita;
        }

        // PUT: api/CancionesFavoritas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancionFavorita(int id, CancionFavorita cancionFavorita)
        {
            if (id != cancionFavorita.Id)
            {
                return BadRequest();
            }

            _context.Entry(cancionFavorita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionFavoritaExists(id))
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

        // POST: api/CancionesFavoritas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CancionFavorita>> PostCancionFavorita(CancionFavorita cancionFavorita)
        {
            _context.CancionesFavoritas.Add(cancionFavorita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancionFavorita", new { id = cancionFavorita.Id }, cancionFavorita);
        }

        // DELETE: api/CancionesFavoritas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancionFavorita(int id)
        {
            var cancionFavorita = await _context.CancionesFavoritas.FindAsync(id);
            if (cancionFavorita == null)
            {
                return NotFound();
            }

            _context.CancionesFavoritas.Remove(cancionFavorita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancionFavoritaExists(int id)
        {
            return _context.CancionesFavoritas.Any(e => e.Id == id);
        }
    }
}
