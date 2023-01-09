using Car.Web.Models;
namespace Car.Web.Areas.Dashbord.ViewModels
{
    public class IndexCarBandViewModel
    {
        public IEnumerable<CarBand> carBands { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCh { get; set; }
        public string CountryEn { get; set; }
        public string? ImageName { get; set; }
    }
}
