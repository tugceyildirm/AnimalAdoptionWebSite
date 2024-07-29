using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator() 
        { 
            RuleFor(x=>x.MailUser).NotEmpty().WithMessage("Mail Adresi Boş Olamaz");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz");
            RuleFor(x=>x.Message).NotEmpty().WithMessage(" Mesaj Boş Olamaz");
            RuleFor(x=>x.NameUser).NotEmpty().WithMessage("İsim Boş Olamaz");
        }
    }
}
