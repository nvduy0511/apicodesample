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
        Boolean RemoveGV(string id);
        Boolean AddOrUpdate(string id, string ten, string mail, DateTime date, string shool, string linkAvatar, string tenHienThi);

        bool AddGV(string id, string ten, string mail, DateTime date, string shool);
        bool EditGV(string id, string ten, DateTime date, string shool);
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
        public Boolean AddOrUpdate(string id, string ten, string mail, DateTime date, string shool,string linkAvatar, string tenHienThi)
        {
            GiangVien gvFind = _codeSampleContext.GiangViens.FirstOrDefault(p => p.UId == id);

            try
            {
                if (gvFind == null)
                {
                    gvFind = new GiangVien();
                    gvFind.UId = id;
                    gvFind.HoTen = ten;
                    gvFind.Email = mail;
                    gvFind.NamSinh = date;
                    gvFind.Truong = shool;
                    gvFind.LinkAvatar = linkAvatar;
                    gvFind.TenHienThi = tenHienThi;
                    _codeSampleContext.GiangViens.Add(gvFind);
                }
                else
                {
                    gvFind.HoTen = ten;
                    gvFind.Email = mail;
                    gvFind.NamSinh = date;
                    gvFind.Truong = shool;
                    gvFind.LinkAvatar = linkAvatar;
                    gvFind.TenHienThi = tenHienThi;
                }

                _codeSampleContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public GiangVien getOne(string uID)
        {
            var giangvien = _codeSampleContext.GiangViens.SingleOrDefault(gv => gv.UId == uID);
            if (giangvien == null)
            {
                return null;
            }
            return giangvien;
        }

        public bool AddGV(string id, string ten, string mail, DateTime date, string shool)
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

        public bool EditGV(string id, string ten, DateTime date, string shool)
        {
            GiangVien gv = new GiangVien();
            gv = _codeSampleContext.GiangViens.FirstOrDefault(p => p.UId == id);
            if (gv != null)
            {
                gv.HoTen = ten;
                gv.NamSinh = date;
                gv.Truong = shool;
                _codeSampleContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
