using CodeSampleAPI.Data;
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

        [HttpGet("getByUidGiangVien")]
        public IActionResult getByUidGiangVien(string uID)
        {
            return Ok(_phongHocService.getListPhongHocByUidGiangVien(uID));
        }

        [HttpGet("getOne")]
        public IActionResult getOneById(string id)
        {
            return Ok(_phongHocService.getOneByID(id));
        }

        [HttpPost("addUser")]
        public IActionResult addUserToPhongHoc(string uID, string id)
        {
            return Ok(_phongHocService.addUserToPhongPhong(uID, id));
        }
        [HttpPost("createRoom")]
        public IActionResult createRoom(PhongHoc phong)
        {
            return Ok(_phongHocService.createPhongHoc(phong));
        }
    }
}
