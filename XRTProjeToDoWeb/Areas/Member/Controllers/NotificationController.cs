using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XRTProje.ToDo.DTO.DTOs.NotificationDTOs;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
[Authorize(Roles =RoleInfo.Member)]
[Area(AreaInfo.Member)]
    //public class NotificationController : Controller
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        //private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public NotificationController(IMapper mapper,INotificationService notificationService, UserManager<AppUser> userManager):base(userManager)
        {
            _notificationService = notificationService;
            //_userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Notification;
            var user = await GetirGirisYapanKullanici();
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var notifications = _notificationService.GetirOkunmayanlar(user.Id);
            //List<NotificationListViewModel> models = new List<NotificationListViewModel>();
            //foreach (var notification in notifications)
            //{
            //    NotificationListViewModel model = new NotificationListViewModel();
            //    model.Id = notification.Id;
            //    model.Aciklama = notification.Aciklama;
            //    models.Add(model);
            //}
            //return View(models);
            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetirOkunmayanlar(user.Id)));
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var updateNotification = _notificationService.GetirIdile(id);
            updateNotification.Durum = true;
            _notificationService.Guncelle(updateNotification);
            return RedirectToAction("Index");
        }
    }
}