using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IList<Job> Get()
        {
            return (this._dbContext.Job.Include(x => x.User).ToList());
        }
    }
}


