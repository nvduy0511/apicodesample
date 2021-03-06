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
    public class BaiTapTracNghiemController : ControllerBase
    {
        private readonly IBaiTapTracNghiemService _baiTapTracNghiemService;
        public BaiTapTracNghiemController(IBaiTapTracNghiemService baiTapTracNghiemService)
        {
            this._baiTapTracNghiemService = baiTapTracNghiemService;
        }

        [HttpPost("addBaiTapTN")]
        public IActionResult addBaiTapTracNghiem([FromBody] BaiTapTracNghiem_Custom baiTapTracNghiem_Custom)
        {
            return Ok(_baiTapTracNghiemService.addBaiTapTracNghiem(baiTapTracNghiem_Custom));
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            return Ok(_baiTapTracNghiemService.getAll());
        }   

        [HttpGet("getOne")]
        public IActionResult getOne(int  id)
        {
            return Ok(_baiTapTracNghiemService.getOne(id));
        }

        [HttpGet("search")]
        public IActionResult searchBaiTapTracNghiem(string searchValue)
        {
            return Ok(_baiTapTracNghiemService.searchBaiTapTN(searchValue));
        }

        [HttpDelete]
        public IActionResult deleteBaitapTracNghiem(int id)
        {
            return Ok(_baiTapTracNghiemService.deleteBaiTapTN(id));
        }
        [HttpPut("editBTTN")]
        public IActionResult editBTTN(BaiTapTracNghiem_Custom btTN_Custom)
        {
            return Ok(_baiTapTracNghiemService.editBTTN(btTN_Custom));
        }

        [HttpGet("getListByUid")]
        public IActionResult getListByUid(string uId)
        {
            return Ok(_baiTapTracNghiemService.getListByUid(uId));
        }
    }
}
