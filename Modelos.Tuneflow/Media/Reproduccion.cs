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
    public class Reproduccion
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }

        [ForeignKey(nameof(Cancion))] public int CancionId { get; set; }

        public DateTime FechaHora { get; set; }

        public Cliente? Cliente { get; set; }
        public Cancion? Cancion { get; set; }
    }
}
