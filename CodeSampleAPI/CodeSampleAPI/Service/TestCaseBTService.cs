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
        bool AddTestCase(string input, string output, int idBTLT);
        bool DeleteTestCase(int id);
        bool EditTestCase(int id, string input, string output);
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

        public bool AddTestCase(string input, string output, int idBTLT)
        {
            TestCaseBtcode ts = new TestCaseBtcode();
            ts.Input = input;
            ts.Output = output;
            ts.IdBaiTap = idBTLT;
            _codeSampleContext.TestCaseBtcodes.Add(ts);
            _codeSampleContext.SaveChanges();
            return true;
        }

        public bool DeleteTestCase(int id)
        {
            TestCaseBtcode ts = new TestCaseBtcode();
            ts = _codeSampleContext.TestCaseBtcodes.FirstOrDefault(p => p.Id == id);
            if (ts != null)
            {
                _codeSampleContext.TestCaseBtcodes.Remove(ts);
                _codeSampleContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditTestCase(int id, string input, string output)
        {
            TestCaseBtcode ts = new TestCaseBtcode();
            ts = _codeSampleContext.TestCaseBtcodes.FirstOrDefault(p => p.Id == id);
            if (ts != null)
            {
                ts.Input = input;
                ts.Output = output;
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
