using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.UrgencyDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator:AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım Alanı Boş Geçilemez.");
        }
    }
}
