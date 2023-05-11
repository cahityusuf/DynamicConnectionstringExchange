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
        private readonly IConfiguration _configuration; 
        private readonly IConnectionStringProvider _connectionStringProvider;

        public ChangeConnectionStringController(ChangeConnectionStringDbContext dbContext, IConfiguration configuration, IConnectionStringProvider connectionStringProvider)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _connectionStringProvider = connectionStringProvider;
        }

        [HttpGet("getall")]
        public ActionResult Index()
        {
            var result = _dbContext.TestModel.ToList();

            return Ok(new ResponseModel<List<TestModel>>(result, _dbContext.Database.GetConnectionString()));
        }
    }
}
