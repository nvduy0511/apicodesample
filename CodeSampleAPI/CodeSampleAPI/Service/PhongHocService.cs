using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IPhongHocService
    {
        List<PhongHoc> getListPhongHocByUidUser(string uID);

        bool addUserToPhongPhong(string uID, int idPhongHoc);

    }
    public class PhongHocService : IPhongHocService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public PhongHocService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public List<PhongHoc> getListPhongHocByUidUser(string uID)
        {
            return _codeSampleContext.CtPhongHocs.Where(p => p.UIdNguoiDung == uID).Select(p => p.IdPhongHocNavigation).ToList();
        }

        public bool addUserToPhongPhong(string uID, int idPhongHoc)
        {
            // kiểm tra phòng học có tồn tại không
            PhongHoc phongHoc = _codeSampleContext.PhongHocs.FirstOrDefault(p => p.Id == idPhongHoc);
            if (phongHoc == null)
                return false;
            //tồn tại rồi thì không thêm nữa
            CtPhongHoc ctPH = _codeSampleContext.CtPhongHocs.FirstOrDefault(p => p.IdPhongHoc == idPhongHoc && p.UIdNguoiDung.Equals(uID));
            if (ctPH != null)
                return false;
            // tiến hành thêm chi tiêt phòng học
            try
            {
                DateTime Datenow = DateTime.Now;

                CtPhongHoc ctPhongHoc = new CtPhongHoc() { IdPhongHoc = idPhongHoc, UIdNguoiDung = uID, NgayThamGia = Datenow };
                _codeSampleContext.CtPhongHocs.Add(ctPhongHoc);
                _codeSampleContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
