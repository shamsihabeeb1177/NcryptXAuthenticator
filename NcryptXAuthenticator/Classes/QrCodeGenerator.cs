using AspNetCore.Totp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    public class QrCodeGenerator
    {
        public string qrGen(string id, string key)
        {
            var qrGenerator = new TotpSetupGenerator();
            var qrCode = qrGenerator.Generate(
                issuer: "NcryptX GenX R&D Inc",
                accountIdentity: id,
                accountSecretKey: key
            );

            return qrCode.QrCodeImage;


        }

    }
}
