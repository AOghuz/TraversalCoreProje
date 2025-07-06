using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationnService _reservationnService;
        private readonly ICommentService _commentService;

        public UserController(IAppUserService appUserService, IReservationnService reservationnService,ICommentService commentService)
        {
            _appUserService = appUserService;
            _reservationnService = reservationnService;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var value = _appUserService.GetList();
            return View(value);
        }
        public IActionResult DeleteUser(int id)
        {
            var value = _appUserService.GetById(id);
            _appUserService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var value = _appUserService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult CommentUser(int id)
        {
            var comments = _commentService.TGetListCommentByUserWithDestination(id);
            return View(comments);
        }
        //[HttpPost]
        public IActionResult ReservationUser(int id)
        {
            var value = _reservationnService.GetListWithRezervasyonByAccepted(id);
            return View(value);
        }
    }
}
