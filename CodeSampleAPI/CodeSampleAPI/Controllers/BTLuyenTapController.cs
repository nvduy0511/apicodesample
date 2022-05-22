using CodeSampleAPI.Model;
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
    public class BTLuyenTapController : ControllerBase
    {
        private readonly IBTLuyenTapService _btLuyenTapService;
        public BTLuyenTapController(IBTLuyenTapService btLuyenTapService)
        {
            this._btLuyenTapService = btLuyenTapService;
        }

        [HttpGet("getOne")]
        public IActionResult getOne(int id)
        {
            return Ok(_btLuyenTapService.getOne(id));
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            return Ok(_btLuyenTapService.getAll());
        }

        [HttpPost("add")]
        public IActionResult add([FromBody]BaiTapLuyenTap_Custom bt)
        {
            return Ok(_btLuyenTapService.add(bt));
        }
    }
}
