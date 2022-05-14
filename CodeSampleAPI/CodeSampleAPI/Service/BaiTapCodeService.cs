using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
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
        bool addBaiTapCodeAndTestCases(BaiTapCode_Custom baiTapCode_Custom);

        bool deleteBaiTapCode(int id);
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

        public bool addBaiTapCodeAndTestCases(BaiTapCode_Custom btCode_Custom)
        {
            BaiTapCode baiTapCode = new BaiTapCode() { DeBai = btCode_Custom.DeBai, DoKho = btCode_Custom.DoKho, IsPublic = btCode_Custom.IsPublic
                                                        , TieuDe = btCode_Custom.TieuDe, UIdNguoiTao = btCode_Custom.UIdNguoiTao};

            List<TestCase_Custom> testCases = btCode_Custom.testCases;
            try
            {
                _codeSampleContext.BaiTapCodes.Add(baiTapCode);
                _codeSampleContext.SaveChanges();
                foreach (var testCase in testCases)
                {
                    TestCase t = new TestCase() { IdBaiTap = baiTapCode.Id, Input = testCase.Input, Output = testCase.Output };
                    _codeSampleContext.TestCases.Add(t);
                }
                _codeSampleContext.SaveChanges();
            }
            catch (System.Exception e)
            {
                return false;
            }
            return true;

        }

        public bool deleteBaiTapCode(int id)
        {
            BaiTapCode btCode = _codeSampleContext.BaiTapCodes.FirstOrDefault(p => p.Id == id);
            if (btCode == null)
                return false;

            try
            {
                _codeSampleContext.BaiTapCodes.Remove(btCode);
                _codeSampleContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
