using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using CodeSampleAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeSampleAPI.Controllers
{

    [ApiController]
    public class RunCodeController : ControllerBase
    {
        private readonly ITestCaseService _testCaseService;
        private readonly IRunCodeService _runCodeService;
        public RunCodeController(ITestCaseService testCaseService,IRunCodeService runCodeService)
        {
            this._testCaseService = testCaseService;
            this._runCodeService = runCodeService;
        }
        [Route("api/runCode")]
        [HttpPost]
        public IActionResult runCode([FromBody] RunCodeRequest runCodeRequest)
        {
            Task<RunCodeResponse> task = Task<RunCodeResponse>.Run(() => _runCodeService.callAPI(runCodeRequest));
            task.Wait();
            return Ok(task.Result);
        }

        [Route("api/runCodes")]
        [HttpPost]
        public IActionResult runCodes(int id,[FromBody] RunCodeRequest requestFromClient)
        {
            List<TestCase> testCases = _testCaseService.getTestCasesByIDBaiTapCode(id);

            // List input cho các test case
            List<String> inputs = (from tC in testCases select tC.Input).ToList();
            List<String> outputs = (from tC in testCases select tC.Output).ToList();
            // List các task chạy bất đồng bộ
            List<Task<RunCodeResponse>> TaskList = new List<Task<RunCodeResponse>>();
            // List các request để Call API Code X
            List<RunCodeRequest> runCodeRequests = new List<RunCodeRequest>();
            // Tạo request cho API code X bằng input từ DB 
            foreach (String input in inputs)
            {
                runCodeRequests.Add(new RunCodeRequest() { Code = requestFromClient.Code, Language = requestFromClient.Language, Input = input });
            }
            // Chạy đa luồng call API Code X
            foreach (RunCodeRequest runCodeRequest in runCodeRequests)
            {
                Task<RunCodeResponse> task = Task<RunCodeResponse>.Run(() => _runCodeService.callAPI(runCodeRequest));
                TaskList.Add(task);
            }
            Task.WaitAll(TaskList.ToArray());

            // List kết quả sau khi chạy xong
            List<RunCodeResponse> res = TaskList.Select(p => p.Result).ToList();
            
            //So sánh kết qủa giữa Output trong DB và Output code của người dùng
            List<int> kq = new List<int>();
            for (int i = 0; i < outputs.Count; i++)
            {
                kq.Add(outputs.ElementAt(i)
                    .Equals(res.ElementAt(i).output) 
                    ? 1 : 0);
            }
            return Ok(kq);
        }

    }
}
