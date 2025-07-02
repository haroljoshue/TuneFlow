using Modelos.Tuneflow.Usuario.Consumidor;
using Modelos.Tuneflow.Usuario.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Tuneflow.Usuario.Perfiles
{
    public class Perfil
    {
        [Key] public int Id { get; set; } // Identificador único del perfil

        [ForeignKey(nameof(Cliente))] public int? ClienteId { get; set; } // Identificador del cliente al que pertenece el perfil

        [ForeignKey(nameof(Artista))] public int? ArtistaId { get; set; } // Identificador del artista al que pertenece el perfil
        public Cliente? Cliente { get; set; } // Relación con el cliente (opcional)
        public Artista? Artista { get; set; } // Relación con el artista (opcional)
        public string ImagenPerfil { get; set; } // URL o ruta de la imagen del perfil
        public string Biografia { get; set; } // Breve biografía o descripción del perfil
        public DateTime FechaCreacion { get; set; } // Fecha de creación del perfil

    }
}
