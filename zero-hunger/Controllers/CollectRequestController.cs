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
        private readonly PostgreSqlDBContext _dbContext;

        public CollectRequestController(PostgreSqlDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.CollectRequest.ToListAsync());
        }

        [HttpGet]
        [Route("getCollectRequestById")]
        public async Task<IActionResult> GetCollectRequestById(int id)
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

        [HttpPut]
        [Route("setAsCompleted")]
        public async Task<IActionResult> SetAsCompleted(CollectRequest collectRequest)
        {
            var _collectRequest = await _dbContext.CollectRequest.FindAsync(collectRequest.Id);
            if (_collectRequest != null)
            {
                _collectRequest.IsCompleted = true;
                _collectRequest.CompletedAt = DateTime.Now;
                _dbContext.CollectRequest.Update(_collectRequest);
                await _dbContext.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpPut]
        [Route("setAsCollected")]
        public async Task<IActionResult> SetAsCollected(CollectRequest collectRequest)
        {
            var _collectRequest = await _dbContext.CollectRequest.FindAsync(collectRequest.Id);
            if (_collectRequest != null)
            {
                _collectRequest.IsCollected = true;
                _collectRequest.CollectedAt = DateTime.Now;
                _dbContext.CollectRequest.Update(_collectRequest);
                await _dbContext.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
