using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTieto.Models;  //

namespace WebApiTieto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KysyController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Quiz> Allquizzes()
        {
            TestiContext context = new();
            List<Quiz> allquizzes = context.Quizzes.ToList();
            return allquizzes;
        }
    }
}
