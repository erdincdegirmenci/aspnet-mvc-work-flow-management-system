using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class DutyAddDValidator : AbstractValidator<DutyAddDto>
    {
        public DutyAddDValidator()
        {
            RuleFor(I=>I.Ad).NotNull().WithMessage("Görev Adı Alanı Boş Bırakılamaz.");
            RuleFor(I => I.UrgencyId).ExclusiveBetween(0,int.MaxValue).WithMessage("Lütfen Bir Aciliyet Durumu Belirtiniz.");
        }
    }
}
