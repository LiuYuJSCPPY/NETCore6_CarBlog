namespace Car.Web.Areas.Dashbord.ViewModels
{
    public class CreateCarBand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCh { get; set; }
        public string CountryEn { get; set; }
        public IFormFile BandImagePath { get; set; }
    }
}
