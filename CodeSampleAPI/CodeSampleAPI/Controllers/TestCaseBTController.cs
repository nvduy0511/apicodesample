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
    public class TestCaseBTController : ControllerBase
    {
        private readonly ITestCaseBTService _testCaseBTService;
        public TestCaseBTController(ITestCaseBTService testCaseBTService)
        {
            this._testCaseBTService = testCaseBTService;
        }
        [HttpGet]
        public IActionResult getListIntTestCase(int id)
        {
            return Ok(_testCaseBTService.getListIntTestCaseByIDBaiTapCode(id));
        }

        [HttpGet("getOneTestCase")]
        public IActionResult getOneTestCaseByID(int id)
        {
            return Ok(_testCaseBTService.getTestCasesByIDBaiTapCode(id));
        }    
    }
}
