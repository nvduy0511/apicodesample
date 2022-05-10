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
        public RunCodeController(ITestCaseService testCaseService)
        {
            this._testCaseService = testCaseService;
        }
        [Route("api/runCode")]
        [HttpPost]
        public IActionResult runCode([FromBody] RunCodeRequest runCodeRequest)
        {
            Task<RunCodeResponse> task = Task<RunCodeResponse>.Run(() => callAPI(runCodeRequest));
            task.Wait();
            return Ok(task.Result);
        }

        [Route("api/runCodes")]
        [HttpPost]
        public IActionResult runCodes(int id,[FromBody] RunCodeRequest requestFromClient)
        {
            List<TestCase> testCases = _testCaseService.getTestCasesByIDBaiTapCode(id);

            // List input cho các test case
            List<String> inputs = (from tC in testCases select tC.Intput).ToList();
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
                Task<RunCodeResponse> task = Task<RunCodeResponse>.Run(() => callAPI(runCodeRequest));
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

        public static async Task<RunCodeResponse> callAPI(RunCodeRequest runCodeRequest)
        {
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                var url = "https://codexweb.netlify.app/.netlify/functions/enforceCode";
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var data = new Dictionary<string, string>
                {
                    {"code",runCodeRequest.Code},
                    {"input",runCodeRequest.Input},
                    {"language",runCodeRequest.Language}
                };

                var jsonData = JsonConvert.SerializeObject(data);
                var contentData = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, contentData);

                if (response.IsSuccessStatusCode)
                {
                    var stringData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RunCodeResponse>(stringData);
                    return result;
                }

            }
            return null;
        }

        /*
         
          #include<iostream>\nusing namespace std;\n\nint main()\n{\n    string s;\n    getline(cin, s);\n    cout<<s;\n    return 0;\n}

         */
    }
}
