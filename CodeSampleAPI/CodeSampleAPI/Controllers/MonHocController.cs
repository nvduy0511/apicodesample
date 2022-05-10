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
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocService _monHocService;
        public MonHocController(IMonHocService monHocService)
        {
            this._monHocService = monHocService;
        }

        [HttpGet("getOne")]
        public IActionResult getMonHocByID(int id)
        {
            return Ok(_monHocService.getMonHocByID(id));
        }

        [HttpGet("getAll")]
        public IActionResult getAllMonHoc()
        {
            return Ok(_monHocService.getAllMonHoc());
        }

    }
}
