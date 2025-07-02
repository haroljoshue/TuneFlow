using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Usuario.Consumidor;

namespace Modelos.Tuneflow.Media
{
    public class CancionFavorita
    {
        [Key] public int Id { get; set; }

        // Cliente que marcó como favorita
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }

        // Canción marcada
        [ForeignKey(nameof(Cancion))] public int CancionId { get; set; }

        public DateTime FechaAgregado { get; set; }

        public Cliente? Cliente { get; set; }
        public Cancion? Cancion { get; set; }
    }
}
