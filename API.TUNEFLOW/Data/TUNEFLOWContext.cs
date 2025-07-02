using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos.Tuneflow.Media;
using Modelos.Tuneflow.Pagos;
using Modelos.Tuneflow.Playlist;
using Modelos.Tuneflow.Usuario.Administracion;
using Modelos.Tuneflow.Usuario.Consumidor;
using Modelos.Tuneflow.Usuario.Perfiles;
using Modelos.Tuneflow.Modelos;
using Modelos.Tuneflow.Usuario.Produccion;

    public class TUNEFLOWContext : DbContext
    {
        public TUNEFLOWContext (DbContextOptions<TUNEFLOWContext> options)
            : base(options)
        {
        }

        public DbSet<Modelos.Tuneflow.Media.Cancion> Canciones { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Media.CancionFavorita> CancionesFavoritas { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Media.Reproduccion> Reproducciones { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Pagos.Pago> Pagos { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Playlist.Album> Albums { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Playlist.MusicaPlaylist> MusicasPlaylists { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Playlist.Playlist> Playlists { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Administracion.Administrador> Administradores { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Consumidor.Cliente> Clientes { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Consumidor.Suscripcion> Suscripciones { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Consumidor.TipoSuscripcion> TiposSuscripciones { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Perfiles.Perfil> Perfiles { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Modelos.Pais> Paises { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Administracion.EstadisticasArtista> EstadisticasArtistas { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Produccion.Artista> Artistas { get; set; } = default!;

public DbSet<Modelos.Tuneflow.Usuario.Produccion.Seguimiento> Seguimientos { get; set; } = default!;
    }
