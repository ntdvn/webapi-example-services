using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using Microsoft.AspNetCore.Mvc;
using webapi_example_services.Models.Entities;

namespace webapi_example_services.Controllers
{
    [Route("api/crawler")]
    public class CrawlerController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> Register()
        {
            return Ok();
        }
    }
}