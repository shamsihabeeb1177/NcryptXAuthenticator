using Microsoft.AspNetCore.Mvc;
using NcryptXAuthenticator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NcryptXAuthenticator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class getallController : ControllerBase
    {
        // GET: api/<ValuesController>

        StoreAdConnectionContext _dbContext = new StoreAdConnectionContext();

        [HttpGet]
        public Array getAll()
        {
            Object[] getall = _dbContext.users.ToArray();
            return getall;
        }

    }
}
