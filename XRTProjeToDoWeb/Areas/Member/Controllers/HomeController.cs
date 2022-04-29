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

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    //public class HomeController : Controller
    public class HomeController : BaseIdentityController
    {

        private readonly IReportService _reportService;
        //private readonly UserManager<AppUser> _userManager;
        private readonly IDutyService _dutyService;
        private readonly INotificationService _notificationService;
        public HomeController(INotificationService notificationService,IReportService reportService, UserManager<AppUser> userManager, IDutyService dutyService):base(userManager)
        {
            _reportService = reportService;
            //_userManager = userManager;
            _dutyService = dutyService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var user = await GetirGirisYapanKullanici();
            TempData["Active"] = TempdataInfo.Home;
            ViewBag.RaporSayisi = _reportService.GetirRaporSayisiileAppUserId(user.Id);
            ViewBag.GorevSayisi = _dutyService.GetirGorevSayisiTamamlananileAppUserId(user.Id);
            ViewBag.TamamlanmasıGerekenGorevSayisi = _dutyService.GetirGorevSayisiTamamlanmasıGerekenileAppUserId(user.Id);
            ViewBag.OkunmamışBildirimSayisi = _notificationService.GetirOkunmayanSayisiileAppUserId(user.Id);
            return View();
        }
    }
}