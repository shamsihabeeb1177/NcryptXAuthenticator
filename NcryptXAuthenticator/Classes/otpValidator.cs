using AspNetCore.Totp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    public class otpValidator
    {
        public bool validate(int otp, string str)
        {
            var generator = new TotpGenerator();
            var validator = new TotpValidator(generator);
            var code = validator.Validate(str, otp);
            return code;
        }

    }
}
