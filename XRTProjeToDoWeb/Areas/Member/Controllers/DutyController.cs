using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    //public class DutyController : Controller
    public class DutyController : BaseIdentityController
    {
        private readonly IDutyService _dutyService;
        //private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DutyController(IMapper mapper, IDutyService dutyService, UserManager<AppUser> userManager):base(userManager)
        {
            _dutyService = dutyService;
            //_userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int aktifSayfa = 1)
        {
            TempData["Active"] = TempdataInfo.Duty;
            var user = await GetirGirisYapanKullanici();
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var duties = _dutyService.GetirTumTablolarlaTamamlanmayan(out toplamSayfa, user.Id, aktifSayfa);

            var duties = _mapper.Map<List<DutyListAllDto>>(_dutyService.GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, user.Id, aktifSayfa));

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

            //List<DutyListAllViewModel> models = new List<DutyListAllViewModel>();
            //foreach (var duty in duties)
            //{
            //    DutyListAllViewModel model = new DutyListAllViewModel();
            //    model.Id = duty.Id;
            //    model.Aciklama = duty.Aciklama;
            //    model.Urgency = duty.Urgency;
            //    model.Ad = duty.Ad;
            //    model.AppUser = duty.AppUser;
            //    model.OlusturulmaTarih = duty.OlusturulmaTarih;
            //    model.Reports = duty.Reports;
            //    models.Add(model);
            //}
            //return View(models);
            return View(duties);
        }
    }
}