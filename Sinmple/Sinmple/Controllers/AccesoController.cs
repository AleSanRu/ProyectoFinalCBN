using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Sinmple.Models;
using Sinmple.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sinmple.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuarios usuario)
        {
            DataUsuario dataUsuario = new DataUsuario();
            var usuarioValidado = dataUsuario.ValidaUsuario(usuario.Correo, usuario.Clave);

            if (usuarioValidado != null)
            {
                // Configurar las claims para el usuario autenticado
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioValidado.Nombre),
                    new Claim("Correo", usuarioValidado.Correo),
                };

                foreach (var rol in usuarioValidado.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                // Crear la identidad del usuario
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Iniciar sesión del usuario
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Redireccionar al controlador "Home" y acción "Index"
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Usuario no válido, volver a la vista de acceso
                return View();
            }
        }
        public async Task<IActionResult> Salir()
        {
            //3.- CONFIGURACION DE LA AUTENTICACION
            #region AUTENTICACTION
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            return RedirectToAction("Index");

        }
    }
}
