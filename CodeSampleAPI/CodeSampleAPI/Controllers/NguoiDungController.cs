using CodeSampleAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _nguoiDungService;
        public NguoiDungController(INguoiDungService nguoiDungService)
        {
            this._nguoiDungService = nguoiDungService;
        }
        [HttpGet("getAllNguoiDung")]
        public IActionResult getAllNguoiDung()
        {
            return Ok(_nguoiDungService.getAllNguoiDung());
        }
        [HttpPost("AddNguoiDung")]
        public IActionResult AddNguoiDung(string id, string ten, string mail, DateTime date, string shool)
        {
            return Ok(_nguoiDungService.AddNguoiDung(id, ten, mail, date, shool));
        }
        [HttpDelete("RemoveNguoiDung")]
        public IActionResult RemoveNguoiDung(string id)
        {
            return Ok(_nguoiDungService.RemoveNguoiDung(id));
        }
        [HttpPut("EditNguoiDung")]
        public IActionResult EditNguoiDung(string id, string ten, string tenHienThi ,string linkAvatar, string mail, DateTime date, string shool)
        {
            return Ok(_nguoiDungService.EditNguoiDung(id, ten, tenHienThi, linkAvatar ,mail, date, shool));
        }
        [HttpGet("getSoLuongUser")]
        public IActionResult getSoLuongUser()
        {
            return Ok(_nguoiDungService.getSoLuongUser());
        }
        [HttpGet("getOne")]
        public IActionResult getThongTinNguoiDung(string uID)
        {
            return Ok(_nguoiDungService.getOne(uID));
        }
    }
}
