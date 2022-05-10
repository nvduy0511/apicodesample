using CodeSampleAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface ITestCaseService
    {
        List<TestCase> getTestCasesByIDBaiTapCode(int id);
        List<int> getListIntTestCaseByIDBaiTapCode(int id);
    }
    public class TestCaseService : ITestCaseService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public TestCaseService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }
        public List<TestCase> getTestCasesByIDBaiTapCode(int id)
        {
            return _codeSampleContext.TestCases.Where(p => p.IdBaiTap == id).ToList();
        }

        public List<int> getListIntTestCaseByIDBaiTapCode(int id)
        {
            int count = _codeSampleContext.TestCases.Where(p => p.IdBaiTap == id).ToList().Count;
            List<int> testCaseInt = new List<int>();
            // 0: là đánh dấu testCase lên cho UI xử lý icon còn dữ liệu testCase sẽ chỉ xử lý ở phần BE
            for (int i = 0; i < count; i++)
                testCaseInt.Add(2);

            return testCaseInt;
        }
    }
}
