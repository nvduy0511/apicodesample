using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface ILyThuyetService
    {
        LyThuyet getLyThuyetByID(int id);
        List<LyThuyet> getAllLyThuyetByIDMonHoc(int id);
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
        public List<LyThuyet> getAllLyThuyetByIDMonHoc(int id)
        {
            return _codeSampleContext.LyThuyets.Where(p => p.IdMonHoc == id).ToList();
        }
    }
}
