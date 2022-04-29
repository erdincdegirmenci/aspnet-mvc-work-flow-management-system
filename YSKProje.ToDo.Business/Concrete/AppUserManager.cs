using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<DualHelper> GetirEnCokGorevdeCalisanPersoneller()
        {
            return _userDal.GetirEnCokGorevdeCalisanPersoneller();
        }

        public List<DualHelper> GetirEnCokGorevTamamlamisPersoneller()
        {
            return _userDal.GetirEnCokGorevTamamlamisPersoneller();
        }

        public List<AppUser> GetNonAdmin()
        {
            return _userDal.GetNonAdmin();
        }

        public List<AppUser> GetNonAdmin(out int TotalPage, string aranacakkelime, int aktifSayfa)
        {
            return _userDal.GetNonAdmin(out TotalPage, aranacakkelime, aktifSayfa);
        }
    }
}
