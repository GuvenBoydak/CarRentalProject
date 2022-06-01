using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Kulanıcı ismi Boş Geçilemez!!!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Kulanıcı Soyismi Boş Geçilemez!!!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kulanıcı Şifresi Boş Geçilemez!!!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Kulanıcı Email Boş Geçilemez!!!");
            RuleFor(x => x.Email).EmailAddress().WithMessage(" Email Adress Formatında  Giriniz!!!");
        }
    }
}
