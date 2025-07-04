using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using API.Consumer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Modelos.Tuneflow.Modelos;
using Modelos.Tuneflow.Usuario.Consumidor;

namespace MVC.TUNEFLOW.Areas.Identity.Pages.Account
{
    public class RegisterClienteModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterClienteModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly TUNEFLOWContext _context;

        public RegisterClienteModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterClienteModel> logger,
            IEmailSender emailSender,
            TUNEFLOWContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public List<SelectListItem> Paises { get; set; }

        public class InputModel
        {
            [Required, Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Required, Display(Name = "Apellido")]
            public string Apellido { get; set; }

            [Required, EmailAddress, Display(Name = "Email")]
            public string Email { get; set; }

            [Required, Phone, Display(Name = "Teléfono")]
            public string Telefono { get; set; }

            [Required, Display(Name = "País")]
            public int PaisId { get; set; }

            [DataType(DataType.Date), Display(Name = "Fecha de nacimiento")]
            public DateTime FechaNacimiento { get; set; }

            [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            Paises = await GetPaisesAsync();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid)
            {
                Paises = await GetPaisesAsync();
                return Page();
            }

            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                Paises = await GetPaisesAsync();
                return Page();
            }

            _logger.LogInformation("Cliente registrado correctamente.");

            // Crear suscripción básica
            var suscripcion = new Suscripcion
            {
                FechaInicio = DateTime.UtcNow,
                TipoSuscripcionId = 1 // Básica por defecto
            };
            _context.Suscripciones.Add(suscripcion);
            await _context.SaveChangesAsync();

            // Crear cliente
            var cliente = new Cliente
            {
                Nombre = Input.Nombre,
                Apellido = Input.Apellido,
                Email = Input.Email,
                Telefono = Input.Telefono,
                PaisId = Input.PaisId,
                FechaNacimiento = Input.FechaNacimiento.ToUniversalTime(),
                TipoCuenta = "Cliente",
                Activo = true,
                FechaRegistro = DateTime.UtcNow,
                SuscripcionId = suscripcion.Id
            };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, "cliente");

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                null,
                new { area = "Identity", userId = userId, code = code, returnUrl },
                Request.Scheme);

            await _emailSender.SendEmailAsync(Input.Email, "Confirma tu cuenta",
                $"Por favor confirma tu cuenta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>aquí</a>.");

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
                return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });

            await _signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect(returnUrl);
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"No se pudo crear '{nameof(IdentityUser)}'. Asegúrate de que tiene constructor vacío.");
            }
        }

        private async Task<List<SelectListItem>> GetPaisesAsync()
        {
            var paises = await Crud<Pais>.GetAllAsync();
            return paises.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
                throw new NotSupportedException("El UserManager no soporta email.");
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
