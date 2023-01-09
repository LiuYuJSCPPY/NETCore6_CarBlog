using Microsoft.EntityFrameworkCore;
using Car.Web.Models;
using Car.Web.Areas.Dashbord.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Car.Web.DataContext
{
    public class CarDataContext : IdentityDbContext<CarUser>
    {
        public CarDataContext(DbContextOptions<CarDataContext> options) : base(options)
        {

        }

        public DbSet<CarBand> CarBand { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<CarModelClass> CarModelClasse { get; set; }
        public DbSet<CarModelImage> CarModelImage { get; set; }
        public DbSet<CarModelPostImage> CarModelPostImage { get; set; }
    }
}
