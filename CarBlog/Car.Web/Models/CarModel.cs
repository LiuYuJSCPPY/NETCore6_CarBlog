using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Car.Web.DataContext.Enum;

namespace Car.Web.Models
{
    [Table("CarModel",Schema ="dbo")]
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? LowPrice { get; set; }
        public float? HighPrice { get; set; }
        public int? LowDisclcament { get; set; }
        public int? HighDisclcament { get; set; }

        public int CarBandId { get; set; }

        public CarBand CarBand { get; set; }

        public CarClass CarClass { get; set; }
        public CarDisplacement CarDisplacement { get; set; }
        public CarPower CarPower { get; set; }
        public CarSize CarSize { get; set; }
        public HotLeveling? HotLeveling { get; set; }
        public LuxuryLeveling? LuxuryLeveling { get; set; }
        public OrderLeveling? OrderLeveling { get; set; }
        public string Content { get; set; }


        public virtual ICollection<CarModelImage> CarModelImage { get; set; }
        public virtual ICollection<CarModelPostImage> CarModelPostImages { get; set; }
        public virtual ICollection<CarModelClass> CarModelClasses { get; set; }
    }
}
