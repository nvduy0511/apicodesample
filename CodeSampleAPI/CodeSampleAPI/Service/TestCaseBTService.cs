using CodeSampleAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface ITestCaseBTService
    {
        List<TestCaseBtcode> getTestCasesByIDBaiTapCode(int id);
        List<int> getListIntTestCaseByIDBaiTapCode(int id);
    }
    public class TestCaseBTService : ITestCaseBTService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public TestCaseBTService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }
        public List<TestCaseBtcode> getTestCasesByIDBaiTapCode(int id)
        {
            return _codeSampleContext.TestCaseBtcodes.Where(p => p.IdBaiTap == id).ToList();
        }

        public List<int> getListIntTestCaseByIDBaiTapCode(int id)
        {
            int count = _codeSampleContext.TestCaseBtcodes.Where(p => p.IdBaiTap == id).ToList().Count;
            List<int> testCaseInt = new List<int>();
            // 0: là đánh dấu testCase lên cho UI xử lý icon còn dữ liệu testCase sẽ chỉ xử lý ở phần BE
            for (int i = 0; i < count; i++)
                testCaseInt.Add(2);

            return testCaseInt;
        }
    }
}
