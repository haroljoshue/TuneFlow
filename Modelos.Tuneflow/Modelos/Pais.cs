using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Tuneflow.Modelos
{
    public class Pais
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Continente { get; set; }
        public string Moneda { get; set; }

    }
}
