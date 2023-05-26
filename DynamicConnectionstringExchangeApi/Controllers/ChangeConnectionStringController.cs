using DynamicConnectionstringExchangeApi.DbConnections;
using DynamicConnectionstringExchangeApi.Models;
using DynamicConnectionstringExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamicConnectionstringExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeConnectionStringController : ControllerBase
    {
        private readonly ChangeConnectionStringDbContext _dbContext;
 

        public ChangeConnectionStringController(ChangeConnectionStringDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("getall")]
        public ActionResult Index()
        {
            var result = _dbContext.TestModel.ToList();

            var aa = _dbContext.Database.GetConnectionString();

            return Ok(new ResponseModel<List<TestModel>>(result, _dbContext.Database.GetConnectionString()));
        }
    }
}
