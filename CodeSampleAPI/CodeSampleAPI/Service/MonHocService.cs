using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IMonHocService
    {
        MonHoc getMonHocByID(int id);
        List<MonHoc> getAllMonHoc();
        bool AddMonHoc(MonHoc_Custom mh);
        bool EditMonHoc(MonHoc_Custom mh);
        bool DeleteMonHoc(int id);
    }
    public class MonHocService : IMonHocService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public MonHocService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public MonHoc getMonHocByID(int id)
        {
            return _codeSampleContext.MonHocs.FirstOrDefault(p => p.Id == id);
        }
        public List<MonHoc> getAllMonHoc()
        {
            return _codeSampleContext.MonHocs.ToList();
        }

        public bool AddMonHoc(MonHoc_Custom mh)
        {
            MonHoc monHoc = new MonHoc();
            monHoc.TenMonHoc = mh.ten;
            monHoc.MoTa = mh.mota;
            monHoc.HinhAnh = mh.hinh;
            if (monHoc.HinhAnh.Equals("string") || monHoc.HinhAnh.Equals(""))
            {
                monHoc.HinhAnh = null;
            }
            _codeSampleContext.MonHocs.Add(monHoc);
            _codeSampleContext.SaveChanges();
            return true;
        }

        public bool EditMonHoc(MonHoc_Custom mh)
        {
            MonHoc monhoc = new MonHoc();
            monhoc = _codeSampleContext.MonHocs.FirstOrDefault(p => p.Id == mh.id);
            if (monhoc != null)
            {
                monhoc.TenMonHoc = mh.ten;
                monhoc.MoTa = mh.mota;
                monhoc.HinhAnh = mh.hinh;
                if (monhoc.HinhAnh.Equals("string") || monhoc.HinhAnh.Equals("") || monhoc.HinhAnh == null)
                {
                    monhoc.HinhAnh = null;
                }
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMonHoc(int id)
        {
            MonHoc mh = new MonHoc();
            mh = _codeSampleContext.MonHocs.FirstOrDefault(p => p.Id == id);
            if (mh != null && (_codeSampleContext.LyThuyets.FirstOrDefault(p => p.IdMonHoc == id)) == null)
            {
                _codeSampleContext.MonHocs.Remove(mh);
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
