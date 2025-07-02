using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Media;

namespace Modelos.Tuneflow.Playlist
{
    public class MusicaPlaylist
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(Cancion))] public int CancionId { get; set; }
        [ForeignKey(nameof(Playlist))] public int PlaylistId { get; set; }
        public Cancion? Cancion { get; set; } // Relación con la canción que pertenece a esta playlist
        public Playlist? Playlist { get; set; } // Relación con la playlist a la que pertenece esta canción 
    }
}
