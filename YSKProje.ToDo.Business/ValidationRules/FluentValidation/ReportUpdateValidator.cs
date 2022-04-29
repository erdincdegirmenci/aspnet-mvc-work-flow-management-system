using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class ReportUpdateValidator : AbstractValidator<ReportUpdateDto>
    {
        public ReportUpdateValidator()
        {
            RuleFor(I => I.Tanım).NotNull().WithMessage("Tanım Alanı Boş Bırakılamaz.");
            RuleFor(I => I.Detay).NotNull().WithMessage("Detay Alanı Boş Bırakılamaz.");
        }
    }
}
