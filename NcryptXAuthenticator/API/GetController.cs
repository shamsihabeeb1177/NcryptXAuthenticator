using Microsoft.AspNetCore.Mvc;
using NcryptXAuthenticator.Classes;
using System.Text;
using System;
using NcryptXAuthenticator.APIclasses;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NcryptXAuthenticator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        StoreAdConnectionContext _dbContext = new StoreAdConnectionContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get(string username, string deviceid, string mobile)
        {

            var usrnme = _dbContext.users.Where(s => s.username == username).FirstOrDefault<users>();
            var device = _dbContext.users.Where(s => s.deviceid == deviceid).FirstOrDefault<users>();
            int num = new Random().Next(1000, 9999);

            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);

            }



            if (usrnme == null || usrnme != null && deviceid != usrnme.deviceid)
            {
                users usr2 = new users();
                usr2.username = username;
                usr2.devicetype = "Device";
                usr2.deviceid = deviceid;
                usr2.status = "Pending";
                usr2.startdate = DateTime.Now;
                usr2.enddate = DateTime.Now.AddMinutes(10);
                usr2.mobile = mobile;
                usr2.randomNumber = num.ToString();
                usr2.connectionString = sb.ToString();
                _dbContext.users.Add(usr2);
                _dbContext.SaveChanges();
                return "State Set to pending";
            }


            if (usrnme != null && deviceid != null)
            {
                if (usrnme.username == username && device.deviceid == deviceid && DateTime.Now < usrnme.enddate)
                {
                    return usrnme.status;
                }
                else
                {
                    return "State Set to Pending";
                }
            }
            else
            {
                return "not found";
            }


        }


    }
}
