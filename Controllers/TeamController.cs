using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa.DTOs;
using kol2poprawa.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kol2poprawa.Controllers
{
  
   [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IRepoService _repserv;
        public TeamController(IRepoService service)
        {
            _repserv = service;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var info = await _repserv.TeamInfo(id);
            if(info == null) {
                return NotFound();
            }
            return Ok(info);
        }
        
        [HttpPost("team/{member}/{id}/member")]
        public async Task<IActionResult> PostTModel(MemberPost member, int id)
        {
            
            var memberadded = await _repserv.AddMember(member, id); 
            if(memberadded){
             return Created(" "," ");
            }
            else return BadRequest("Not belong to same orgazniation");
        }

        
    }
}