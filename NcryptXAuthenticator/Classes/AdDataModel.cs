using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    public class AdDataModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }

        [Key]
        public string ConnectionName { get; set; }
        public string Server { get; set; }
        public string DC { get; set; }

    }
}
