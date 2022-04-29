using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidator:AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(I => I.Tanım).NotNull().WithMessage("Tanım Alanı Boş Bırakılamaz.");
            RuleFor(I => I.Detay).NotNull().WithMessage("Detay Alanı Boş Bırakılamaz.");
        }
    }
}
