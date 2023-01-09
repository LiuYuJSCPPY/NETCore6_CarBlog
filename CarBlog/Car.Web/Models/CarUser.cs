using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Car.Web.DataContext.Enum;


namespace Car.Web.Models
{
    public class CarUser : IdentityUser
    {
        public string? Cellphone { get; set; }
        public string? FullName { get; set; }
        public DateTime? Birthday { get; set; } 
        public CountyCity county { get; set; }
        public string? Address { get; set; }
        public bool? male { get; set; }
        public string? UserImage { get; set; }

        
    }
}
