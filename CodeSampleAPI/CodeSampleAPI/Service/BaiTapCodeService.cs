using CodeSampleAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IBaiTapCodeService
    {
        BaiTapCode GetById(int id);
        List<BaiTapCode> getAllBaiTapCode();
    }

    public class BaiTapCodeService : IBaiTapCodeService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public BaiTapCodeService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

  
        public BaiTapCode GetById(int id)
        {
            return _codeSampleContext.BaiTapCodes.FirstOrDefault(p => p.Id == id);
        }
        public List<BaiTapCode> getAllBaiTapCode()
        {
            return _codeSampleContext.BaiTapCodes.ToList();
        }




    }
}
