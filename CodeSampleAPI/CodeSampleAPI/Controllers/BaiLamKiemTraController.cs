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
    public class BaiLamKiemTraController : ControllerBase
    {
        private readonly IBaiLamKiemTraService _baiLamKiemTraService;
        public BaiLamKiemTraController(IBaiLamKiemTraService baiLamKiemTraService)
        {
            this._baiLamKiemTraService = baiLamKiemTraService;
        }

        [HttpPost]
        public IActionResult addBaiLamKiemTra(BaiLamKiemTraCustom baiLamKiemTraCustom )
        {
            return Ok(_baiLamKiemTraService.add(baiLamKiemTraCustom));
        }
    }
}
