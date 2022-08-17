using AspNetCore.Totp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NcryptXAuthenticator.Pages
{
    public class Database_ConfigurationModel : PageModel
    {
        private readonly ITotpGenerator _totpGenerator;
        private readonly ITotpSetupGenerator _totpQrGenerator;
        private readonly ITotpValidator _totpValidator;
        public void OnGet()
        {
            
        }

        
        
    }
}
