using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
namespace HrProject.Presentation.Controllers
{
    public class CurrentValueController : Controller
    {

        private readonly ICurrentValueService _currentValueService;
        private readonly ICurrentValueChangeService _currentValueChangeService;

        public CurrentValueController(ICurrentValueService currentValueService, ICurrentValueChangeService currentValueChangeService)
        {
            _currentValueService = currentValueService;
            _currentValueChangeService = currentValueChangeService;
        }
        public IActionResult Index()
        {
            var currentValues = _currentValueService.GetCurrentValuesByInclude();
            return View(currentValues);
        }
        [HttpGet]
        public IActionResult AddCurrentValue(string name, int unitId, decimal price)
        {
            CurrentValue currentValue = new CurrentValue();
            currentValue.CurrentValueName = name;
            currentValue.UnitId = unitId;
            currentValue.CreatedTime = DateTime.Now;
            currentValue.Price = price;
            _currentValueService.Insert(currentValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCurrentValue(int currentValueId, decimal price)
        {
            _currentValueService.UpdateCurrentValueWithChange(currentValueId, price);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetCurrentValueChange(int currentValueId)
        {
            var currentValue = _currentValueChangeService.GetByListCurrentValueId(currentValueId);
            return Json(currentValue);
        }
        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _currentValueService.Delete(id);
                return Json("ok");
            }
            catch (Exception)
            {

                return Json("Hata");

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
