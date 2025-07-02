using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Tuneflow.Usuario.Administracion;

namespace API.TUNEFLOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticasArtistasController : ControllerBase
    {
        private readonly TUNEFLOWContext _context;

        public EstadisticasArtistasController(TUNEFLOWContext context)
        {
            _context = context;
        }

        // GET: api/EstadisticasArtistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadisticasArtista>>> GetEstadisticasArtista()
        {
            return await _context.EstadisticasArtistas.ToListAsync();
        }

        // GET: api/EstadisticasArtistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadisticasArtista>> GetEstadisticasArtista(int id)
        {
            var estadisticasArtista = await _context.EstadisticasArtistas.FindAsync(id);

            if (estadisticasArtista == null)
            {
                return NotFound();
            }

            return estadisticasArtista;
        }

        // PUT: api/EstadisticasArtistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadisticasArtista(int id, EstadisticasArtista estadisticasArtista)
        {
            if (id != estadisticasArtista.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadisticasArtista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadisticasArtistaExists(id))
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

        // POST: api/EstadisticasArtistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadisticasArtista>> PostEstadisticasArtista(EstadisticasArtista estadisticasArtista)
        {
            _context.EstadisticasArtistas.Add(estadisticasArtista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadisticasArtista", new { id = estadisticasArtista.Id }, estadisticasArtista);
        }

        // DELETE: api/EstadisticasArtistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadisticasArtista(int id)
        {
            var estadisticasArtista = await _context.EstadisticasArtistas.FindAsync(id);
            if (estadisticasArtista == null)
            {
                return NotFound();
            }

            _context.EstadisticasArtistas.Remove(estadisticasArtista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadisticasArtistaExists(int id)
        {
            return _context.EstadisticasArtistas.Any(e => e.Id == id);
        }
    }
}
