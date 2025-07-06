using BusinnessLayer.Abstract;
using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetListWithUserAndDestination();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.GetById(id);
            _commentService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
