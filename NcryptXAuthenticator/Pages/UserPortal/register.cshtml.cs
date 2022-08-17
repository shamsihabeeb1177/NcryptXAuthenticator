using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System.Linq;

namespace NcryptXAuthenticator.Pages.UserPortal
{
    [Authorize(AuthenticationSchemes ="cookie")]
    public class registerModel : PageModel
    {
        public void OnGet()
        {
            
            
        }
    }
}
