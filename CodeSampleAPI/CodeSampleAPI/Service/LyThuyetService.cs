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
    }
}
