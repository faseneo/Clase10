using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Clase10.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clase10.Controllers;

public class HomeController : Controller{
    //[Authorize]
    public IActionResult Dashboard(){
        // Comprobar el estado de la sesión
        var user = HttpContext.Session.GetString("User");
        if (string.IsNullOrEmpty(user)){
            // Si no hay un usuario en la sesión, redirige al login
            return RedirectToAction("Login");
            }
        return View();
        }
    }
