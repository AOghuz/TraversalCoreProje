using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSigInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı adınızı giriniz")]
        public string? username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string? password { get; set; }
    }
}
