using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Araç İsmi Boş Geçilemez!!!");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Araç İsmi En az 2 Karakter olmalı.");
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage("Araç Model yılı Boş Geçilemez!!!");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Araç Günlük Fiyati Boş Geçilemez!!!");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Araç Açıklaması Boş Geçilemez!!!");
        }
    }
}
