using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Usuario.Consumidor;

namespace Modelos.Tuneflow.Pagos
{
    public class Pago
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; } // Identificador del usuario que realizó el pago
        public DateTime FechaPago { get; set; } // Fecha en que se realizó el pago
        public double Monto { get; set; } // Monto del pago
        public string MetodoPago { get; set; } // Método de pago utilizado (tarjeta de crédito, PayPal, etc.)

    }
}
