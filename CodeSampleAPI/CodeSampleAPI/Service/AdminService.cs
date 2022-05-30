using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IAdminService
    {
        bool login(Admin admin);
    }
    public class AdminService : IAdminService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public AdminService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public bool login(Admin admin)
        {
            try
            {
                var res = _codeSampleContext.Admins.FirstOrDefault(ad => ad.TaiKhoan.Equals(admin.TaiKhoan) && ad.MatKhau.Equals(ad.MatKhau));
                if(res == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
