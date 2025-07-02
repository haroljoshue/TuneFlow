using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Media;

namespace Modelos.Tuneflow.Playlist
{
    public class Album
    {
        [Key] public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Genero { get; set; } // Pop, Rock, Hip-Hop, etc.
        public DateOnly FechaCreacion { get; set; } // Fecha de creación del álbum
        public string Descripcion { get; set; } // Descripción del álbum
        public string RutaPortada { get; set; } // Ruta de la imagen de portada del álbum
        public List<Cancion> Canciones { get; set; } // Lista de canciones que pertenecen a este álbum
    }
}
