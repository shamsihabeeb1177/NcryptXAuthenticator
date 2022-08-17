using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Text;
using System;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Pages.UserPortal.config
{
    public class importModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string import )
        {

            if (import != null)
            {

                StoreAdConnectionContext con = new StoreAdConnectionContext();
                var ad = con.Settings.Find("test");
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, ad.Server + ":" + ad.Port, ad.DC, ContextOptions.SimpleBind | ContextOptions.ServerBind, ad.Username, ad.Password);
                UserPrincipal user = new UserPrincipal(pc);
                PrincipalSearcher search = new PrincipalSearcher(user);
                UserModel usr = new UserModel();

                List<string> tes = new List<string>();

                foreach (var dn in con.UsersMFA)
                {
                    tes.Add(dn.UserPrincipalName);
                }


                foreach (UserPrincipal result in search.FindAll())
                {





                    if (result.UserPrincipalName != null)
                    {
                        int num = new Random().Next(1000, 9999);
                        StringBuilder sb = new StringBuilder();
                        const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        Random rnd = new Random();

                        for (int i = 0; i < 32; i++)
                        {
                            int index = rnd.Next(chars.Length);
                            sb.Append(chars[index]);

                        }

                        usr.DisplayName = result.DisplayName;
                        usr.SamAccountName = result.SamAccountName;
                        usr.EmailAddress = result.EmailAddress;
                        usr.UserPrincipalName = result.UserPrincipalName;
                        usr.VoiceTelephoneNumber = result.VoiceTelephoneNumber;
                        usr.Enabled = (bool)result.Enabled;
                        usr.GivenName = result.GivenName;
                        usr.Surname = result.Surname;
                        usr.seed = sb.ToString();



                        if (!tes.Contains(result.UserPrincipalName))
                        {
                            con.UsersMFA.Add(usr);
                            con.SaveChanges();
                        }


                        ViewData["Message"] = "imported users sucessfully";

                    }



                }


                return Page();

            }

            return Page();
        }
    }
}
