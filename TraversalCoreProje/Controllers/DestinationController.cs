using BusinnessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = _destinationManager.GetList();
            return View(values);
        }
        //[HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id;
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = values.Id;
            ViewBag.Id = values.Id;
            var value = _destinationManager.TGetDestinationWithGuide(id);
            return View(value);
        }
        //[HttpPost]
        //public IActionResult Details(Destination p)
        //{
        //    return View();
        //}
    }
}
