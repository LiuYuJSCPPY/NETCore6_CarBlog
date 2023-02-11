using Car.Web.Inatface;
using Car.Web.Models;
using Microsoft.EntityFrameworkCore;
using Car.Web.DataContext;
using Car.Web.DataContext.Enum;

namespace Car.Web.Repository
{
    public class CarModelRepository : ICarModel
    {
        private readonly CarDataContext _carDataContext;
        private readonly IWebHostEnvironment _webHostBuilder;

        public CarModelRepository(CarDataContext carDataContext, IWebHostEnvironment webHostBuilder)
        {
            _carDataContext = carDataContext;
            _webHostBuilder = webHostBuilder;
        }

      

        public async Task<IEnumerable<CarModel>> GetAllAsnyc()
        {
            return await _carDataContext.CarModel.Include(m => m.CarBand).Include(m => m.CarModelClasses).Include(m => m.CarModelImage).ToListAsync();
        }

        public async Task<CarModel?> GetByIdAsnyc(int Id)
        {
            return await _carDataContext.CarModel.Include(m => m.CarModelClasses).FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<CarModel?> GetByIdAsnycNoTracking(int Id)
        {
            return await _carDataContext.CarModel.AsNoTracking().FirstOrDefaultAsync(m => m.Id == Id);
        }

        public bool SaveCarModelImage(int Id, List<IFormFile> formFiles)
        {
            List<CarModelImage> CarModelImages = new List<CarModelImage>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/CarModel/Images");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            foreach(var File in formFiles)
            {
                string FileName = Guid.NewGuid().ToString()+"-" + File.FileName;
                string SavePath = Path.Combine(_webHostBuilder.WebRootPath, "Files/CarModel/Images", FileName);
                using (var steam = new FileStream(SavePath, FileMode.Create))
                {
                    File.CopyTo(steam);
                }
                CarModelImages.Add(new CarModelImage { CarModelId = Id, ImagePath = FileName });
            }

            _carDataContext.CarModelImage.AddRange(CarModelImages);
            return _carDataContext.SaveChanges() > 0;

        }

        public bool DeleteCarModelImage(int Id, List<CarModelImage> DeleteIamges)
        {
            

            foreach (var DeleteIamge in DeleteIamges)
            {
                
                string DeletePath = Path.Combine(_webHostBuilder.WebRootPath, "Files/CarModel/Images", DeleteIamge.ImagePath);
                if (Directory.Exists(DeletePath))
                {
                    Directory.Delete(DeletePath);
                }
            }

            
            _carDataContext.RemoveRange(DeleteIamges);
            return _carDataContext.SaveChanges() > 0;

        }

        public bool Create(CarModel carModel)
        {
            _carDataContext.Add(carModel);
            return _carDataContext.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            CarModel DeleteCarModel = _carDataContext.CarModel.Include(x => x.CarModelClasses).Include(x => x.CarModelImage).FirstOrDefault(x => x.Id == Id);
            
            if (DeleteCarModel == null)
            {
                return false;

            }
            DeleteCarModelImage(Id, DeleteCarModel.CarModelImage.ToList());
            
            _carDataContext.Remove(DeleteCarModel);
            return _carDataContext.SaveChanges() > 0;
        }
        public bool Update(CarModel carModel)
        {
            _carDataContext.Entry(carModel).State = EntityState.Modified;
            return _carDataContext.SaveChanges() > 0;
        }
    }
}
