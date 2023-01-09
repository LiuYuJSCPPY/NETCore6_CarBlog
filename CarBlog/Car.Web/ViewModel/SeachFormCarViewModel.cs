using System.ComponentModel;
using Car.Web.DataContext.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using Car.Web.Models;


namespace Car.Web.ViewModel
{
    public class SeachFormCarViewModel
    {
        public IEnumerable<CarModel> carModels { get; set; }

        [DisplayName("名字")]
        public string Name { get; set; }

        [DisplayName("最低價")]
        public float? LowPrice { get; set; }

        [DisplayName("最高價")]
        public float? HighPrice { get; set; }



        [DisplayName("車型")]
        public CarClass CarClass { get; set; }

        [DisplayName("排氣量")]
        public CarDisplacement CarDisplacement { get; set; }

        [DisplayName("能源")]
        public CarPower CarPower { get; set; }

        [DisplayName("車型大小")]
        public CarSize CarSize { get; set; }

        [DisplayName("熱門級距")]
        public HotLeveling HotLeveling { get; set; }

        [DisplayName("豪華級距")]
        public LuxuryLeveling LuxuryLeveling { get; set; }

        [DisplayName("其他級距")]
        public OrderLeveling OrderLeveling { get; set; }

        [DisplayName("文章")]
        public string Content { get; set; }

        public IEnumerable<CarBand> carBands { get; set; }
    }
}
