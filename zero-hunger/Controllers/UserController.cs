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
    public class UserController : Controller
    {
        private PostgreSqlDBContext _dbContext;

        public UserController(PostgreSqlDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.User.ToListAsync());
        }

        [HttpGet]
        [Route("getUserById")]
        public async Task<IActionResult> GetUserByIdAsync(int id) {
            return Ok(await _dbContext.User.FindAsync(id));
	    }

        [HttpPost]
        public async Task<IActionResult> PostAsync(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return Created($"/getUserById?id={user.Id}", user);
        }
    }
}


