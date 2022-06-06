using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IAdminService {
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
            var res = _codeSampleContext.Admins.FirstOrDefault(a => a.TaiKhoan == admin.TaiKhoan && a.MatKhau == admin.MatKhau);
            if(res != null)
            {
                return true;
            }
            return false;
        }
    }
}
