using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Movieapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {        
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("MovieList")]
        public async Task<IActionResult> MovieList()
        {
            List<MoviesModel> items = new List<MoviesModel>();
            try
            {
                using (StreamReader r = new StreamReader("json/Movies.json"))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<MoviesModel>>(json);
                }
                return new OkObjectResult(items);
            }
            catch (Exception e)
            {

                return new BadRequestResult();
            }
        }


        
    }
}
