using Car.Web.Models;

namespace Car.Web.Inatface
{
    public interface ICarModel
    {
        Task<IEnumerable<CarModel>> GetAllAsnyc();
        Task<CarModel?> GetByIdAsnyc(int Id);
        Task<CarModel?> GetByIdAsnycNoTracking(int Id);


        bool SaveCarModelImage(int Id,List<IFormFile> formFiles);
    
        bool Create(CarModel carModel);
        bool Update(CarModel carModel);
        bool Delete(int Id);
    }
}
