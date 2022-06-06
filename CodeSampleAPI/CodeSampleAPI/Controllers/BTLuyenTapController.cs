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
        [HttpGet("getAllByAdmin")]
        public IActionResult getAllByAdmin()
        {
            return Ok(_btLuyenTapService.getAllByAdmin());
        }
        [HttpPost("add")]
        public IActionResult add([FromBody]BaiTapLuyenTap_Custom bt)
        {
            return Ok(_btLuyenTapService.add(bt));
        }
        [HttpDelete("DeleteBTLT")]
        public IActionResult DeleteBTLT(int id)
        {
            return Ok(_btLuyenTapService.DeleteBTLT(id));
        }
        [HttpPut("EditBTLT")]
        public IActionResult EditBTLT(int id, int doKho, string tieuDe, string deBai, string rangBuoc, string dinhDangDauVao, string dinhDangDauRa, string mauDauVao, string mauDauRa, string tag)
        {
            return Ok(_btLuyenTapService.EditBTLT(id, doKho, tieuDe, deBai, rangBuoc, dinhDangDauVao, dinhDangDauRa, mauDauVao, mauDauRa, tag));
        }
        [HttpGet("countAll")]
        public IActionResult countAll()
        {
            return Ok(_btLuyenTapService.getSoLuongBaiLuyenTap());
        }
    }
}
