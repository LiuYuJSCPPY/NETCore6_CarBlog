using Microsoft.AspNetCore.Mvc;
using Car.Web.DataContext.Enum;
using Car.Web.ViewModel;
using Car.Web.Inatface;
using Car.Web.ViewModel;
using Car.Web.Models;

namespace Car.Web.Controllers
{
    public class FondCarBlogController : Controller
    {
        private readonly IFontCarBlogSearchIndex _fontCarBlogSearchIndex;
        private readonly ICarBand _carBand;

        public FondCarBlogController(IFontCarBlogSearchIndex fontCarBlogSearchIndex, ICarBand carBand)
        {
            _fontCarBlogSearchIndex = fontCarBlogSearchIndex;
            _carBand = carBand;
        }

        [HttpGet]
       
        public async Task<IActionResult> SearchIndex()
        {
            SeachFormCarViewModel Model = new SeachFormCarViewModel
            {
               
                carBands = await _carBand.ListCartBands(),
            };

            return View(Model);
        }
        [HttpGet]
        [Route("CarBlog/Search/")]
        public async Task<IActionResult> Search(int? minprice,int? maxprice, int[] CarClass, int[] CarDisplacement, int[] CarPower, int[] CarSize)
        {

            SeachFormCarViewModel Model = new SeachFormCarViewModel();
            var carModels = await _fontCarBlogSearchIndex.SearchAllcarModels();

           if(CarClass.Count() > 0)
            {
                carModels = _fontCarBlogSearchIndex.SearchCarClass(CarClass, carModels);
            }
           if(CarSize.Count() > 0)
            {
                carModels = _fontCarBlogSearchIndex.SearchSize(CarSize, carModels);

            }
            if(CarPower.Count() > 0)
            {
                carModels = _fontCarBlogSearchIndex.SearchCarPower(CarPower, carModels);
            }
            if(CarDisplacement.Count() > 0)
            {
                carModels = _fontCarBlogSearchIndex.SearchCarDisplacement(CarDisplacement, carModels);
            }
            if(minprice.HasValue || maxprice.HasValue)
            {
                carModels = _fontCarBlogSearchIndex.SearchPrice(minprice, maxprice, carModels);
            }
            Model.carModels = carModels;
            return View(Model);
        }

        [HttpGet]
        [Route("CarBlog/CarBand/{CarBandId:int}")]
        public async Task<IActionResult> CarBand(int CarBandId)
        {
            SeachFormCarViewModel Model = new SeachFormCarViewModel();
            Model.carModels = await _fontCarBlogSearchIndex.CarModelBandAsync(CarBandId);
            return View(Model);
        }

        [HttpGet]
        [Route("CarBlog/CarModel/{CarModelId:int}")]
        public async Task<IActionResult> CarModel (int CarModelId)
        {
            var CarModel = await _fontCarBlogSearchIndex.GetCarModelGetIdAsync(CarModelId);
            return View(CarModel);
        }
    }
}
