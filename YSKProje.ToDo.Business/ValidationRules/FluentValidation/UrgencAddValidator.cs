using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.UrgencyDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class UrgencAddValidator:AbstractValidator<UrgencyAddDto>
    {
        public UrgencAddValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım Alanı Boş Bırakılamaz.");
        }
    }
}
