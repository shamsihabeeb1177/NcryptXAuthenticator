using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustAnotherAPI.Models;
using System.Diagnostics;
using JustAnotherAPI.data;
using System.Linq;
using System;

namespace NcryptXAuthenticator.Pages.UserPortal.config
{

    public class managedevicesModel : PageModel
    {

       

        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string enable, List<string> usr,string del, string disable, string restore)
        {
            
            if (restore != null && usr != null)
            {
                userDbContext dbcon = new userDbContext();
                foreach (var u in usr)
                {
                    string[] ud = u.Split("+");
                    var ut = dbcon.Users.Where(i => i.username == ud[0] && i.deviceid == ud[1]).FirstOrDefault();
                    ut.enddate = DateTime.Now + TimeSpan.FromDays(1);
                    dbcon.Users.Update(ut);
                    dbcon.SaveChanges();
                }
            }

            if (disable != null && usr != null)
            {
                userDbContext dbcon = new userDbContext();
                foreach (var u in usr)
                {
                    string[] ud = u.Split("+");
                    var ut = dbcon.Users.Where(i => i.username == ud[0] && i.deviceid == ud[1]).FirstOrDefault();
                    ut.status = "Pending";
                    dbcon.Users.Update(ut);
                    dbcon.SaveChanges();
                }
            }

            if (enable != null && usr != null)
            {
                userDbContext dbcon = new userDbContext();
                foreach (var u in usr)
                {
                    string[] ud = u.Split("+");
                    var ut = dbcon.Users.Where(i => i.username == ud[0] && i.deviceid == ud[1]).FirstOrDefault();
                    ut.status = "Active";
                    dbcon.Users.Update(ut);
                    dbcon.SaveChanges();
                }
            }


            if (del != null && usr != null)
            {
                userDbContext dbcon = new userDbContext();
                foreach (var u in usr)
                {
                    string[] ud = u.Split("+");
                    var ut= dbcon.Users.Where(i => i.username == ud[0] && i.deviceid == ud[1]).FirstOrDefault();
                    dbcon.Users.Remove(ut);
                    dbcon.SaveChanges();
                }
            }
            
            return Page();
        }
    }



}
