namespace Car.Web.Areas.Dashbord.ViewModels
{
    public class EditCarBandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCh { get; set; }
        public string CountryEn { get; set; }
        public string? ImageName { get; set; }

        public IFormFile? BandImagePath { get; set; }
    }
}
