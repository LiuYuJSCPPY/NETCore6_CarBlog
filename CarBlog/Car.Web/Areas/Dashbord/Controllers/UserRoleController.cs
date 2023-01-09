using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Car.Web.Areas.Dashbord.ViewModels;
using Car.Web.Models;
namespace Car.Web.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class UserRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CarUser> _userManager;
        public UserRoleController(RoleManager<IdentityRole> roleManager, UserManager<CarUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult RoleList()
        {
            var roleList = _roleManager.Roles;
            return View(roleList);
        }


        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModels Model)
        {
            var roleResult = await _roleManager.RoleExistsAsync(Model.Name);
            if (!roleResult)
            {
                var test = await _roleManager.CreateAsync(new IdentityRole(Model.Name));
                
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(Id);
            if(role == null)
            {
                return NotFound();

            }
            else
            {
                ViewBag.User = await _userManager.GetUsersInRoleAsync(role.Name);
            }
           
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(IdentityRole Model)
        {
            if(Model == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _roleManager.UpdateAsync(Model);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
