using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NcryptXAuthenticator.Classes;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NcryptXAuthenticator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class removeController : ControllerBase
    {
        StoreAdConnectionContext _dbContext = new StoreAdConnectionContext();
        // GET: api/<removeController>
        [HttpGet]
        public void Remove()
        {

            var test = _dbContext.users.Where(s => s.enddate <= DateTime.Now);
            var test1 = test.Where(s => s.status == "Pending");
            _dbContext.users.RemoveRange(test1);
            _dbContext.SaveChanges(true);
        }
    }
}
