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

        bool AddTestCase(string input, string output, int idBTLT);
        bool DeleteTestCase(int id);
        bool EditTestCase(int id, string input, string output);
    }
    public class TestCaseLuyenTapService : ITestCaseLuyenTapService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public TestCaseLuyenTapService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public bool AddTestCase(string input, string output, int idBTLT)
        {
            TestCaseLuyenTap ts = new TestCaseLuyenTap();
            ts.Input = input;
            ts.Output = output;
            ts.IdBtluyenTap = idBTLT;
            _codeSampleContext.TestCaseLuyenTaps.Add(ts);
            _codeSampleContext.SaveChanges();
            return true;
        }

        public bool DeleteTestCase(int id)
        {
            TestCaseLuyenTap ts = new TestCaseLuyenTap();
            ts = _codeSampleContext.TestCaseLuyenTaps.FirstOrDefault(p => p.Id == id);
            if (ts != null)
            {
                _codeSampleContext.TestCaseLuyenTaps.Remove(ts);
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
            TestCaseLuyenTap ts = new TestCaseLuyenTap();
            ts = _codeSampleContext.TestCaseLuyenTaps.FirstOrDefault(p => p.Id == id);
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

        public List<int> getListIntTestCaseByID(int id)
        {
            int count = _codeSampleContext.TestCaseLuyenTaps.Where(p => p.IdBtluyenTap == id).ToList().Count;
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
