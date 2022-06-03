using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IPhongHocService
    {
        List<PhongHocCustom> getListPhongHocByUidUser(string uID);

        bool addUserToPhongPhong(string uID, string idPhongHoc);

        PhongHoc getOneByID(string id);

        List<PhongHocCustom> getListPhongHocByUidGiangVien(string uID);

    }
    public class PhongHocService : IPhongHocService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public PhongHocService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public List<PhongHocCustom> getListPhongHocByUidUser(string uID)
        {
            var res = (from ctph in _codeSampleContext.CtPhongHocs
                       where ctph.UIdNguoiDung.Equals(uID)
                       select new PhongHocCustom()
                       {
                          id = ctph.IdPhongHoc,
                          tenPhong = ctph.IdPhongHocNavigation.TenPhong,
                          soLuongThanhVien = ctph.IdPhongHocNavigation.SoThanhVien,
                          linkAvatar = ctph.IdPhongHocNavigation.IdChuPhongNavigation.LinkAvatar,
                          tenHienThi = ctph.IdPhongHocNavigation.IdChuPhongNavigation.TenHienThi
                       }).ToList();

            return res;
        }

        public bool addUserToPhongPhong(string uID, string idPhongHoc)
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

        public PhongHoc getOneByID(string id)
        {
            return _codeSampleContext.PhongHocs.FirstOrDefault(p => p.Id.Equals(id));
        }

        public List<PhongHocCustom> getListPhongHocByUidGiangVien(string uID)
        {
            var res = (from ph in _codeSampleContext.PhongHocs
                       where ph.IdChuPhong.Equals(uID)
                       select new PhongHocCustom()
                       {
                           id = ph.Id,
                           linkAvatar = ph.IdChuPhongNavigation.LinkAvatar,
                           tenHienThi = ph.IdChuPhongNavigation.TenHienThi,
                           soLuongThanhVien = ph.SoThanhVien,
                           tenPhong = ph.TenPhong
                           
                       }).ToList();
            return res;
        }
    }
}
