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

        [HttpPost]
        public IActionResult addDeKiemTra([FromBody] DeKiemTra_Custom deKiemTra_Custom)
        {
            return Ok(_deKiemTraService.addDeKiemTra(deKiemTra_Custom));
        }
    }
}
