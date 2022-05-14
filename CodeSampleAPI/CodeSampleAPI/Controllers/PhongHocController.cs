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
    public class PhongHocController : ControllerBase
    {
        private readonly IPhongHocService _phongHocService;

        public PhongHocController(IPhongHocService phongHocService)
        {
            this._phongHocService = phongHocService;
        }

        [HttpGet("getByUid")]
        public IActionResult getPhongHocByUid(string uID)
        {
            return Ok(_phongHocService.getListPhongHocByUidUser(uID));
        }

        [HttpPost("addUser")]
        public IActionResult addUserToPhongHoc(string uID, int id)
        {
            return Ok(_phongHocService.addUserToPhongPhong(uID, id));
        }
    }
}
