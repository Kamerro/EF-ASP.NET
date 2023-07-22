using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wft.Entities;

namespace wft.Controllers
{
    [Route("controller")]
    public class RestaurantController : ControllerBase
    {
        private RestaurantDbContext dbContext;
        public RestaurantController(RestaurantDbContext context)
        {
                      dbContext = context;
        }
        [HttpGet]
        [Route("Restaurants")]
        public ActionResult GetAll()
        {

            return Ok(dbContext.Restaurants.ToList());
        }
        [HttpGet]
        [Route("Restaurants/{id}")]
        public ActionResult Get([FromRoute]int id) {

            return Ok(dbContext.Restaurants.Where(r => r.Id == id));
        }
    }
}
