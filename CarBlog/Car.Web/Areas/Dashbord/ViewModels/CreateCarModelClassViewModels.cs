using System.ComponentModel;
using Car.Web.DataContext.Enum;
using Car.Web.Models;
namespace Car.Web.Areas.Dashbord.ViewModels
{
    public class CreateCarModelClassViewModels
    {
        [DisplayName("編號")]
        public int Id { get; set; }
        [DisplayName("名字")]
        public string Name { get; set; }

        [DisplayName("售價(萬)")]
        public float Pirce { get; set; }

        [DisplayName("排氣量(c.c)")]
        public int? Disclcament { get; set; }

        [DisplayName("燃料")]
        public CarPower CarPower { get; set; }

        [DisplayName("引擎型式")]
        public string EngineClass { get; set; }

        [DisplayName("變速系統")]
        public string Shifting { get; set; }

        [DisplayName("傳動方式")]
        public string Driventrain { get; set; }

        [DisplayName("馬力")]
        public int? Ps { get; set; }

        [DisplayName("轉速")]
        public int? Rpm { get; set; }

        [DisplayName("平均油耗 km/L(歐)")]
        public float? Kml { get; set; }

        [DisplayName("燃料稅")]
        public int? Burn { get; set; }

        [DisplayName("牌照稅")]
        public int? Brand { get; set; }


        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
    }
}
