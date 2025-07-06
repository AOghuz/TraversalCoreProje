using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;
using System.IO;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [AllowAnonymous]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity?.Name;  // Null kontrolü yapıyoruz.
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("SignIn", "Login"); // Kullanıcı adı boşsa login sayfasına yönlendir
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login"); // Kullanıcı bulunamazsa yönlendir
            }


            UserEditViewModel model = new UserEditViewModel
            {
                name = user.Name ?? string.Empty,
                surname = user.Surname ?? string.Empty,
                email = user.Email ?? string.Empty,
                phoneNumber = user.PhoneNumber ?? string.Empty,
                imageUrl = user.ImageUrl ?? string.Empty // Resim URL'sini kontrol et
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var userName = User.Identity?.Name;  // Null kontrolü yapıyoruz.
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("SignIn", "Login"); // Kullanıcı adı boşsa login sayfasına yönlendir
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login"); // Kullanıcı bulunamazsa yönlendir
            }


            // Resim dosyası varsa, yükle
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot", "userimages", imageName);

                await using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }

                user.ImageUrl = imageName; // Resim URL'sini güncelle
            }

            // Diğer alanları güncelle
            user.Name = model.name ?? string.Empty;
            user.Surname = model.surname ?? string.Empty;
            user.Email = model.email ?? string.Empty;
            user.PhoneNumber = model.phoneNumber ?? string.Empty;

            // Şifreyi kontrol et, eğer varsa güncelle
            if (!string.IsNullOrEmpty(model.password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.password);
            }

            // Veritabanı güncellemesi
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login"); // Güncelleme başarılı, yönlendir
            }

            return View(model); // Hata durumunda formu tekrar göster
        }
    }
}
