using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.title = featureManager.GetList().FirstOrDefault().Title;
            ViewBag.price = featureManager.GetList().FirstOrDefault().Description;
            ViewBag.Image = featureManager.GetList().FirstOrDefault().Image;

            var values = featureManager.GetList().TakeLast(4).ToList();
            return View(values);
        }
    }
}
