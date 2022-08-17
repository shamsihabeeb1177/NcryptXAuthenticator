using System.ComponentModel.DataAnnotations;

namespace NcryptXAuthenticator.Classes
{
    public class smsConnectorModel
    {
        [Key]
        public string Name { get; set; }
        public string headerkey { get; set; }
        public string targeturl { get; set; }
        public string port { get; set; }
        public string body { get; set; }
        public string bodytype { get; set; }
    }
}
