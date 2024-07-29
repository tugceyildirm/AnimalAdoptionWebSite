using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.AnimalName).NotEmpty()
                .WithMessage("Hayvanın ismini boş geçemezsiniz!!");
          


           /* RuleFor(x => x.AnimalName).MinimumLength(6)
                .WithMessage("Lütfen en az 6 karakterli bir şifre giriniz.");
            RuleFor(x => x.AnimalName).MaximumLength(10)
                .WithMessage("Lütfen en fazla 10 karakterli bir şifre giriniz.");*/

        }

    }
}
