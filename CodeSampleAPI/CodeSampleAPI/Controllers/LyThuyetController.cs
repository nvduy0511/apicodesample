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
    public class LyThuyetController : ControllerBase
    {
        private readonly ILyThuyetService _lyThuyetService;
        public LyThuyetController(ILyThuyetService lyThuyetService)
        {
            this._lyThuyetService = lyThuyetService;
        }

        [HttpGet("getOne")]
        public IActionResult getLyThuyetByID(int id)
        {
            return Ok(_lyThuyetService.getLyThuyetByID(id));
        }

        [HttpGet("getAll")]
        public IActionResult getAllLyThuyetByIDMonHoc(int id)
        {
            return Ok(_lyThuyetService.getAllLyThuyetByIDMonHoc(id));
        }
    }
}
