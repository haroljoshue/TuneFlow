using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Tuneflow.Usuario
{
    public abstract class Usuario
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoCuenta { get; set; } // "Cliente, Artista o Administrador"
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
