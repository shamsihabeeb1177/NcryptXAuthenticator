using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Pages.UserPortal.config
{
    public class manageusersModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string deletedbuser, List<string> dbuser, string disableuser, string enableuser)
        {
            if (deletedbuser != null)
            {
                StoreAdConnectionContext con = new StoreAdConnectionContext();
                if (dbuser != null)
                {
                    foreach (var user in dbuser)
                    {
                        var du = con.UsersMFA.Find(user);
                        con.UsersMFA.Remove(du);
                        con.SaveChanges();
                    }
                    ViewData["Message"] = "Deleted users sucessfully";
                }
            }

            if (disableuser != null)
            {
                StoreAdConnectionContext con = new StoreAdConnectionContext();
                
                if (dbuser != null)
                {
                    foreach (var user in dbuser)
                    {
                        var du = con.UsersMFA.Find(user);
                        du.Enabled = false;
                        con.SaveChanges();
                    }
                    ViewData["Message"] = "Disabled users sucessfully";
                }
            }

            if (enableuser != null)
            {
                StoreAdConnectionContext con = new StoreAdConnectionContext();
                if (dbuser != null)
                {
                    foreach (var user in dbuser)
                    {
                        var du = con.UsersMFA.Find(user);
                        du.Enabled = true;
                        con.SaveChanges();
                    }
                    ViewData["Message"] = "Disabled users sucessfully";
                }
            }



            return Page();
        }
        }
}
