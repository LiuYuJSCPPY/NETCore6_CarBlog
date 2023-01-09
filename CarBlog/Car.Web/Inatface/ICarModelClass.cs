using Car.Web.Models;

namespace Car.Web.Inatface
{
    public interface ICarModelClass
    {

        Task<IEnumerable<CarModelClass>> CarModelAllCarModelClassesAsync(int CarModelId);

        Task<CarModelClass> CarModelISCarModelClassAsync(int CarClassId);

        public bool SaveModelClasses(int CarModelId, CarModelClass CreateModelClass);

        public bool UpdateModelClasses(CarModelClass UpdateModelClass);
        public bool DeleteModelClasses(int Id);

    }
}
