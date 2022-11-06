using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zero_hunger.Models;

namespace zero_hunger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private PostgreSqlDBContext _dbContext;

        public RestaurantController(PostgreSqlDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.Restaurant.ToListAsync());
        }

        [HttpGet]
        [Route("getRestaurantById")]
        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            return Ok(await _dbContext.Restaurant.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Restaurant restaurant)
        {
            _dbContext.Restaurant.Add(restaurant);
            await _dbContext.SaveChangesAsync();
            return Created($"/getRestaurantById?id={restaurant.Id}", restaurant);
        }
    }
}
