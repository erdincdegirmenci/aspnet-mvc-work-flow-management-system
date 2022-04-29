using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator:AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz.");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola Alanı Boş Bırakılamaz.");

        }
    }
}
