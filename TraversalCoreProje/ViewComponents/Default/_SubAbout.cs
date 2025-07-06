using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager _manager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var value = _manager.GetList();
            return View(value);
        }
    }
}
