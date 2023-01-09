using System.ComponentModel.DataAnnotations;
using Car.Web.DataContext.Enum;

namespace Car.Web.ViewModel
{
    public class FontUserSettingViewModel
    {
        public string Id { get; set; }

        [Display(Name = "手機")]
        public string? Cellphone { get; set; }

        
        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        
        [Display(Name = "城市")]
        public CountyCity county { get; set; }

       
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "性別")]
        public bool male { get; set; }

        [Display(Name = "圖片")]
        public string ImagePath { get; set; }
    }
}
