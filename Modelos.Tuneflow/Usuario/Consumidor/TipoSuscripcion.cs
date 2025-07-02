using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Tuneflow.Usuario.Consumidor
{
    public class TipoSuscripcion
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }  // Free, Premium, Familiar
        public double Precio { get; set; }
        public int LimiteMiembros { get; set; }
    }
}
