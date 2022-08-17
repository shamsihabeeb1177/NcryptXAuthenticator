using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NcryptXAuthenticator.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace NcryptXAuthenticator.Pages.UserPortal.config
{
    public class radiusclientModel : PageModel
    {
        [BindProperty]
        public radcl rc { get; set; }
        public void OnGet()
        {
        }

        public  void OnPost(string radname, string radport,string radsecret, int radid, string save, string delete)
        {
            
            if(save != null)
            {
                StoreAdConnectionContext con = new StoreAdConnectionContext();
                var client = con.RadiusClients.Find(radid);
                client.secret = radsecret;
                client.port = radport;
                client.ClientName = radname;
                con.RadiusClients.Update(client);
                con.SaveChanges();
                
            }

            if (delete != null)
            {
                StoreAdConnectionContext con = new StoreAdConnectionContext();
                var client = con.RadiusClients.Find(radid);
                client.secret = null;
                client.port = null;
                client.ClientName = null;
                con.RadiusClients.Update(client);
                con.SaveChanges();

            }




        }
        

        
        }

    public class radcl
    {

        public string name;
        public string secret;
        public string port;
              
    }
}
