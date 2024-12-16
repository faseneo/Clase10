using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;

namespace Clase10.Models{
    public class AuthController : Controller{
        private readonly MongoDbContext _context;
        public AuthController(MongoDbContext context){
            _context = context;
            }
        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(string username, string password){
            var user = _context.Users.Find(u => u.Username == username).FirstOrDefault();
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)){
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Dashboard", "Home");
                }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
            }

        public IActionResult Register() => View();
        [HttpPost]
        public IActionResult Register(User user){
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.InsertOne(user);
            return RedirectToAction("Login");
            }
        public IActionResult Logout(){
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
            }
        }
    }
