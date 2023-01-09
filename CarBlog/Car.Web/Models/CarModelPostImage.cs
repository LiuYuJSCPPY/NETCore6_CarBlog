using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Car.Web.Models
{
    [Table("CarModelPostImage",Schema ="dbo")]
    public class CarModelPostImage
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public string ImagePath { get; set; }

    }
}
