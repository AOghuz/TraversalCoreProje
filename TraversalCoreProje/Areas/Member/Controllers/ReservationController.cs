using BusinnessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationnManager rezervasyonManager = new ReservationnManager(new EfReservationnDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyCurrentReservation()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = rezervasyonManager.GetListWithRezervasyonByAccepted(value.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = rezervasyonManager.GetListWithRezervasyonByPrevious(value.Id);
            return View(valuesList);
        }
        public IActionResult NewReservation()
        {
            List<SelectListItem> value = (from x in destinationManager.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.City,
                                              Value = x.DestinationId.ToString()
                                          }).ToList();
            ViewBag.v = value;
            return View();
        }
        [HttpPost]

        public IActionResult NewReservation(Reservationn p)
        {
            p.AppUserId = 2;
            p.Status = "Onay Bekliyor";
            rezervasyonManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = rezervasyonManager.GetListWithRezervasyonByWaitAprroval(value.Id);
            return View(valuesList);
        }
    }
}
