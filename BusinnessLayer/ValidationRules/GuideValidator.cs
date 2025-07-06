using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rehber Adını giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Rehber açıklamasını giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Rehber görselini giriniz");
        }
    }
}
