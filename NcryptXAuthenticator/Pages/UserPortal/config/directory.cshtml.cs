using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Pages.UserPortal.config
{
    public class directoryModel : PageModel
    {
        [BindProperty]
        public formelem form { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(formelem form, string save, string delete, string test)
        {

            if (save != null)
            {
                AdDataModel fr = new AdDataModel();
                fr.Server = form.server;
                fr.Port = form.port;
                fr.DC = form.bind;
                fr.Username = form.binduser;
                fr.Password = form.bindpass;
                fr.ConnectionName = "test";

                StoreAdConnectionContext con = new StoreAdConnectionContext();
                con.Settings.Update(fr);
                con.SaveChanges();
                ModelState.AddModelError("save", "Settings saved successfully");
                ViewData["Message"] = "Successfully Saved Settings!";
                return Page();


            }

            if (delete != null)
            {
                AdDataModel fr = new AdDataModel();
                fr.Server = null;
                fr.Port = null;
                fr.DC = null;
                fr.Username = null;
                fr.Password = null;
                fr.ConnectionName = "test";

                StoreAdConnectionContext con = new StoreAdConnectionContext();
                con.Settings.Update(fr);
                con.SaveChanges();
                ModelState.AddModelError("save", "Settings saved successfully");
                ViewData["Message"] = "Successfully Deleted Settings!";
                return Page();


            }

            if (test != null)
            {


                StoreAdConnectionContext con = new StoreAdConnectionContext();
                var conset = con.Settings.Find("test");
                AdConnectionSettingsTest t = new AdConnectionSettingsTest();
                AdDataModel ad = new AdDataModel();
                ad.Server = form.server;
                ad.Port = form.port;
                ad.Username = form.binduser;
                ad.Password = form.bindpass;
                ad.DC = form.bind;
                try
                {
                    var conn = t.ConnectionCheck(ad);
                    if (conn == "Connection Successful")
                    {
                        ViewData["Message"] = "Connection Successful";
                        return Page();
                    }
                    else
                    {
                        ViewData["Message"] = "Connection Failed";
                        return Page();
                    }
                }
                catch (Exception e)
                {
                    ViewData["Message"] = "Connection Failed";
                    return Page();
                }

            }

            return Page();
        }
    }

    public class formelem
    {
        public string server { get; set; }
        public string port { get; set; }
        public string bind { get; set; }
        public string binduser { get; set; }
        public string bindpass { get; set; }
        public string conname { get; set; }

    }
}