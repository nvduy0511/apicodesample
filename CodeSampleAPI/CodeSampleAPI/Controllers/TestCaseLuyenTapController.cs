using CodeSampleAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseLuyenTapController : ControllerBase
    {
        private readonly ITestCaseLuyenTapService _testCaseLuyenTapService;
        public TestCaseLuyenTapController(ITestCaseLuyenTapService testCaseLuyenTapService)
        {
            this._testCaseLuyenTapService = testCaseLuyenTapService;
        }

        [HttpGet]
        public IActionResult getByID(int id)
        {
            return Ok(_testCaseLuyenTapService.getListIntTestCaseByID(id));
        }
        [HttpGet("getTestCasesByID")]
        public IActionResult getTestCasesByID(int id)
        {
            return Ok(_testCaseLuyenTapService.getTestCasesByID(id));
        }
        [HttpPost("AddTestCase")]
        public IActionResult AddTestCase(string input, string output, int idBTLT)
        {
            return Ok(_testCaseLuyenTapService.AddTestCase(input, output, idBTLT));
        }
        [HttpDelete("DeleteTestCase")]
        public IActionResult DeleteTestCase(int id)
        {
            return Ok(_testCaseLuyenTapService.DeleteTestCase(id));
        }
        [HttpPut("EditTestCase")]
        public IActionResult EditTestCase(int id, string input, string output)
        {
            return Ok(_testCaseLuyenTapService.EditTestCase(id, input, output));
        }
    }
}
