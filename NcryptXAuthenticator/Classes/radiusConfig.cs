using System.ComponentModel.DataAnnotations;

namespace NcryptXAuthenticator.Classes
{
    public class radiusConfig
    {
        [Key]
        public int id { get; set; }
        public string ClientName { get; set; }
        public string secret { get; set; }
        public string port { get; set; }

    }
}
