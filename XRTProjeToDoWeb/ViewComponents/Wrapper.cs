using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public Wrapper(IMapper mapper, UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(identityUser);
            //var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = user.Id;
            //model.Name = user.Name;
            //model.Email = user.Email;
            //model.SurName = user.Surname;
            //model.Picture = user.Picture;

            var notifications = _notificationService.GetirOkunmayanlar(model.Id).Count;
            ViewBag.BildirimSayisi = notifications;

            var roles = _userManager.GetRolesAsync(identityUser).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
        }
    }
}
