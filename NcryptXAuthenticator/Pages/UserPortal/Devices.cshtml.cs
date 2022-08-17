using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NcryptXAuthenticator.Pages.UserPortal
{
    [Authorize(AuthenticationSchemes = "mfa")]
    public class DevicesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
