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
        [HttpPost("AddGV")]
        public IActionResult AddGV(string id, string ten, string mail, DateTime date, string shool)
        {
            return Ok(_giangVienService.AddGV(id, ten, mail, date, shool));
        }
        [HttpDelete("RemoveGV")]
        public IActionResult RemoveGV(string id)
        {
            return Ok(_giangVienService.RemoveGV(id));
        }
        [HttpPut("EditGV")]
        public IActionResult EditGV(string id, string ten, string mail, DateTime date, string shool)
        {
            return Ok(_giangVienService.EditGV(id, ten, mail, date, shool));
        }
    }
}
