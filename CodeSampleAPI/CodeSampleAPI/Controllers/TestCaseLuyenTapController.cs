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
    }
}
