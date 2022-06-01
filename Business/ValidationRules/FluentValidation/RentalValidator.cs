﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.RentDate).NotEmpty().WithMessage("Kiralama Tarihi Boş Geçilemez!!!");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("Kiralama Tarihi Boş Geçilemez!!!");
        }
    }
}