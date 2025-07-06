using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var value = JsonConvert.SerializeObject(destination);
            return Json(value);
        }
        #region
        //public static List<CityClass> cities = new List<CityClass>()
        //{ new CityClass()
        //    {
        //    Id = 1,
        //    CityName = "Üsküp",
        //    CityCountry = "Makedonya"
        //    },
        //    new CityClass()
        //    {
        //    Id = 2,
        //    CityName = "Roma",
        //    CityCountry = "İtalya"
        //    },
        //    new CityClass()
        //    {
        //    Id = 3,
        //    CityName = "Londra",
        //    CityCountry = "İngiltere"
        //    }
        //};
        #endregion

        public IActionResult GetById(int DestinationId)
        {
            var value = _destinationService.GetById(DestinationId);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }

        public IActionResult DeleteCity(int id)
        {
            var value = _destinationService.GetById(id);
            _destinationService.TDelete(value);
            return NoContent();
        }
        public IActionResult UpdateCity(Destination destination)
        {

            _destinationService.TUpdate(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
    }
}

