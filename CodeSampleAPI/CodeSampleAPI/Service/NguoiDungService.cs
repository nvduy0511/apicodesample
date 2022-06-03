using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface INguoiDungService
    {
        List<NguoiDung> getAllNguoiDung();
        NguoiDung getOne(string uID);
        Boolean RemoveNguoiDung(string id);
        Boolean AddOrUpdate(string id, string ten, string tenHienThi, string linkAvatar, string mail, DateTime date, string shool);
        int getSoLuongUser();
    }
    public class NguoiDungService : INguoiDungService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public NguoiDungService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }
        public List<NguoiDung> getAllNguoiDung()
        {
            return _codeSampleContext.NguoiDungs.ToList();
        }
        public Boolean RemoveNguoiDung(string id)
        {
            NguoiDung user = new NguoiDung();
            user = _codeSampleContext.NguoiDungs.FirstOrDefault(p => p.UId == id);
            if (user != null)
            {
                _codeSampleContext.NguoiDungs.Remove(user);
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddOrUpdate(string id, string ten, string tenHienThi, string? linkAvatar, string mail, DateTime date, string shool)
        {
            NguoiDung ndFind = _codeSampleContext.NguoiDungs.FirstOrDefault(p => p.UId == id);
            try
            {
                if (ndFind == null)
                {
                    ndFind = new NguoiDung();
                    ndFind.UId = id;
                    ndFind.HoTen = ten;
                    ndFind.Email = mail;
                    ndFind.TenHienThi = tenHienThi;
                    ndFind.LinkAvatar = linkAvatar;
                    ndFind.NamSinh = date;
                    ndFind.Truong = shool;
                    _codeSampleContext.NguoiDungs.Add(ndFind);
                }
                else
                {
                    ndFind.HoTen = ten;
                    ndFind.Email = mail;
                    ndFind.TenHienThi = tenHienThi;
                    ndFind.LinkAvatar = linkAvatar;
                    ndFind.NamSinh = date;
                    ndFind.Truong = shool;
                }
                _codeSampleContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
            
        }
        public int getSoLuongUser()
        {
            return _codeSampleContext.NguoiDungs.ToList().Count();
        }

        public NguoiDung getOne(string uID)
        {
            NguoiDung res = _codeSampleContext.NguoiDungs.FirstOrDefault(nd => nd.UId == uID);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
