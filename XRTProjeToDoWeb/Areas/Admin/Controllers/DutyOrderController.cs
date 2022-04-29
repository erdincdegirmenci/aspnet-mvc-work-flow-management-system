using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class DutyOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IDutyService _dutyService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;


        public DutyOrderController(IMapper mapper, IFileService fileService, IAppUserService appUserService, IDutyService dutyService, UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _appUserService = appUserService;
            _dutyService = dutyService;
            _userManager = userManager;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.DutyOrder;
            //var model = _appUserService.GetNonAdmin();
            //List<Duty> duties = _dutyService.GetirTumTablolarla();
            //List<DutyListAllViewModel> models = new List<DutyListAllViewModel>();
            //foreach (var item in duties)
            //{
            //    DutyListAllViewModel model = new DutyListAllViewModel
            //    {
            //        Id = item.Id,
            //        Aciklama = item.Aciklama,
            //        Urgency = item.Urgency,
            //        Ad = item.Ad,
            //        AppUser = item.AppUser,
            //        OlusturulmaTarih = item.OlusturulmaTarih,
            //        Reports = item.Reports
            //    };
            //    models.Add(model);
            //}
            //return View(models);
            return View(_mapper.Map<List<DutyListAllDto>>(_dutyService.GetirTumTablolarla()));
        }
        public IActionResult AssignStaff(int id, string s, int sayfa = 1)
        {
            TempData["Active"] = TempdataInfo.DutyOrder;


            ViewBag.ActivePage = sayfa;
            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetNonAdmin().Count() / 3);
            ViewBag.Search = s;

            var personal = _mapper.Map<List<AppUserListDto>>(_appUserService.GetNonAdmin(out int TotalPage, s, sayfa));

            //var personal = _appUserService.GetNonAdmin(out TotalPage, s, sayfa);
            ViewBag.TotalPage = TotalPage;
            //List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            //foreach (var item in personal)
            //{
            //    AppUserListViewModel model = new AppUserListViewModel();
            //    model.Id = item.Id;
            //    model.Name = item.Name;
            //    model.SurName = item.Surname;
            //    model.Email = item.Email;
            //    model.Picture = item.Picture;
            //    appUserListModel.Add(model);
            //}
            ViewBag.Personals = personal;

            return View(_mapper.Map<DutyListDto>(_dutyService.GetirAciliyetileId(id)));
            //var duty = _dutyService.GetirAciliyetileId(id);
            //DutyListViewModel dutymodel = new DutyListViewModel();
            //dutymodel.Id = duty.Id;
            //dutymodel.Aciklama = duty.Aciklama;
            //dutymodel.Urgency = duty.Urgency;
            //dutymodel.Ad = duty.Ad;
            //dutymodel.OlusturulmaTarih = duty.OlusturulmaTarih;
            //return View(dutymodel);
        }
        //public IActionResult AssignPersonal(PersonalAssignViewModel model)
        public IActionResult AssignPersonal(PersonalAssignDto model)
        {
            TempData["Active"] = TempdataInfo.DutyOrder;

            //var user = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonalId));
            //var user = _userManager.Users.FirstOrDefault(I => I.Id == model.PersonalId);
            //AppUserListViewModel userModel = new AppUserListViewModel();
            //userModel.Id = user.Id;
            //userModel.Name = user.Name;
            //userModel.Picture = user.Picture;
            //userModel.SurName = user.Surname;
            //userModel.Email = user.Email;

            //var duty = _mapper.Map<DutyListDto>(_dutyService.GetirAciliyetileId(model.DutyId));
            //var duty = _dutyService.GetirAciliyetileId(model.DutyId);
            //DutyListViewModel dutyModel = new DutyListViewModel();
            //dutyModel.Id = duty.Id;
            //dutyModel.Aciklama = duty.Aciklama;
            //dutyModel.Urgency = duty.Urgency;
            //dutyModel.Ad = duty.Ad;

            PersonalAssignListDto personalassignModel = new PersonalAssignListDto();
            personalassignModel.AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonalId));
            personalassignModel.Duty = _mapper.Map<DutyListDto>(_dutyService.GetirAciliyetileId(model.DutyId));
            //personalassignModel.Duty = dutyModel;

            return View(personalassignModel);
        }

        [HttpPost]
        //Bildirim gönderilecek.
        //public IActionResult AssignStaff(PersonalAssignViewModel model)
        public IActionResult AssignStaff(PersonalAssignDto model)
        {
            TempData["Active"] = "dutyorder";
            var uptadeduty = _dutyService.GetirIdile(model.DutyId);
            uptadeduty.AppUserId = model.PersonalId;
            _dutyService.Guncelle(uptadeduty);

            _notificationService.Kaydet(new Notification
            {
                AppUserId = model.PersonalId,
                Aciklama = $"{uptadeduty.Ad} adlı iş için görevlendirildiniz."
            });


            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            TempData["Active"] = TempdataInfo.DutyOrder;
            //var duty = _dutyService.GetirRaporlarileId(id);
            //DutyListAllViewModel model = new DutyListAllViewModel();
            //model.Id = duty.Id;
            //model.Reports = duty.Reports;
            //model.Ad = duty.Ad;
            //model.Aciklama = duty.Aciklama;
            //model.AppUser = duty.AppUser;
            //return View(model);

            return View(_mapper.Map<DutyListAllDto>(_dutyService.GetirRaporlarileId(id)));
        }
        public IActionResult GetExcel(int id)
        {
            //return File(_fileService.Excel(_dutyService.GetirRaporlarileId(id).Reports), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
            return File(_fileService.Excel(_mapper.Map<List<ReportFileDto>>(_dutyService.GetirRaporlarileId(id).Reports)),
                "application/vnd.openxmlformats,officedocument,spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");

        }
        public IActionResult GetPdf(int id)
        {
            //var path = _fileService.Pdf(_dutyService.GetirRaporlarileId(id).Reports);
            var path = _fileService.Pdf(_mapper.Map<List<ReportFileDto>>(_dutyService.GetirRaporlarileId(id).Reports));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}