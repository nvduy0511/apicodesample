using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface ITestCaseLuyenTapService
    {
        List<int> getListIntTestCaseByID(int id);

        List<TestCaseLuyenTap> getTestCasesByID(int id);
    }
    public class TestCaseLuyenTapService : ITestCaseLuyenTapService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public TestCaseLuyenTapService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public List<int> getListIntTestCaseByID(int id)
        {
            int count = _codeSampleContext.TestCaseLuyenTaps.Where(p => p.Id == id).ToList().Count;
            List<int> testCaseInt = new List<int>();
            // 0: là đánh dấu testCase lên cho UI xử lý icon còn dữ liệu testCase sẽ chỉ xử lý ở phần BE
            for (int i = 0; i < count; i++)
                testCaseInt.Add(2);

            return testCaseInt;
        }

        public List<TestCaseLuyenTap> getTestCasesByID(int id)
        {
            return _codeSampleContext.TestCaseLuyenTaps.Where(p => p.IdBtluyenTap == id).ToList();
        }
    }
}
