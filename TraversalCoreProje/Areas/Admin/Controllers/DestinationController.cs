using BusinnessLayer.Abstract;
using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/Destination")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        //[Route("")]
        //[Route("Index")]
        public IActionResult Index()
        {
            var value = _destinationService.GetList();
            return View(value);
        }
        //[Route("")]
        //[Route("AddDestination")]
        [HttpGet]
        
        public IActionResult AddDestination()
        {
            return View();
        }
        //[Route("")]
        //[Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }
        //[Route("")]
        //[Route("DeleteDestination")]
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationService.GetById(id);
            _destinationService.TDelete(value);
            return RedirectToAction("Index", "Destination");
        }
        //[Route("")]
        //[Route("UpdateDestination")]
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationService.GetById(id);

            if (value == null)
            {
                return NotFound(); // Eğer id ile eşleşen kayıt yoksa, uygun bir hata döndür.
            }

            return View(value); // Mevcut veriyi düzenleme ekranına gönder.
        }
        //[Route("")]
        //[Route("UpdateDestination")]
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            // Checkbox işaretli değilse, Status değeri false olarak ayarlanacak
            if (destination.Status == null)
            {
                destination.Status = false; // Checkbox işaretli değilse false değeri atanacak
            }

            if (ModelState.IsValid)
            {
                // Güncelleme işlemi
                _destinationService.TUpdate(destination);
                return RedirectToAction("Index", "Destination");
            }

            // Eğer model geçerli değilse, tekrar formu görüntüle
            return View(destination);
        }
      /*  [Route("")]
        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _destinationService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        [Route("")]
        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
           _destinationService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        */

    }
}

