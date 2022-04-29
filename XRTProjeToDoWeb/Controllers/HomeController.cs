using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Models;

namespace YSKProje.ToDo.Web.Controllers
{
    //public class HomeController : Controller
    public class HomeController : BaseIdentityController
    {

        //private readonly IDutyService _taskService;
        //private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _customLogger;
        public HomeController(/*IDutyService taskService*/ICustomLogger customLogger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {
            //_taskService = taskService;
            //_userManager = userManager;
            _signInManager = signInManager;
            _customLogger = customLogger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> SignIn(AppUserSignInModel model)
        public async Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                //var user = await _userManager.FindByNameAsync(model.UserName);
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            }
            return View("Index", model);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        //public async Task<IActionResult> SignUp(AppUserAddViewModel model)
        public async Task<IActionResult> SignUp(AppUserSignUpDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.SurName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addroleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addroleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    HataEkle(addroleResult.Errors);
                    //foreach (var item in addroleResult.Errors)
                    //{
                    //    ModelState.AddModelError("", item.Description);
                    //}
                }
                HataEkle(result.Errors);
                //foreach (var item in result.Errors)
                //{
                //    ModelState.AddModelError("", item.Description);
                //}
            }
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa bulunamadı";
            }
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"Hatanın oluştuğu yer:{exceptionHandler.Path}\nHatanın Mesajı:{exceptionHandler.Error.Message}\nStack Trace:{exceptionHandler.Error.StackTrace}");
            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;
            return View();
        }
        public void Hata()
        {
            throw new Exception("Bu bir hata");
        }
    }
}