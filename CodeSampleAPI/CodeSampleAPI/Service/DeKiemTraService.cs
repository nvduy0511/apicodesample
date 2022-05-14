using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IDeKiemTraService
    {
        List<DeKiemTra> getDeKiemTraByIdPhong(int id);

        bool addDeKiemTra();
    }
    public class DeKiemTraService : IDeKiemTraService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public DeKiemTraService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }


        public List<DeKiemTra> getDeKiemTraByIdPhong(int id)
        {
            return _codeSampleContext.DeKiemTras.Where(p => p.IdPhong == id).ToList();
        }
        public bool addDeKiemTra()
        {
            return true;
        }
    }
}
