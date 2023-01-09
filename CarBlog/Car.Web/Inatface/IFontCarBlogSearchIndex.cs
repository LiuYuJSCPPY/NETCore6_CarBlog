using Car.Web.Models;

namespace Car.Web.Inatface
{
    public interface IFontCarBlogSearchIndex
    {
        Task<IList<CarModel>> SearchAllcarModels();
        IList<CarModel> SearchCarClass(int[] Class, IList<CarModel> carModels);
        IList<CarModel> SearchCarDisplacement(int[] Displacement, IList<CarModel> carModels);
        IList<CarModel> SearchCarPower(int[] Power, IList<CarModel> carModels);
        IList<CarModel> SearchSize(int[] Size, IList<CarModel> carModels);
        IList<CarModel> SearchPrice(int? MinPrice, int? MaxPrice, IList<CarModel> carModels);
        Task<IList<CarModel>> CarModelBandAsync(int CarBandId);

        Task<CarModel> GetCarModelGetIdAsync(int CarModelId);
    }
}
