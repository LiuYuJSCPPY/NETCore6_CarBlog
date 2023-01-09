using Car.Web.Inatface;
using Car.Web.Models;
using Car.Web.DataContext.Enum;
using Car.Web.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Car.Web.Repository
{
    public class FontCarBlogSearchIndexRepository : IFontCarBlogSearchIndex
    {
        private readonly CarDataContext _carDataContext;
        public FontCarBlogSearchIndexRepository(CarDataContext carDataContext)
        {
            _carDataContext = carDataContext;
        }

        public async Task<IList<CarModel>> SearchAllcarModels()
        {
            return await _carDataContext.CarModel.Include(m => m.CarModelImage).ToListAsync();
        }

        public IList<CarModel> SearchCarClass(int[] Class, IList<CarModel> carModels)
        {
            List<CarModel> ListCarClass = new List<CarModel>();
           foreach (var carclass in Class)
            {
                var SerachClass =  carModels.Where(x => (int)x.CarClass == carclass).ToList();
                ListCarClass.AddRange(SerachClass);
               
               
               
            }
            return ListCarClass.ToList();
            
        }

        public IList<CarModel> SearchCarDisplacement(int[] Displacement, IList<CarModel> carModels)
        {
            List<CarModel> ListCarDisplacement = new List<CarModel>();
            foreach(var ADisplacmet in Displacement)
            {
                var SearchDiscplacement = carModels.Where(m => (int)m.CarDisplacement == ADisplacmet).ToList();
                ListCarDisplacement.AddRange(SearchDiscplacement);
            }
            return ListCarDisplacement.ToList();
        }

        public IList<CarModel> SearchCarPower(int[] Power, IList<CarModel> carModels)
        {
            List<CarModel> ListCarPower = new List<CarModel>();
            foreach(var Apower in Power)
            {
                var SearchCarPower = carModels.Where(m => (int)m.CarPower == Apower).ToList();
                ListCarPower.AddRange(SearchCarPower);

            }
            return ListCarPower.ToList();
        }

        public IList<CarModel> SearchPrice(int? MinPrice, int? MaxPrice, IList<CarModel> carModels)
        {
            List<CarModel> ListCarPrice = new List<CarModel>();
            if(MinPrice.HasValue && !MaxPrice.HasValue)
            {
                var MSearchPrice = carModels.Where(m => m.LowPrice >= MinPrice.Value).ToList();
                ListCarPrice.AddRange(MSearchPrice);

            }
            else if(!MinPrice.HasValue && MaxPrice.HasValue)
            {
                var MXSreachPrice = carModels.Where(m => m.HighPrice <= MaxPrice.Value).ToList();
                ListCarPrice.AddRange(MXSreachPrice);

            }
            else if(MinPrice.HasValue && MaxPrice.HasValue)
            {
                var SearchPrice = carModels.Where(m => m.LowPrice >= MinPrice.Value).Where(m => m.HighPrice <= MaxPrice.Value).ToList();
                ListCarPrice.AddRange(SearchPrice);
            }
            else
            {
                ListCarPrice = (List<CarModel>)carModels;
            }

            return ListCarPrice.ToList();
        }
        
        public IList<CarModel> SearchSize(int[] Size, IList<CarModel> carModels)
        {
            List<CarModel> SearchCarSize = new List<CarModel>();
            foreach(var ASize in Size)
            {
                var SearchSize = carModels.Where(m => (int)m.CarSize == ASize).ToList();
                SearchCarSize.AddRange(SearchSize);
            }
            return SearchCarSize.ToList();
        }

        public async Task<IList<CarModel>> CarModelBandAsync(int CarBandId)
        {
            
            return await _carDataContext.CarModel.Where(m => m.CarBandId == CarBandId).Include(m => m.CarModelImage).Include(m => m.CarModelClasses).ToListAsync();
            
        }

        public async Task<CarModel> GetCarModelGetIdAsync(int CarModelId)
        {
            return await _carDataContext.CarModel.Where(m => m.Id == CarModelId).Include(m => m.CarModelClasses).Include(m => m.CarModelImage).FirstOrDefaultAsync();
        }
    }
}
