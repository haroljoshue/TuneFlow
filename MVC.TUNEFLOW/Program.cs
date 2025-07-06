using API.Consumer;
using API.TUNEFLOW.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modelos.Tuneflow.Media;
using Modelos.Tuneflow.Modelos;
using Modelos.Tuneflow.Pagos;
using Modelos.Tuneflow.Playlist;
using Modelos.Tuneflow.Usuario.Administracion;
using Modelos.Tuneflow.Usuario.Consumidor;
using Modelos.Tuneflow.Usuario.Perfiles;
using Modelos.Tuneflow.Usuario.Produccion;
using MVC.TUNEFLOW.Data;

namespace MVC.TUNEFLOW
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            Crud<Administrador>.EndPoint = "https://localhost:7031/api/Administradores";
            Crud<Album>.EndPoint = "https://localhost:7031/api/Albums";
            Crud<Cancion>.EndPoint = "https://localhost:7031/api/Canciones";
            Crud<CancionFavorita>.EndPoint = "https://localhost:7031/api/CancionesFavoritas";
            Crud<Artista>.EndPoint = "https://localhost:7031/api/Artistas";
            Crud<Cliente>.EndPoint = "https://localhost:7031/api/Clientes";
            Crud<EstadisticasArtista>.EndPoint = "https://localhost:7031/api/EstadisticasArtistas";
            Crud<MusicaPlaylist>.EndPoint = "https://localhost:7031/api/MusicasPlaylists";
            Crud<Pago>.EndPoint = "https://localhost:7031/api/Pagos";
            Crud<Perfil>.EndPoint = "https://localhost:7031/api/Perfiles";
            Crud<Reproduccion>.EndPoint = "https://localhost:7031/api/Reproducciones";
            Crud<Seguimiento>.EndPoint = "https://localhost:7031/api/Seguimientos";
            Crud<Suscripcion>.EndPoint = "https://localhost:7031/api/Suscripciones";
            Crud<TipoSuscripcion>.EndPoint = "https://localhost:7031/api/TiposSuscripciones";
            Crud<Playlist>.EndPoint = "https://localhost:7031/api/Playlists";
            Crud<Pais>.EndPoint = "https://localhost:7031/api/Paises";

            // Add services to the container.
            var connectionString = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            builder.Services.AddDbContext<TUNEFLOWContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));


            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
