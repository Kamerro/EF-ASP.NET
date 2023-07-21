using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;
using wft;
namespace wft.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService IWFS)
        {
            _logger = logger;
            _service = IWFS;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Route("Me")]
        public IEnumerable<WeatherForecast> Get([FromRoute] int max, [FromRoute] int min, [FromRoute] int items)
        {
            var response = _service.Get(max, min, items);
            return response;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [Route("generate/{max}/{min}/{items}")]
        public ActionResult<IEnumerable<WeatherForecast>> generate([FromRoute] int max, [FromRoute] int min, [FromRoute] int items)
        {
            var response = _service.Get(max, min, items);
            if (max < min || items < 0)
            {
                
                return BadRequest();
            }
            else
            {
                return StatusCode(200, response);
            }
        }

        [HttpPost(Name = "Posci")]
        [Route("Post")]
        public ActionResult<string> PostName()
        {
            //Dzia³a tylko po zwróceniu statusCode.
            //HttpContext.Response.StatusCode = 401;
            return StatusCode(401, "Hey");
        }
    }
}