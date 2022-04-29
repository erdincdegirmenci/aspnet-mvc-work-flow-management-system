using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("GetDutyAppUserId")]
    public class DutyAppUserIdTagHelper : TagHelper
    {
        private readonly IDutyService _dutyService;
        public DutyAppUserIdTagHelper(IDutyService dutyService)
        {
            _dutyService = dutyService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Duty> duties = _dutyService.GetirileAppUserId(AppUserId);
            int tamamlanan=duties.Where(I => I.Durum).Count();
            int calistigiGorevSayisi= duties.Where(I => !I.Durum).Count();
            string htmlString = $"<strong>Tamamladığı Görev Sayısı: </strong>{tamamlanan}<br> <strong> Üstünde Çalıştığı Görev Sayısı: </strong>{calistigiGorevSayisi}";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
