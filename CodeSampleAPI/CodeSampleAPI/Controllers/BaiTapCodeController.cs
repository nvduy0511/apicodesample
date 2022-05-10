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
    public class BaiTapCodeController : ControllerBase
    {
        private readonly IBaiTapCodeService _baiTapCodeService;
        public BaiTapCodeController(IBaiTapCodeService baiTapCodeService)
        {
            this._baiTapCodeService = baiTapCodeService;
        }

        [HttpGet("getOne")]
        public IActionResult getBaiTapCodeByID(int id)
        {
            return Ok(_baiTapCodeService.GetById(id));
        }

        [HttpGet("getAll")]
        public IActionResult getAllBaiTapCode()
        {
            return Ok(_baiTapCodeService.getAllBaiTapCode());
        }
    }
}
