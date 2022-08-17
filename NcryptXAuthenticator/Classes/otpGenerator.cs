using AspNetCore.Totp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    public class otpGenerator
    {
        public int tokenGen(string str)
        {
            var generator = new TotpGenerator();

            var token = generator.Generate(str);
            return token;
        }

    }
}
