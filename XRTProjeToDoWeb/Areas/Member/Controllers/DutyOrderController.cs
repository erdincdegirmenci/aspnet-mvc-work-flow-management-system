using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Models;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    //public class DutyOrderController : Controller
    public class DutyOrderController : BaseIdentityController
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly IDutyService _dutyService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public DutyOrderController(IMapper mapper,IDutyService dutyService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService):base(userManager)
        {
            _dutyService = dutyService;
            //_userManager = userManager;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.DutyOrder;
            var user = await GetirGirisYapanKullanici();
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var duties = _dutyService.GetirTumTablolarla(I => I.AppUserId == user.Id && !I.Durum);
            var duties = _mapper.Map<List<DutyListAllDto>>(_dutyService.GetirTumTablolarla(I => I.AppUserId == user.Id && !I.Durum));
            //List<DutyListAllViewModel> models = new List<DutyListAllViewModel>();
            //foreach (var item in duties)
            //{
            //    DutyListAllViewModel model = new DutyListAllViewModel();
            //    model.Id = item.Id;
            //    model.Aciklama = item.Aciklama;
            //    model.Urgency = item.Urgency;
            //    model.Ad = item.Ad;
            //    model.AppUser = item.AppUser;
            //    model.Reports = item.Reports;
            //    model.OlusturulmaTarih = item.OlusturulmaTarih;
            //    models.Add(model);
            //}
            //return View(models);
            return View(duties);
        }
        public IActionResult AddReport(int id)
        {
            TempData["Active"] = TempdataInfo.DutyOrder;
            var duty = _dutyService.GetirAciliyetileId(id);
            //ReportAddViewModel model = new ReportAddViewModel();
            ReportAddDto model = new ReportAddDto();
            model.GorevId = id;
            model.Gorev = duty;
            return View(model);
        }
        [HttpPost]
        //public async Task<IActionResult> AddReport(ReportAddViewModel model)
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Kaydet(new Report()
                {
                    DutyId = model.GorevId,
                    Detail = model.Detay,
                    Description = model.Tanım
                });

               var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                //var aktifKullanici = await _userManager.FindByNameAsync(User.Identity.Name);
                var aktifKullanici = await GetirGirisYapanKullanici();

                foreach (var admin in adminUserList)
                {
                    _notificationService.Kaydet(new Notification
                    {
                        Aciklama = $"{aktifKullanici.Name} {aktifKullanici.Surname} yeni bir rapor yazdı",
                        AppUserId = admin.Id
                    }) ;
                }


                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = TempdataInfo.DutyOrder;
            var report = _reportService.GetirGorevileId(id);
            //ReportUpdateViewModel model = new ReportUpdateViewModel();
            ReportUpdateDto model = new ReportUpdateDto();
            model.Id = report.Id;
            model.Tanım = report.Description;
            model.Detay = report.Detail;
            model.Gorev = report.Duty;
            model.GorevId = report.DutyId;
            return View(model);
        }
        [HttpPost]
        //public IActionResult UpdateReport(ReportUpdateViewModel model)
        public IActionResult UpdateReport(ReportUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatereport = _reportService.GetirIdile(model.Id);
                updatereport.Description = model.Tanım;
                updatereport.Detail = model.Detay;

                _reportService.Guncelle(updatereport);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> CompleteDuty(int dutyId)
        {
            TempData["Active"] = TempdataInfo.DutyOrder;
            var updateDuty = _dutyService.GetirIdile(dutyId);
            updateDuty.Durum = true;
            _dutyService.Guncelle(updateDuty);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            //var aktifKullanici = await _userManager.FindByNameAsync(User.Identity.Name);
            var aktifKullanici = await GetirGirisYapanKullanici();

            foreach (var admin in adminUserList)
            {
                _notificationService.Kaydet(new Notification
                {
                    Aciklama = $"{aktifKullanici.Name} {aktifKullanici.Surname} vermiş olduğunuz görevi tamamladı.",
                    AppUserId = admin.Id
                });
            }


            return Json(null);
        }
    }
}