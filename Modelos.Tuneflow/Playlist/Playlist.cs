using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Usuario.Consumidor;
using Modelos.Tuneflow.Media;

namespace Modelos.Tuneflow.Playlist
{
    public class Playlist
    {
        [Key] public int Id { get; set; }
        public string Titulo { get; set; } // Título de la playlist
        public string Descripcion { get; set; } // Descripción de la playlist
        public DateTime FechaCreacion { get; set; } // Fecha de creación de la playlist
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public List<Cancion>? Canciones { get; set; } // Lista de canciones que pertenecen a esta playlist

    }
}
