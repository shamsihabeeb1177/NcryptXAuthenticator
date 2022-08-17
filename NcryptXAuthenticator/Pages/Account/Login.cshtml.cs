using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential mycredential { get; set; }

        public LoginModel()
        {

        }
        
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
            
            if (ad.ConnectionCheck(adData) == "Connection Successful")
            {
                
              

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, mycredential.UserName),
                    new Claim(ClaimTypes.Role,"User")

                };
                    var identity = new ClaimsIdentity(claims, "cookie");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("cookie", principal);
                    return RedirectToPage("/UserPortal/register");
                
                
            }
            return Page();

        }
    }

    public class Credential
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
