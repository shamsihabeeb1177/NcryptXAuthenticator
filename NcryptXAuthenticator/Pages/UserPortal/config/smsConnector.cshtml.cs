using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using NcryptXAuthenticator.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Twilio.TwiML.Voice;
using static System.Net.WebRequestMethods;

namespace NcryptXAuthenticator.Pages.UserPortal.config
{
    public class smsConnectorModel : PageModel
    {
        [BindProperty]
        public forme frm { get; set; }
        public void OnGet()
        {
        }

        public async void OnPostAsync(forme f, string delete, string save, string test, List<string> rad)
        {

            if (test != null)
            {
                StoreAdConnectionContext context = new StoreAdConnectionContext();
                var config = context.smsConfig.Find("test");
                

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/"+config.bodytype.ToString()));
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Post;
                msg.Headers.Host = "Localhost";

                /*
                use this code for otp and phonenumber variable
                if (config.body.Contains("{otp}"))
                {
                    
                    Console.WriteLine(config.body.ToString().Replace("{otp}", "4487"));
                }
                */

                if (config.headerkey != null)
                {
                    var headers = config.headerkey.Split(',');
                    foreach (var header in headers)
                    {
                        var b = header.Split(":");


                        var headerk = b[0];
                        var headerv = b[1];
                        Console.WriteLine("The key is " + headerk + " The value is " + headerv);
                        msg.Headers.Add(headerk, headerv);

                        if (config.bodytype == "xml")
                        {
                          //  msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                            msg.Content = new StringContent(config.body.ToString(), Encoding.UTF8, "application/xml");
                        }
                        if (config.bodytype == "json")
                        {
                          //  msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            msg.Content = new StringContent(config.body.ToString(), Encoding.UTF8, "application/json");
                        }

                    }
                }
                else
                {
                    if (config.bodytype.ToString() == "xml")
                    {

                      //  msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                        // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                        msg.Content = new StringContent(config.body.ToString(), Encoding.UTF8, "application/xml");
                    }
                    if (config.bodytype.ToString() == "json")
                    {

                       // msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        msg.Content = new StringContent(config.body.ToString(), Encoding.UTF8, "application/json");
                    }
                }

                

                var resp = await client.PostAsync(config.targeturl,msg.Content);
                Console.WriteLine("This is the request "+msg);
                Console.WriteLine("This is the request body: " + config.body.ToString().Trim());
                Console.WriteLine(resp);
                Console.WriteLine("This is the return code ########"+resp.StatusCode);
                
            }

            if (delete != null)
            {
                StoreAdConnectionContext context = new StoreAdConnectionContext();
                var config = context.smsConfig.Find("test");
                config.body = "";
                config.port = "";
                config.headerkey = "";
                config.targeturl = "";
                config.bodytype = "";
                context.smsConfig.Update(config);
                context.SaveChanges();
            }

            if (save != null)
            {
                StoreAdConnectionContext context = new StoreAdConnectionContext();
                var config = context.smsConfig.Find("test");
                config.body = f.body;
                config.port = f.port;
                config.bodytype = rad[0];   // change this code later
                config.headerkey = f.headerkey;
                config.targeturl = f.targeturl;
                context.smsConfig.Update(config);
                context.SaveChanges();
            }
        }



    }

    public class forme
    {
        public string headerkey { get; set; }
        public string targeturl { get; set; }
        public string port { get; set; }
        public string body { get; set; }
        public string bodytype { get; set; }
    }
}
