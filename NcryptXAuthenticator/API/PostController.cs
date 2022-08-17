using Microsoft.AspNetCore.Mvc;
using NcryptXAuthenticator.APIclasses;
using NcryptXAuthenticator.Classes;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NcryptXAuthenticator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        StoreAdConnectionContext _dbContext = new StoreAdConnectionContext();

        [HttpPost]
        public void Post([FromBody] users usr)
        {

            var terra = _dbContext.users.Where(s => s.username == usr.username && s.deviceid == usr.deviceid).FirstOrDefault<users>();
            terra.status = "Active";
            terra.startdate = DateTime.Now;
            terra.enddate = DateTime.Today.AddDays(30);
            /*string accountSid = "AC8963d740e7c9b569f03197047e219f96";
            string authToken = "333091c92cb01dbcc3f5863d5134208c";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "You have successfully Activated your device, Your device will expire on  " + terra.enddate ,
                from: new Twilio.Types.PhoneNumber("+14352917123"),
                to: new Twilio.Types.PhoneNumber(terra.mobile)
            );*/
            _dbContext.Update(terra);
            _dbContext.SaveChanges();
        }

    }
}
