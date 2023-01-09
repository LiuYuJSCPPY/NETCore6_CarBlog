using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Car.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Car.Web.ViewModel;

namespace Car.Web.Controllers
{
    
    public class FontCarBlogUserController : Controller
    {
        private readonly UserManager<CarUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly SignInManager<CarUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FontCarBlogUserController(UserManager<CarUser> userManger , RoleManager<IdentityRole> roleManager, SignInManager<CarUser> signInManager,IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManger;
            _roleManger = roleManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("CarBlog/User/Setting")]
        public async Task<IActionResult> FontUserSetting()
        {

            if (_signInManager.IsSignedIn(User))
            {
                FontUserSettingViewModel Model = new FontUserSettingViewModel()
                {
                    Id = _signInManager.UserManager.Users.First().Id,
                    Cellphone = _signInManager.UserManager.Users.First().Cellphone,
                    FullName = _signInManager.UserManager.Users.First().FullName,
                    Birthday = _signInManager.UserManager.Users.First().Birthday,
                    county = _signInManager.UserManager.Users.First().county,
                    Address = _signInManager.UserManager.Users.First().Address,
                    male = (bool)_signInManager.UserManager.Users.First().male,
                    ImagePath = _signInManager.UserManager.Users.First().UserImage,

                };
              
                return View(Model);
            }
            else
            {
                return RedirectToAction("SearchIndex", "FondCarBlog", new { Areas = "" });
            }

        }

        [HttpPost]
        [Route("CarBlog/User/Setting")]
        public async Task<IActionResult> FontUserSetting(FontUserSettingViewModel EditcarUser, IFormFile fileImage)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/User/Images");
           
            string filePath = "";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            if (_signInManager.IsSignedIn(User))
            {
                string FileName = Guid.NewGuid().ToString() + "-" + fileImage.FileName;
                string SavePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files/User/Images", FileName);
                using(var SavePost = new FileStream(SavePath, FileMode.Create))
                {
                    fileImage.CopyTo(SavePost);
                }

               
                 var EditId = _signInManager.UserManager.Users.First().Id;
                var EditUser = _userManager.Users.FirstOrDefault(x => x.Id == EditId);

                EditUser.Cellphone = EditcarUser.Cellphone;
                EditUser.FullName = EditcarUser.FullName;
                EditUser.Birthday = EditcarUser?.Birthday;
                EditUser.county = EditcarUser.county;
                EditUser.Address = EditcarUser.Address;
                EditUser.male = EditcarUser.male;
                EditUser.UserImage = FileName;



               var userModel = await _userManager.UpdateAsync(EditUser);
               

                return RedirectToAction("SearchIndex", "FondCarBlog", new { Areas = "" });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
