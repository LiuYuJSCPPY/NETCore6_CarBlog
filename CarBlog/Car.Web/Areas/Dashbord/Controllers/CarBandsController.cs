using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car.Web.DataContext;
using Car.Web.Models;
using Car.Web.Areas.Dashbord.ViewModels;
using Car.Web.Inatface;


namespace Car.Web.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class CarBandsController : Controller
    {
        private readonly CarDataContext _context;
        private readonly ICarBand _carband;
        public CarBandsController(CarDataContext context, ICarBand carband)
        {
            _context = context;
            _carband = carband;
        }

        // GET: Dashbord/CarBands
        public async Task<IActionResult> Index()
        {
            IndexCarBandViewModel showCarBand = new IndexCarBandViewModel();
            showCarBand.carBands = await _carband.ListCartBands();
              return View(showCarBand);
        }

        // GET: Dashbord/CarBands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarBand == null)
            {
                return NotFound();
            }

            var carBand = await _context.CarBand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carBand == null)
            {
                return NotFound();
            }

            return View(carBand);
        }

        // GET: Dashbord/CarBands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashbord/CarBands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryCh,CountryEn,BandImagePath")] CreateCarBand createCarBand)
        {
            bool Result = false;
            string CreateImage = "";
            if (ModelState.IsValid)
            {
                
                CreateImage = _carband.SaveImage(createCarBand.BandImagePath);

                CarBand carBand = new CarBand
                {
                    Name = createCarBand.Name,
                    CountryCh = createCarBand.CountryCh,
                    CountryEn = createCarBand.CountryEn,
                    BandImagePath = CreateImage,

                };

                 Result = _carband.Create(carBand);

               

            }

            if (Result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }

        }

        // GET: Dashbord/CarBands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarBand == null)
            {
                return NotFound();
            }

            CarBand carBand = await _carband.IsCarBandAsync(id.Value);
            EditCarBandViewModel editCarBandViewModel = new EditCarBandViewModel
            {
                Id = carBand.Id,
                Name = carBand.Name,
                CountryCh = carBand.CountryCh,
                CountryEn = carBand.CountryEn,
                ImageName = carBand.BandImagePath,

            };

            if (carBand == null)
            {
                return NotFound();
            }
            return View(editCarBandViewModel);
        }

        // POST: Dashbord/CarBands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryCh,CountryEn,ImageName,BandImagePath")] EditCarBandViewModel EditcarBand)
        {

            string EditImageName = "";
            bool Result = false;
            if (id != EditcarBand.Id)
            {
                return NotFound();
            }

            CarBand car = await _carband.IsCarBandAsyncAsTracking(id);

            if (car.BandImagePath != null && EditcarBand.BandImagePath != null)
            {
                _ = _carband.DeleteImage(car.BandImagePath);
            }

            if (EditcarBand.BandImagePath != null)
            {
                 EditImageName = _carband.SaveImage(EditcarBand.BandImagePath);
            }
          

            if (ModelState.IsValid)
            {



              
                CarBand updateCarBand = new CarBand
                {
                    Id = id,
                    Name = EditcarBand.Name,
                    CountryCh = EditcarBand.CountryCh,
                    CountryEn = EditcarBand.CountryEn,
                    BandImagePath = EditImageName,
                };

               Result = _carband.Update(updateCarBand);

                if (Result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }

              
            }
            return View(EditcarBand);
        }

        // GET: Dashbord/CarBands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarBand == null)
            {
                return NotFound();
            }

            var carBand = await _carband.IsCarBandAsync(id.Value);
            if (carBand == null)
            {
                return NotFound();
            }

            return View(carBand);
        }

        // POST: Dashbord/CarBands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            bool Result = false;

            if (_context.CarBand == null)
            {
                return Problem("Entity set 'CarDataContext.CarBand'  is null.");
            }

            _carband.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CarBandExists(int id)
        {
          return _context.CarBand.Any(e => e.Id == id);
        }
    }
}
