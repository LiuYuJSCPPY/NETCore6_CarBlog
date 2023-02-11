using Car.Web.Inatface;
using Car.Web.Models;
using Car.Web.DataContext.Enum;
using Car.Web.DataContext;
using Car.Web.Areas.Dashbord.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Car.Web.Repository
{
    public class CarModelClassRepository : ICarModelClass
    {

        private readonly CarDataContext _carDataContext;

        public CarModelClassRepository(CarDataContext carDataContext)
        {
          _carDataContext = carDataContext;
        }

        public async Task<IEnumerable<CarModelClass>> CarModelAllCarModelClassesAsync(int CarModelId)
        {
            return await _carDataContext.CarModelClasse.Where(m => m.CarModelId == CarModelId).ToListAsync();

        }


        public async Task<CarModelClass> CarModelISCarModelClassAsync(int Id)
        {
            return await _carDataContext.CarModelClasse.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public  bool DeleteModelClasses(int Id)
        {
            bool Result = false;
      
            var DCarModelClass =  _carDataContext.CarModelClasse.Where(m => m.Id == Id).FirstOrDefault();

            if(DCarModelClass != null)
            {
                _carDataContext.CarModelClasse.Remove(DCarModelClass);
                Result = _carDataContext.SaveChanges() > 0;
            }

            return Result;
        }

        public bool SaveModelClasses(int CarModelId,CarModelClass CreateModelClass)
        {
            bool Result = false;

            var FCarModelClass = _carDataContext.CarModel.Find(CarModelId);

            if(FCarModelClass != null)
            {
                CreateModelClass.CarModelId = CarModelId;
                _carDataContext.Add(CreateModelClass);
                Result = _carDataContext.SaveChanges() > 0;

            }


            return Result;
        }
       
        public bool UpdateModelClasses(CarModelClass UpdateModelClass)
        {
            _carDataContext.Entry(UpdateModelClass).State = EntityState.Modified;
            return _carDataContext.SaveChanges() > 0;
        }
    }
}
