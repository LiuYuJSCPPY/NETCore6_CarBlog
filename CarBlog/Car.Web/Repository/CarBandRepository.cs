using Microsoft.EntityFrameworkCore;
using Car.Web.DataContext;
using Car.Web.DataContext.Enum;
using Car.Web.Inatface;
using Car.Web.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car.Web.Repository
{
    public class CarBandRepository : ICarBand
    {
        private readonly CarDataContext _carDataContext;
        private readonly IWebHostEnvironment _environment;

        public CarBandRepository(CarDataContext carDataContext,IWebHostEnvironment environment)
        {
            _carDataContext = carDataContext;
            _environment = environment;
        }
        public async Task<IEnumerable<CarBand>> ListCartBands()
        {
            return await _carDataContext.CarBand.ToListAsync();
        }

        public async Task<CarBand> IsCarBandAsync(int Id)
        {
            CarBand oneCarBand = await _carDataContext.CarBand.FindAsync(Id);
            return oneCarBand;
        }


        public List<SelectListItem> SelectListCarBand()
        {
            var CarBandAll = _carDataContext.CarBand.ToList();
            var SelectListCarModel = new List<SelectListItem>();

            foreach(var CarBand in CarBandAll)
            {
                SelectListItem AddSelectListItem = new SelectListItem();

                AddSelectListItem.Value = CarBand.Id.ToString();
                AddSelectListItem.Text = CarBand.Name;
                SelectListCarModel.Add(AddSelectListItem);

            }

            return SelectListCarModel;
        }






        public string SaveImage(IFormFile file)
        {
            

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/CarBand/Images");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
           
            string fileName =  Guid.NewGuid().ToString()+"-"+ file.FileName;
            string SavePath = Path.Combine(_environment.WebRootPath, "Files/CarBand/Images", fileName);
            using(var stream = new FileStream(SavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        public bool DeleteImage(string OldPathImage)
        {
            bool result = false;
            if(OldPathImage != null)
            {
                string DeleteImage = Path.Combine(_environment.WebRootPath, "Files/CarBand/Images", OldPathImage);
                File.Delete(DeleteImage);
                result = true;
            }
            return result;
        }
        public bool Create(CarBand carBand )
        {
          
            _carDataContext.Add(carBand);
            int id = carBand.Id;
            return _carDataContext.SaveChanges() > 0;
        }

        public bool Update(CarBand carBand)
        {

            _carDataContext.Update(carBand);
            return _carDataContext.SaveChanges() > 0;
        }
        
        public bool Delete(int Id)
        {
            
      
            bool Result = false;
            CarBand DeleteCB = _carDataContext.CarBand.Where(m => m.Id == Id).First();
            if(DeleteCB.BandImagePath != null)
            {
                DeleteImage(DeleteCB.BandImagePath);
            }
            _carDataContext.Remove(DeleteCB);
            Result = _carDataContext.SaveChanges() > 0;
           
            return Result;

        }

        public async Task<CarBand?> IsCarBandAsyncAsTracking(int id)
        {
            return await _carDataContext.CarBand.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
