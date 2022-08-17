using Microsoft.AspNetCore.Mvc;
using NcryptXAuthenticator.Classes;
using System.Collections.Generic;

namespace NcryptXAuthenticator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadiusClientController : ControllerBase
    {
        [HttpGet]
        public List<radiusConfig> RadiusClient(string username, string deviceid, string mobile)
        {

            StoreAdConnectionContext con = new StoreAdConnectionContext();
            var clients = con.RadiusClients;
            List<radiusConfig> radli = new List<radiusConfig>();
            foreach (var client in clients)
            {
                radli.Add(client);
            }
            return radli;

            


        }
        }
}
