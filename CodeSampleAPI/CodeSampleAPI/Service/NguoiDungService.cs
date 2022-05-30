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
        Boolean AddNguoiDung(string id, string ten, string mail, DateTime date, string shool);
        Boolean RemoveNguoiDung(string id);
        Boolean EditNguoiDung(string id, string ten, string tenHienThi, string linkAvatar ,string mail, DateTime date, string shool);
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
        public Boolean AddNguoiDung(string id, string ten, string mail, DateTime date, string shool)
        {
            NguoiDung user = new NguoiDung();
            if ((_codeSampleContext.NguoiDungs.FirstOrDefault(p => p.UId == id)) != null)
            {
                return false;
            }
            else
            {
                user.UId = id;
                user.HoTen = ten;
                user.Email = mail;  
                user.NamSinh = date;
                user.Truong = shool;
                _codeSampleContext.NguoiDungs.Add(user);
                _codeSampleContext.SaveChanges();
                return true;
            }
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
        public bool EditNguoiDung(string id, string ten, string tenHienThi, string? linkAvatar ,string mail, DateTime date, string shool)
        {
            NguoiDung user = new NguoiDung();
            user = _codeSampleContext.NguoiDungs.FirstOrDefault(p => p.UId == id);
            if(user != null)
            {
                user.HoTen = ten;
                user.Email = mail;
                user.TenHienThi = tenHienThi;
                user.LinkAvatar = linkAvatar;
                user.NamSinh = date;
                user.Truong = shool;
                _codeSampleContext.SaveChanges();
                return true;
            }
            return false;
        }
        public int getSoLuongUser()
        {
            return _codeSampleContext.NguoiDungs.ToList().Count();
        }

        public NguoiDung getOne(string uID)
        {
            NguoiDung res = _codeSampleContext.NguoiDungs.FirstOrDefault(nd => nd.UId == uID);
            if(res == null)
            {
                return null;
            }
            return res;
        }
    }
}
