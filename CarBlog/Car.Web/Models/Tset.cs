using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Car.Web.Models
{
    
    [Table("Tset", Schema = "dbo")]
    public class Tset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCh { get; set; }
        public string? BandImagePath { get; set; }
        public string CountryEn { get; set; }

    }
}
