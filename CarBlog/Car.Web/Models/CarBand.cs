using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Car.Web.Models
{
    [Table("CarBand",Schema ="dbo")]
    public class CarBand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCh { get; set; } 
        public string? BandImagePath { get; set; }
        public string CountryEn { get; set; }
       



        public ICollection<CarModel> CarModels { get; set; }
        
    }
}
