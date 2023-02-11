using Microsoft.AspNetCore.Mvc;
using Car.Web.Inatface;
using Car.Web.DataContext.Enum;
using Car.Web.Areas.Dashbord.ViewModels;
using Car.Web.Models;



namespace Car.Web.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class CarModelClassController : Controller
    {

        private readonly ICarModelClass _CarModelClass;
        private readonly ICarModel _carModel;
        public CarModelClassController(ICarModelClass CarModelClass,ICarModel CarModel)
        {
            _CarModelClass = CarModelClass;
            _carModel = CarModel;
        }


        [HttpGet]
        [Route("{CarModelId:int}/IndexCarModelClass")]
        public async Task<IActionResult> Index(int CarModelId)
        {
            IndexCarModelClassViewModels indexCarModelClassViewModels = new IndexCarModelClassViewModels
            {
                carModelClasses = await _CarModelClass.CarModelAllCarModelClassesAsync(CarModelId),
                CarModelId = CarModelId,
            };
            return View(indexCarModelClassViewModels);
        }





        [HttpGet]
        [Route("{CarModelId:int}/CarModelClass/Create")]
        public async Task<IActionResult> Create(int CarModelId)
        {
            CreateCarModelClassViewModels createCarModelClassViewModels = new CreateCarModelClassViewModels();

            createCarModelClassViewModels.CarModelId = CarModelId;
            createCarModelClassViewModels.CarModel = await _carModel.GetByIdAsnycNoTracking(CarModelId);

            return View(createCarModelClassViewModels);
        }

        [HttpPost]
        [Route("{CarModelId:int}/CarModelClass/Create")]
        public async Task<IActionResult> Create(int CarModelId, CarModelClass carModelClass)
        {
            
            carModelClass.CarModelId = CarModelId;
            bool Result = false;
            Result = _CarModelClass.SaveModelClasses(CarModelId, carModelClass);

            if (Result)
            {
                return RedirectToAction("Index", "CarModelClass", new { CarModelId = CarModelId });
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("{CarModelId:int}/CarModelClass/Edit")]
        public async Task<IActionResult> Edit(int CarModelId, int CarModelClassId)
        {
            ActionCarModelClasseViewModel actionCarModelClasseViewModel = new ActionCarModelClasseViewModel();

            CarModelClass FindCarModelClass = await _CarModelClass.CarModelISCarModelClassAsync(CarModelClassId);
            actionCarModelClasseViewModel.Id = CarModelClassId;
            actionCarModelClasseViewModel.Name = FindCarModelClass.Name;
            actionCarModelClasseViewModel.Pirce = FindCarModelClass.Pirce;
            actionCarModelClasseViewModel.Disclcament = FindCarModelClass.Disclcament;
            actionCarModelClasseViewModel.CarPower = FindCarModelClass.CarPower;
            actionCarModelClasseViewModel.EngineClass = FindCarModelClass.EngineClass;
            actionCarModelClasseViewModel.Shifting = FindCarModelClass.Shifting;
            actionCarModelClasseViewModel.Driventrain = FindCarModelClass.Driventrain;
            actionCarModelClasseViewModel.Ps = FindCarModelClass.Ps;
            actionCarModelClasseViewModel.Rpm = FindCarModelClass.Rpm;
            actionCarModelClasseViewModel.Kml = FindCarModelClass.Kml;
            actionCarModelClasseViewModel.Burn = FindCarModelClass.Burn;
            actionCarModelClasseViewModel.Brand = FindCarModelClass.Brand;
            actionCarModelClasseViewModel.CarModelId = CarModelId;
            actionCarModelClasseViewModel.carModel = await _carModel.GetByIdAsnycNoTracking(CarModelId);

            return View(actionCarModelClasseViewModel);
        }

        [HttpPost]
        [Route("{CarModelId:int}/CarModelClass/Edit")]
        public async Task<IActionResult> Edit(int CarModelId, int CarModelClassId, CarModelClass carModelClass)
        {
            bool result = false;

            carModelClass.Id = CarModelClassId;
            carModelClass.CarModelId = CarModelId;
            result = _CarModelClass.UpdateModelClasses(carModelClass);

            if (result)
            {
                return RedirectToAction("Index", "CarModelClass", new { CarModelId=  CarModelId });
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{CarModelId:int}/CarModelClass/Delete")]
        public async Task<IActionResult> Delete(int CarModelId, int CarModelClassId)
        {
            ActionCarModelClasseViewModel actionCarModelClasseViewModel = new ActionCarModelClasseViewModel();

            CarModelClass FindCarModelClass = await _CarModelClass.CarModelISCarModelClassAsync(CarModelClassId);
            actionCarModelClasseViewModel.Id = CarModelClassId;
            actionCarModelClasseViewModel.Name = FindCarModelClass.Name;
            actionCarModelClasseViewModel.Pirce = FindCarModelClass.Pirce;
            actionCarModelClasseViewModel.Disclcament = FindCarModelClass.Disclcament;
            actionCarModelClasseViewModel.CarPower = FindCarModelClass.CarPower;
            actionCarModelClasseViewModel.EngineClass = FindCarModelClass.EngineClass;
            actionCarModelClasseViewModel.Shifting = FindCarModelClass.Shifting;
            actionCarModelClasseViewModel.Driventrain = FindCarModelClass.Driventrain;
            actionCarModelClasseViewModel.Ps = FindCarModelClass.Ps;
            actionCarModelClasseViewModel.Rpm = FindCarModelClass.Rpm;
            actionCarModelClasseViewModel.Kml = FindCarModelClass.Kml;
            actionCarModelClasseViewModel.Burn = FindCarModelClass.Burn;
            actionCarModelClasseViewModel.Brand = FindCarModelClass.Brand;
            actionCarModelClasseViewModel.CarModelId = CarModelId;

            if (actionCarModelClasseViewModel != null)
            {
                return View();
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpGet]
        
        public async Task<IActionResult> Delete(int CarModelClassId)
        {
            bool result = false;

            result = _CarModelClass.DeleteModelClasses(CarModelClassId);

            if (result)
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
