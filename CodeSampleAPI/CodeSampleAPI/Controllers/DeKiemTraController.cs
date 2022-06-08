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
    public class DeKiemTraController : ControllerBase
    {
        private readonly IDeKiemTraService _deKiemTraService;
        public DeKiemTraController(IDeKiemTraService deKiemTraService)
        {
            this._deKiemTraService = deKiemTraService;
        }

        [HttpGet("getById")]
        public IActionResult getById(int id)
        {
            return Ok(_deKiemTraService.getDeKiemTraByID(id));
        }

        [HttpGet("getByIdPhong")]
        public IActionResult getByIdPhong(string id)
        {
            return Ok(_deKiemTraService.getDeKiemTraByIdPhong(id));
        }

        [HttpPost]
        public IActionResult addDeKiemTra([FromBody] DeKiemTra_Custom deKiemTra_Custom)
        {
            return Ok(_deKiemTraService.addDeKiemTra(deKiemTra_Custom));
        }

        [HttpPost("public-de-kiem-tra")]
        public IActionResult publicDeKiemTra(int id)
        {
            return Ok(_deKiemTraService.publicDeKiemTra(id));
        }
        [HttpGet("getListCauHoi")]
        public IActionResult getListCauHoi(string uID)
        {
            return Ok(_deKiemTraService.getListCauHoi(uID));
        }
    }
}
