using CodeSampleAPI.Data;
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
    }
}
