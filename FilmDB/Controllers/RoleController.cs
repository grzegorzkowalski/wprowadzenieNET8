using FilmDB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;   
        private UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var roles = _roleManager.Roles;
            var user = await _userManager.GetUserAsync(User);
            var userRoles = await _userManager.GetRolesAsync(user);
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRole addRole) 
        {
            var newRole = new IdentityRole(addRole.Name);
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            { 
                return RedirectToAction("Index");
            }
            else
            {
                return View(addRole);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUserToRole()
        {
            var roles = _roleManager.Roles;
            var users = _userManager.Users;
            RolesAndUsers rau = new RolesAndUsers() 
            { 
                Roles = roles,
                Users = users
            };
            return View(rau);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserRols(string userNamew, List<string> Roles) 
        {
            var user = await _userManager.FindByNameAsync(userNamew);
            foreach (var role in Roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserToRole(List<string> Roles, List<string> Users)
        {
            foreach (var item in Users)
            {
                await AddUserRols(item, Roles);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveRole()
        {
            ViewBag.Roles = _roleManager.Roles;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole(string Name)
        {
            var roleToDelete = await _roleManager.FindByNameAsync(Name);

            if (roleToDelete != null)
            {
                var result = await _roleManager.DeleteAsync(roleToDelete);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
