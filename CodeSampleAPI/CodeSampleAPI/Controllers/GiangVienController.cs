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
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienService _giangVienService;
        public GiangVienController(IGiangVienService giangVienService)
        {
            this._giangVienService = giangVienService;
        }
        [HttpGet("getAllGV")]
        public IActionResult getAllGV()
        {
            return Ok(_giangVienService.getAllGV());
        }
        [HttpGet("getOneGV")]
        public IActionResult getOneGV(string uID)
        {
            return Ok(_giangVienService.getOne(uID));
        }
        
        [HttpDelete("RemoveGV")]
        public IActionResult RemoveGV(string id)
        {
            return Ok(_giangVienService.RemoveGV(id));
        }
        [HttpPut("AddOrUpDate")]
        public IActionResult EditGV(string id, string ten, string mail, DateTime date, string shool,string linkAvatar, string tenHienThi)
        {
            return Ok(_giangVienService.AddOrUpdate(id, ten, mail, date, shool,linkAvatar,tenHienThi));
        }
    }
}
