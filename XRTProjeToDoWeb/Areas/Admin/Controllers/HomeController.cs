using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]

    //public class HomeController : Controller
    public class HomeController : BaseIdentityController
    {
        private readonly IDutyService _dutyService;
        private readonly INotificationService _notificationService;
        //private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        public HomeController(IReportService reportService,UserManager<AppUser> userManager,IDutyService dutyService, INotificationService notificationService):base(userManager)
        {
            _dutyService = dutyService;
            _notificationService = notificationService;
            //_userManager = userManager;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var user = await GetirGirisYapanKullanici();
            TempData["Active"] = TempdataInfo.Home;
            ViewBag.AtanmayıBekleyenGorevSayisi = _dutyService.GetirAtanmayıBekleyenGorevSayisi();
            ViewBag.TamamlanmısGorevSayisi = _dutyService.GetirGorevTamamlanmis();
            ViewBag.OkunmamisBildirimSayisi = _notificationService.GetirOkunmayanSayisiileAppUserId(user.Id);
            ViewBag.ToplamRaporSayisi = _reportService.GetirRaporSayisi();
            return View();
        }

    }
}