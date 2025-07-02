using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Usuario.Consumidor;

namespace Modelos.Tuneflow.Usuario.Produccion
{
    public class Seguimiento
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }

        [ForeignKey(nameof(Artista))] public int ArtistaId { get; set; }

        public Cliente? Cliente { get; set; }
        public Artista? Artista { get; set; }
    }
}
