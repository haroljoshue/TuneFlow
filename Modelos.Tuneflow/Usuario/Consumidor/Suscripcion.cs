using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Tuneflow.Usuario.Consumidor
{
    public class Suscripcion
    {
        [Key] public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? CodigoUnion { get; set; } // Código de unión para planes familiares, si es aplicable.
        [ForeignKey(nameof(TipoSuscripcion))] public int TipoSuscripcionId { get; set; }
        public TipoSuscripcion? TipoSuscripcion { get; set; }

        public List<Cliente>? Miembros { get; set; }
    }
}
