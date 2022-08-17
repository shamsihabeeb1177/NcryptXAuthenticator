using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Pages.Account
{


   
    public class mfaModel : PageModel
    {
        [BindProperty]
        public creds mycredential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StoreAdConnectionContext context = new StoreAdConnectionContext();
            getAdConnectionSettings adset = new getAdConnectionSettings(context);
            var constring = adset.getConnectionDetails("test");
            AdConnectionSettingsTest ad = new AdConnectionSettingsTest();
            AdDataModel adData = new AdDataModel();
            adData.Port = constring.Port;
            adData.Server = constring.Server;
            adData.Username = mycredential.UserName;
            adData.Password = mycredential.Password;
            adData.DC = constring.DC;
            otpValidator otpValidator = new otpValidator();
            var usr = context.UsersMFA.Where(op=> op.UserPrincipalName == mycredential.UserName).FirstOrDefault();
            string seedval = usr.seed + usr.UserPrincipalName;
            var tokenval=otpValidator.validate(mycredential.Token, seedval);
            System.Console.WriteLine("OTP Is********************************************"+ tokenval);
            if (ad.ConnectionCheck(adData) == "Connection Successful"&& tokenval)
            {
                
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, mycredential.UserName),
                    new Claim(ClaimTypes.Role,"User")

                };
                    var identity = new ClaimsIdentity(claims, "mfa");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("mfa", principal);
                    return RedirectToPage("/UserPortal/devices");
                

            }
            return Page();

        }

    }
    public class creds
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int Token { get; set; }
    }

}
