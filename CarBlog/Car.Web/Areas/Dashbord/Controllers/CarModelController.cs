using Microsoft.AspNetCore.Mvc;
using Car.Web.DataContext.Enum;
using Car.Web.DataContext;
using Car.Web.Models;
using Car.Web.Inatface;
using Car.Web.Areas.Dashbord.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Car.Web.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class CarModelController : Controller
    {
        private readonly ICarModel _carModel;
        private readonly ICarBand _carBand;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CarModelController(ICarModel carModel, ICarBand carBand, IWebHostEnvironment webHostEnvironment)
        {
            _carModel = carModel;
            _carBand = carBand;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexCarModelViewModel indexCarModelViewModel = new IndexCarModelViewModel();
            indexCarModelViewModel.carModels = await _carModel.GetAllAsnyc();
            return View(indexCarModelViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateCarModelViewModel CarModelViewModel = new CreateCarModelViewModel();
            CarModelViewModel.CarBands = _carBand.SelectListCarBand();
            return View(CarModelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarModelViewModel createCarModelViewModel)
        {
            bool Result = false;
   
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Found");
            }

            CarModel CreateCarModel = new CarModel
            {
                Name = createCarModelViewModel.Name,
                LowPrice = createCarModelViewModel.LowPrice,
                HighPrice = createCarModelViewModel.HighPrice,
                LowDisclcament = createCarModelViewModel.LowDisclcament,
                HighDisclcament = createCarModelViewModel.HighDisclcament,
                CarBandId = createCarModelViewModel.CarBandId,
                CarClass = createCarModelViewModel.CarClass,
                CarDisplacement = createCarModelViewModel.CarDisplacement,
                CarPower = createCarModelViewModel.CarPower,
                CarSize = createCarModelViewModel.CarSize,
                HotLeveling = createCarModelViewModel.HotLeveling,
                LuxuryLeveling = createCarModelViewModel.LuxuryLeveling,
                OrderLeveling = createCarModelViewModel.OrderLeveling,
                Content = createCarModelViewModel.Content,
            };

            Result = _carModel.Create(CreateCarModel);

            if (Result && createCarModelViewModel.CarModelImages != null)
            {
                _carModel.SaveCarModelImage(CreateCarModel.Id, createCarModelViewModel.CarModelImages);
            }

            if (Result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> UploadPostImage(List<IFormFile> Files)
        {              
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/CarModelPost/Images");
            string filepath = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (Files != null)
            {
                foreach (var file in Files)
                {
                    string FileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string SavePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files/CarModelPost/Images", FileName);
                    using (var SavePost = new FileStream(SavePath, FileMode.Create))
                    {
                        file.CopyTo(SavePost);
                    }
                    filepath = "https://localhost:44391/" + "Files/CarModelPost/Images/" + FileName;
                }
                
            }

            return Json(new {url = filepath });
        }

        [HttpGet]
        public async Task<IActionResult> Detail (int Id)
        {
            var carModel = await _carModel.GetByIdAsnyc(Id);
            return View(carModel);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {


          var EditModel = await _carModel.GetByIdAsnyc(Id);

            EditCarModelViewModels EditModelViewModel = new EditCarModelViewModels {
                Id = EditModel.Id,
                Name = EditModel.Name,
                LowPrice = EditModel.LowPrice,
                HighPrice = EditModel.HighPrice,
                LowDisclcament = EditModel.LowDisclcament,
                HighDisclcament = EditModel.HighDisclcament,
                CarBandId = EditModel.CarBandId,
                CarClass = EditModel.CarClass,
                CarDisplacement = EditModel.CarDisplacement,
                CarPower = EditModel.CarPower,
                CarSize = EditModel.CarSize,
                HotLeveling = (HotLeveling)EditModel.HotLeveling,
                LuxuryLeveling = (LuxuryLeveling)EditModel.LuxuryLeveling,
                OrderLeveling = (OrderLeveling)EditModel.OrderLeveling,
                Content = EditModel.Content,
                CarBands = _carBand.SelectListCarBand(),
             };
            

            return View(EditModelViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id,CarModel carModel)
        {
            _carModel.Update(carModel);
            

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<JsonResult> Delete(int id)
        {
            bool Result = false;

             Result = _carModel.Delete(id);
            if (Result)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });

            }
           
        }

    }
}
