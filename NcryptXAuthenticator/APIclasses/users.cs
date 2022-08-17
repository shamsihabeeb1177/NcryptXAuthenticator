using Microsoft.EntityFrameworkCore;
using System;

namespace NcryptXAuthenticator.APIclasses
{
    [Index(nameof(users.deviceid), IsUnique = true)]
    public class users
    {

        public int id { get; set; }

        public string username { get; set; }

        public string deviceid { get; set; }
        public string devicetype { get; set; }

        public string status { get; set; }

        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }

        public String mobile { get; set; }

        public String connectionString { get; set; }

        public String randomNumber { get; set; }


    }
}
