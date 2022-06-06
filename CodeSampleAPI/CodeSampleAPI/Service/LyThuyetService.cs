using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface ILyThuyetService
    {
        LyThuyet getLyThuyetByID(int id);
        LyThuyet_TenMonHoc getAllLyThuyetByIDMonHoc(int id);
        int getSoLuongMon();
        bool AddLT(LyThuyets_Custom lt);
        bool EditLT(LyThuyets_Custom lt);
        bool DeleteLT(int id);
    }
    public class LyThuyetService : ILyThuyetService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public LyThuyetService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public LyThuyet getLyThuyetByID(int id)
        {
            return _codeSampleContext.LyThuyets.FirstOrDefault(p => p.Id == id);
        }
        public LyThuyet_TenMonHoc getAllLyThuyetByIDMonHoc(int id)
        {
            var res = (from mh in _codeSampleContext.MonHocs
                       where mh.Id == id
                       select new LyThuyet_TenMonHoc()
                       {
                           tenMonHoc = mh.TenMonHoc,
                           lyThuyets = mh.LyThuyets.ToList()
                       }).Single();
            return res;
        }

        public int getSoLuongMon()
        {
            return _codeSampleContext.LyThuyets.ToList().Count();
        }

        public bool AddLT(LyThuyets_Custom lt)
        {
            if ((_codeSampleContext.MonHocs.FirstOrDefault(p => p.Id == lt.ID_MonHoc)) != null)
            {
                LyThuyet lyThuyet = new LyThuyet();
                lyThuyet.TieuDe = lt.TieuDe;
                lyThuyet.NoiDung = lt.NoiDung;
                lyThuyet.IdMonHoc = lt.ID_MonHoc;
                _codeSampleContext.LyThuyets.Add(lyThuyet);
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditLT(LyThuyets_Custom lt)
        {
            LyThuyet lyThuyet = new LyThuyet();
            lyThuyet = _codeSampleContext.LyThuyets.FirstOrDefault(p => p.Id == lt.ID);
            if (lyThuyet != null)
            {
                lyThuyet.TieuDe = lt.TieuDe;
                lyThuyet.NoiDung = lt.NoiDung;
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLT(int id)
        {
            LyThuyet lyThuyet = new LyThuyet();
            lyThuyet = _codeSampleContext.LyThuyets.FirstOrDefault(p => p.Id == id);
            if (lyThuyet != null)
            {
                _codeSampleContext.LyThuyets.Remove(lyThuyet);
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
