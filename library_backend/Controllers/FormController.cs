using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_back.Models;

namespace library_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        IFormRepository rep;
        public FormController(IFormRepository r)
        {
            rep = r;
        }

        [HttpPost]
        public async Task<ActionResult<Rootobject>> Post(Rootobject rootobject)
        {
            //try
            //{
                rep.Create(rootobject);
                return Ok(rootobject);
            //}
            //catch { return StatusCode(500); }
        }
    }
}
