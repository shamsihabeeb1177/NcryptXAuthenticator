using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    public class UserModel
    {
        public string SamAccountName { get; set; }
        [Key]
        public string UserPrincipalName { get; set; }

        public string EmailAddress { get; set; }
        public string VoiceTelephoneNumber { get; set; }
        public string DisplayName { get; set; }
        public bool Enabled { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string seed { get; set; }

    }
}
