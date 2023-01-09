using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Car.Web.DataContext.Enum;

namespace Car.Web.Models
{
    [Table("CarModelClass",Schema ="dbo")]
    public class CarModelClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Pirce { get; set; }
        public int? Disclcament { get; set; }
        public CarPower CarPower { get; set; }
        public string EngineClass { get; set; }
        public string Shifting { get; set; }
        public string Driventrain { get; set; }
        public int? Ps { get; set; }
        public int? Rpm { get; set; }
        public float? Kml { get; set; }
        public int? Burn { get; set; }
        public int? Brand { get; set; }

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

    }
}
