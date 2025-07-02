using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Tuneflow.Playlist;

namespace API.TUNEFLOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasPlaylistsController : ControllerBase
    {
        private readonly TUNEFLOWContext _context;

        public MusicasPlaylistsController(TUNEFLOWContext context)
        {
            _context = context;
        }

        // GET: api/MusicasPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicaPlaylist>>> GetMusicaPlaylist()
        {
            return await _context.MusicasPlaylists.ToListAsync();
        }

        // GET: api/MusicasPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicaPlaylist>> GetMusicaPlaylist(int id)
        {
            var musicaPlaylist = await _context.MusicasPlaylists.FindAsync(id);

            if (musicaPlaylist == null)
            {
                return NotFound();
            }

            return musicaPlaylist;
        }

        // PUT: api/MusicasPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicaPlaylist(int id, MusicaPlaylist musicaPlaylist)
        {
            if (id != musicaPlaylist.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicaPlaylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicaPlaylistExists(id))
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

        // POST: api/MusicasPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicaPlaylist>> PostMusicaPlaylist(MusicaPlaylist musicaPlaylist)
        {
            _context.MusicasPlaylists.Add(musicaPlaylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicaPlaylist", new { id = musicaPlaylist.Id }, musicaPlaylist);
        }

        // DELETE: api/MusicasPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicaPlaylist(int id)
        {
            var musicaPlaylist = await _context.MusicasPlaylists.FindAsync(id);
            if (musicaPlaylist == null)
            {
                return NotFound();
            }

            _context.MusicasPlaylists.Remove(musicaPlaylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicaPlaylistExists(int id)
        {
            return _context.MusicasPlaylists.Any(e => e.Id == id);
        }
    }
}
