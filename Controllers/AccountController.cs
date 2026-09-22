using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firmeza.AppWeb.data;
using Firmeza.AppWeb.ViewModels;
using Firmeza.AppWeb.Models;

namespace Firmeza.AppWeb.Controllers;

/// <summary>
/// Controlador encargado de la autenticación de usuarios.
/// Valida las credenciales contra la tabla 'usuarios' y redirige
/// según el rol del usuario (Admin -> Departamentos, Cliente -> Home).
/// </summary>
public class AccountController : Controller
{
    /// <summary>
    /// Contexto de base de datos inyectado por el contenedor de dependencias,
    /// usado para consultar la tabla de usuarios.
    /// </summary>
    private readonly ApplicationsDbContext _context;

    public AccountController(ApplicationsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Muestra el formulario de inicio de sesión (vista vacía, sin datos).
    /// </summary>
    /// <returns>La vista Login con un LoginViewModel vacío.</returns>
    // GET
    public IActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// Procesa el envío del formulario de login: valida el modelo,
    /// busca al usuario por correo, verifica la contraseña contra el hash
    /// almacenado (BCrypt) y redirige según su rol si las credenciales son correctas.
    /// </summary>
    /// <param name="model">Datos del formulario (correo, contraseña, recordar sesión).</param>
    /// <returns>
    /// Redirige a Departamentos si es Admin, a Home si es Cliente,
    /// o vuelve a mostrar el formulario con errores si algo falla.
    /// </returns>
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        // Si las validaciones del ViewModel (Required, EmailAddress, etc.) fallan,
        // se regresa a la misma vista mostrando los mensajes de error.
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Se busca un usuario activo cuyo correo coincida con el ingresado.
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == model.Email && u.IsActive);

        // Si no existe el usuario, o la contraseña no coincide con el hash guardado,
        // se rechaza el login sin especificar cuál de los dos falló (por seguridad).
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(model.Password, usuario.PasswordHash))
        {
            ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos");
            return View(model);
        }

        // Login válido - por ahora solo redirigimos.
        // La sesión real (cookies + [Authorize]) la armamos en el siguiente paso.
        TempData["Success"] = $"Bienvenido, {usuario.FullName}";

        // Redirección según el rol: el Admin de Departamento va a la gestión
        // de departamentos, mientras que el Cliente va a la página de inicio.
        return usuario.Role == UserRole.Admin
            ? RedirectToAction("Index", "Department")
            : RedirectToAction("Index", "Home");
    }
}