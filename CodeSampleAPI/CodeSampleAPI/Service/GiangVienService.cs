using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IGiangVienService
    {
        GiangVien getOne(string uID);
        List<GiangVien> getAllGV();
        Boolean AddGV(string id, string ten, string mail, DateTime date, string shool);
        Boolean RemoveGV(string id);
        Boolean EditGV(string id, string ten, string mail, DateTime date, string shool);
    }
    public class GiangVienService : IGiangVienService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public GiangVienService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }
        public List<GiangVien> getAllGV()
        {
            return _codeSampleContext.GiangViens.ToList();
        }
        public Boolean AddGV(string id, string ten, string mail, DateTime date, string shool)
        {
            GiangVien gv = new GiangVien();
            if ((_codeSampleContext.GiangViens.FirstOrDefault(p => p.UId == id)) != null)
            {
                return false;
            }
            else
            {
                gv.UId = id;
                gv.HoTen = ten;
                gv.Email = mail;
                gv.NamSinh = date;
                gv.Truong = shool;
                _codeSampleContext.GiangViens.Add(gv);
                _codeSampleContext.SaveChanges();
                return true;
            }
        }
        public Boolean RemoveGV(string id)
        {
            GiangVien gv = new GiangVien();
            gv = _codeSampleContext.GiangViens.FirstOrDefault(p => p.UId == id);
            if (gv != null)
            {
                _codeSampleContext.GiangViens.Remove(gv);
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean EditGV(string id, string ten, string mail, DateTime date, string shool)
        {
            GiangVien gv = new GiangVien();
            gv = _codeSampleContext.GiangViens.FirstOrDefault(p => p.UId == id);
            if (gv != null)
            {
                gv.HoTen = ten;
                gv.Email = mail;
                gv.NamSinh = date;
                gv.Truong = shool;
                _codeSampleContext.SaveChanges();
                return true;
            }
            return false;
        }

        public GiangVien getOne(string uID)
        {
            var giangvien = _codeSampleContext.GiangViens.SingleOrDefault(gv => gv.UId == uID);
            if(giangvien == null)
            {
                return null;
            }
            return giangvien;
        }
    }
}
