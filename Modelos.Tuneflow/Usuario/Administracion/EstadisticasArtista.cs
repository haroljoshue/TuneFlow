using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tuneflow.Usuario.Produccion;

namespace Modelos.Tuneflow.Usuario.Administracion
{
    public class EstadisticasArtista
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(Artista))] public int ArtistaId { get; set; }
        public int ReproduccionesTotales { get; set; }
        public int SeguidoresTotales { get; set; }
        public int CancionesPublicadas { get; set; }
        public int AlbumesPublicados { get; set; }

        public Artista? Artista { get; set; }

    }
}
