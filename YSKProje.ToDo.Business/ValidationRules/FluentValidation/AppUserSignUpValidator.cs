using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
   public class AppUserSignUpValidator:AbstractValidator<AppUserSignUpDto>
    {
        public AppUserSignUpValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz.");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola Alanı Boş Bırakılamaz.");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Parola Onay Alanı Boş Bırakılamaz.");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parolalar Eşleşmiyor.");
            RuleFor(I => I.Email).NotNull().WithMessage("Email Alanı Boş Bırakılamaz.").EmailAddress().WithMessage("Geçersiz Email.");
            RuleFor(I => I.Name).NotNull().WithMessage("Ad Alanı Boş Bırakılamaz.");
            RuleFor(I => I.SurName).NotNull().WithMessage("Soyad Alanı Boş Bırakılamaz.");
        }
    }
}
