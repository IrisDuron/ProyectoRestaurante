using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace ProyectoRestaurante.Controllers
{
    public class LoginController : Controller
    {
        private readonly Config _configuracion;
        private ILoginRepositorio _loginRepositorio;
        private IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(Config config)
        {
            _configuracion = config;
            _loginRepositorio = new LoginRepositorio(config.CadenaConexion);
            _usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);
        }

        [HttpPost("/account/login")]
        public async Task<IActionResult> Login(Login login)
        {
            string rol = string.Empty;

            try
            {
                bool usuarioValido = await _loginRepositorio.ValidarUsuario(login);

                if (usuarioValido)
                {
                    Usuario user = await _usuarioRepositorio.GetPorCodigo(login.CodigoUsuario);

                    if (user.EstaActivo == 1)
                    {
                        rol = user.Rol;

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, user.CodigoUsuario),
                            new Claim(ClaimTypes.Role, rol)
                        };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(5) });
                    }
                    else
                    {
                        return LocalRedirect("/login/UsuarioInactivo");
                    }
                }
                else
                {
                    return LocalRedirect("/login/UsuarioInvalido");
                }
            }
            catch (Exception ex)
            {
            }
            return LocalRedirect("/");
        }

        [HttpGet("/account/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/login");
        }
    }
}
