using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTieto.Models; //tämä lisätään

namespace WebApiTieto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiheController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Topic> Alltopics()
        {
            TestiContext context2 = new();
            List<Topic> alltopics = context2.Topics.ToList();
            return alltopics;
        }
    }
}
