using Car.Web.Models;
using Microsoft.EntityFrameworkCore;
using Car.Web.DataContext.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Car.Web.Areas.Dashbord.ViewModels
{
    public class IndexCarModelViewModel
    {
        public IEnumerable<CarModel> carModels { get; set; }

        [DisplayName("編號")]
        public int Id { get; set; }

        [DisplayName("名字")]
        public string Name { get; set; }

        [DisplayName("最低價")]
        public float? LowPrice { get; set; }

        [DisplayName("最高價")]
        public float? HighPrice { get; set; }

        [DisplayName("最低排氣量")]
        public int? LowDisclcament { get; set; }

        [DisplayName("最高排氣量")]
        public int? HighDisclcament { get; set; }

        [DisplayName("品牌")]
        public int CarBandId { get; set; }
        public CarBand carBand { get; set; }

        [DisplayName("車型")]
        public CarClass CarClass { get; set; }

        [DisplayName("排氣量")]
        public CarDisplacement CarDisplacement { get; set; }

        [DisplayName("能源")]
        public CarPower CarPower { get; set; }

        [DisplayName("車型大小")]
        public CarSize CarSize { get; set; }

        [DisplayName("熱門級距")]
        public HotLeveling? HotLeveling { get; set; }

        [DisplayName("豪華級距")]
        public LuxuryLeveling? LuxuryLeveling { get; set; }

        [DisplayName("其他級距")]
        public OrderLeveling? OrderLeveling { get; set; }

        [DisplayName("文章")]
        public string Content { get; set; }

        public virtual ICollection<CarModelImage> CarModelImages { get; set; }
        public virtual ICollection<CarModelClass>? CarModelClasses { get; set; }
    }
}
