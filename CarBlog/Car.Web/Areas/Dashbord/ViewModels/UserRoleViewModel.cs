using Microsoft.AspNetCore.Identity;

namespace Car.Web.Areas.Dashbord.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
       
        public IEnumerable<IdentityRole> Role { get; set; }
        public IEnumerable<IdentityRole> UserRole { get; set; }


    }
}
