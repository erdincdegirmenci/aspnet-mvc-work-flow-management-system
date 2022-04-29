using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using AutoMapper;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    public class DutyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IDutyService _dutyService;
        private readonly IMapper _mapper;
        public DutyController(IDutyService dutyService, IUrgencyService urgencyService, IMapper mapper)
        {
            _dutyService = dutyService;
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Duty;

            //List<Duty> duties = _dutyService.GetirAciliyetİleTamamlanmayan();
            //List<DutyListViewModel> models = new List<DutyListViewModel>();
            //foreach (var item in duties)
            //{
            //    DutyListViewModel model = new DutyListViewModel
            //    {
            //        Aciklama = item.Aciklama,
            //        Urgency = item.Urgency,
            //        UrgencyId = item.UrgencyId,
            //        Ad = item.Ad,
            //        Durum = item.Durum,
            //        Id = item.Id,
            //        OlusturulmaTarih = item.OlusturulmaTarih
            //    };
            //    models.Add(model);
            //}
            //return View(models);
            return View(_mapper.Map<List<DutyListDto>>(_dutyService.GetirAciliyetİleTamamlanmayan()));
        }
        public IActionResult AddTask()
        {
            TempData["Active"] = TempdataInfo.Duty;
            ViewBag.UrgencyList = new SelectList(_urgencyService.GetirHepsi(), "Id", "Description");
            //return View(new DutyAddViewModel());
            return View(new DutyAddDto());
        }

        [HttpPost]
        //public IActionResult AddTask(DutyAddViewModel model)
        public IActionResult AddTask(DutyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _dutyService.Kaydet(new Duty
                {
                    Aciklama=model.Aciklama,
                    Ad=model.Ad,
                    UrgencyId=model.UrgencyId,
                });
                return RedirectToAction("Index");
            }
            ViewBag.UrgencyList = new SelectList(_urgencyService.GetirHepsi(), "Id", "Description");
            return View(model);
        }
        public IActionResult UpdateDuty(int id)
        {
            TempData["Active"] = TempdataInfo.Duty;
            var duty = _dutyService.GetirIdile(id);
            //DutyUpdateViewModel model = new DutyUpdateViewModel
            //{
            //    Id = duty.Id,
            //    Aciklama = duty.Aciklama,
            //    UrgencyId = duty.UrgencyId,
            //    Ad = duty.Ad
            //};            ;
            ViewBag.UrgencyList = new SelectList(_urgencyService.GetirHepsi(), "Id", "Description",duty.UrgencyId);
            return View(_mapper.Map<DutyUpdateDto>(duty));
        }
        [HttpPost]
        //public IActionResult UpdateDuty(DutyUpdateViewModel model)
        public IActionResult UpdateDuty(DutyUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                _dutyService.Guncelle(new Duty()
                {
                    Id = model.Id,
                    Aciklama = model.Aciklama,
                    UrgencyId = model.UrgencyId,
                    Ad = model.Ad
                });

                return RedirectToAction("Index");
            }
            ViewBag.UrgencyList = new SelectList(_urgencyService.GetirHepsi(), "Id", "Description", model.UrgencyId);
            return View(model);
        }
        public IActionResult DeleteDuty(int id)
        {
            _dutyService.Sil(new Duty { Id=id});
            return Json(null);
        }
    }
}