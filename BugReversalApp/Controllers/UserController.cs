using BugReversalApp.Models.Entities;
using BugReversalApp.Models.Enum;
using BugReversalApp.Data;
using BugReversalApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BulkReversal.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MakeUser()
        {
            return View();
        }

        public IActionResult Confirmed()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login"); 
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
 
            var find = _context.Users.FirstOrDefault(x => x.Email == user.Email);

            if (find == null || !BCrypt.Net.BCrypt.Verify(user.Password, find.Password))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(); 
            }

            HttpContext.Session.SetString("SessionId", Guid.NewGuid().ToString());
            HttpContext.Session.SetString("UserId", find.Id.ToString());

            return find.Privilege == UserRole.Maker
                ? RedirectToAction("MakeRequest", "Request")
                : RedirectToAction("ViewRequests", "Request");
           
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login"); 
        }
    }
}
