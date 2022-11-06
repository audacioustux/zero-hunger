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
    public class CollectRequestController : Controller
    {
        private PostgreSqlDBContext _dbContext;

        public CollectRequestController(PostgreSqlDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.CollectRequest.ToListAsync());
        }

        [HttpGet]
        [Route("getCollectRequestById")]
        public async Task<IActionResult> GetCollectRequestByIdAsync(int id)
        {
            return Ok(await _dbContext.CollectRequest.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CollectRequest collectRequest)
        {
            _dbContext.CollectRequest.Add(collectRequest);
            await _dbContext.SaveChangesAsync();
            return Created($"/getCollectRequestById?id={collectRequest.Id}", collectRequest);
        }
    }
}
