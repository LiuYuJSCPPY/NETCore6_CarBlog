using Car.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car.Web.Inatface
{
    public interface ICarBand
    {
        List<SelectListItem> SelectListCarBand();

        Task<IEnumerable<CarBand>> ListCartBands();

        Task<CarBand> IsCarBandAsync(int Id);

        Task<CarBand?> IsCarBandAsyncAsTracking(int id);

        string SaveImage(IFormFile file);

        bool DeleteImage(string OldPathImage);

        bool Create(CarBand carBand);

        bool Update(CarBand carBand);
        bool Delete(int Id);

    }
}
