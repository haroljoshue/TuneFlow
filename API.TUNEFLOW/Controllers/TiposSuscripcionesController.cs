using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Tuneflow.Usuario.Consumidor;

namespace API.TUNEFLOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposSuscripcionesController : ControllerBase
    {
        private readonly TUNEFLOWContext _context;

        public TiposSuscripcionesController(TUNEFLOWContext context)
        {
            _context = context;
        }

        // GET: api/TiposSuscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSuscripcion>>> GetTipoSuscripcion()
        {
            return await _context.TiposSuscripciones.ToListAsync();
        }

        // GET: api/TiposSuscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSuscripcion>> GetTipoSuscripcion(int id)
        {
            var tipoSuscripcion = await _context.TiposSuscripciones.FindAsync(id);

            if (tipoSuscripcion == null)
            {
                return NotFound();
            }

            return tipoSuscripcion;
        }

        // PUT: api/TiposSuscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSuscripcion(int id, TipoSuscripcion tipoSuscripcion)
        {
            if (id != tipoSuscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoSuscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSuscripcionExists(id))
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

        // POST: api/TiposSuscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoSuscripcion>> PostTipoSuscripcion(TipoSuscripcion tipoSuscripcion)
        {
            _context.TiposSuscripciones.Add(tipoSuscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoSuscripcion", new { id = tipoSuscripcion.Id }, tipoSuscripcion);
        }

        // DELETE: api/TiposSuscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSuscripcion(int id)
        {
            var tipoSuscripcion = await _context.TiposSuscripciones.FindAsync(id);
            if (tipoSuscripcion == null)
            {
                return NotFound();
            }

            _context.TiposSuscripciones.Remove(tipoSuscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoSuscripcionExists(int id)
        {
            return _context.TiposSuscripciones.Any(e => e.Id == id);
        }
    }
}
