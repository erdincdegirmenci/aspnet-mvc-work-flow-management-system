using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    //public class ProfilController : Controller
    public class ProfilController : BaseIdentityController
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ProfilController(UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            //_userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Profil;
            var appUser = await GetirGirisYapanKullanici();
            //var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = appUser.Id;
            //model.Name = appUser.Name;
            //model.SurName = appUser.Surname;
            //model.Picture = appUser.Picture;
            //model.Email = appUser.Email;
            //return View(model);
            return View(_mapper.Map<AppUserListDto>(appUser));
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                var uptadeperson = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string pictureName = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }
                    uptadeperson.Picture = pictureName;
                }
                uptadeperson.Name = model.Name;
                uptadeperson.Surname = model.SurName;
                uptadeperson.Email = model.Email;

                var result = await _userManager.UpdateAsync(uptadeperson);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme İşlemi Başarı İle Gerçekleştirildi";
                    return RedirectToAction("Index");
                }
                HataEkle(result.Errors);
                //foreach (var item in result.Errors)
                //{
                //    ModelState.AddModelError("", item.Description);
                //}
            }
            return View(model); 
        }
    }
}