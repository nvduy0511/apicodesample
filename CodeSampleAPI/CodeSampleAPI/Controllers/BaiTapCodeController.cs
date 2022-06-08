using CodeSampleAPI.Data;
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

        [HttpGet("search")]
        public IActionResult searchBaiTapCode(string searchValue)
        {
            return Ok(_baiTapCodeService.searchByIdOrMoTa(searchValue));
        }

        [HttpPost("postBaiTapCode")]
        public IActionResult addBaiTapCodeAndTestCase([FromBody] BaiTapCode_Custom baiTapCode_Custom)
        {
            return Ok(_baiTapCodeService.addBaiTapCodeAndTestCases(baiTapCode_Custom));
        }

        [HttpDelete]
        public IActionResult deleteBaiTapCode(int id)
        {
            return Ok(_baiTapCodeService.deleteBaiTapCode(id));
        }
        [HttpPost("addListBaiTapCode")]
        public IActionResult addListBaiTap(List<BaiTapCode_Custom> listBai, string uID)
        {
            return Ok(_baiTapCodeService.addListBaiTapCode(listBai, uID));
        }
        [HttpGet("getListByuID")]
        public IActionResult getByList(string uID)
        {
            return Ok(_baiTapCodeService.getListByuID(uID));
        }
    }
}
