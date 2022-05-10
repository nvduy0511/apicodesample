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
    public class TestCaseController : ControllerBase
    {
        private readonly ITestCaseService _testCaseService;
        public TestCaseController(ITestCaseService testCaseService)
        {
            this._testCaseService = testCaseService;
        }
        [HttpGet]
        public IActionResult getListIntTestCase(int id)
        {
            return Ok(_testCaseService.getListIntTestCaseByIDBaiTapCode(id));
        }
    }
}
