using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Car.Web.Areas.Dashbord.ViewModels;
using Car.Web.Models;
using Car.Web.DataContext;
namespace Car.Web.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CarUser> _userManager;
        private readonly SignInManager<CarUser> _signInManager;
        public UserController(RoleManager<IdentityRole> roleManager,UserManager<CarUser> userManager, SignInManager<CarUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserToList()
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            var AllUsers = _userManager.Users.ToList();
            foreach(var user in AllUsers){
                userViewModels.Add(new UserViewModel
                {
                    carUser = user,
                    RoleName = String.Join("",await _userManager.GetRolesAsync(user))
                });
            }
            return View(userViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var DeleteUser = await _userManager.FindByIdAsync(Id);
            if(DeleteUser == null)
            {
                return NotFound();
            }
            return View(DeleteUser);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Id , CarUser carUser)
        {
            
            var user = await _userManager.FindByIdAsync(Id);
            
            var ResultUser = await _userManager.DeleteAsync(user);
            if (ResultUser.Succeeded)
            {
                return RedirectToAction("UserToList");
            }
            else
            {
                return NotFound();
            }
        }




    }
}
