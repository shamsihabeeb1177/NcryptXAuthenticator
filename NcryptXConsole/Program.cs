
using NcryptXConsole.Classes;
using System;

namespace NcryptXConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdDataModel adData = new AdDataModel();
            adData.Username = "administrator@deadflatbird.lab";
            adData.Password = "Citrix@123";
            adData.Port = "389";
            adData.Server = "192.168.192.132";
            adData.DC = "DC=deadflatbird,Dc=lab";
            AdConnectionSettingsTest ad = new AdConnectionSettingsTest();
            string w = ad.ConnectionCheck(adData);
            Console.WriteLine(w);

            otpGenerator otp = new otpGenerator();
            Console.WriteLine("The token number is  " + otp.tokenGen("habeebshamsi123456")  ); 
            otpValidator otpVal = new otpValidator();
            Console.WriteLine("The validation for the token is " + otpVal.validate(41300,"habeebshamsi123456"));
            QrCodeGenerator qrCodeGenerator = new QrCodeGenerator();
            Console.WriteLine(qrCodeGenerator.qrGen("test", "habeebshamsi123456")); 
            
        }
    }
}
