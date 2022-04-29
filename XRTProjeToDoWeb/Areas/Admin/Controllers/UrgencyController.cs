using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XRTProje.ToDo.DTO.DTOs.UrgencyDTOs;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class UrgencyController : Controller
    {

        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Urgency;
            //List<Urgency> urgencies = _urgencyService.GetirHepsi();
            //List<UrgencyListViewModel> model = new List<UrgencyListViewModel>();
            //foreach (var item in urgencies)
            //{
            //    UrgencyListViewModel urgencyModel = new UrgencyListViewModel();
            //    urgencyModel.Id = item.Id;
            //    urgencyModel.Description = item.Description;
            //    model.Add(urgencyModel);
            //}       
            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetirHepsi()));
        }
        public IActionResult AddUrgency()
        {
            TempData["Active"] = TempdataInfo.Urgency;
            //return View(new UrgencyAddViewModel());
            return View(new UrgencyAddDto());
        }

        [HttpPost]
        //public IActionResult AddUrgency(UrgencyAddViewModel model)
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Kaydet(new Urgency()
                {
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = TempdataInfo.Urgency;
            //var urgency = _urgencyService.GetirIdile(id);
            //UrgencyUpdateViewModel model = new UrgencyUpdateViewModel
            //{
            //    Id = urgency.Id,
            //    Description = urgency.Description
            //};
            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetirIdile(id)));
        }
        [HttpPost]
        //public IActionResult UpdateUrgency(UrgencyUpdateViewModel model)
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Guncelle(new Urgency
                {
                    Id = model.Id,
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}