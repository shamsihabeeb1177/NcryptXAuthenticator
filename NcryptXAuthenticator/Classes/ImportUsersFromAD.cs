using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    internal class ImportUsersFromAD
    {
        

        public ImportUsersFromAD()
        {

        }


        public List<UserModel> Import(AdDataModel ad)
        {
            List<UserModel> users = new List<UserModel>();
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, ad.Server + ":" + ad.Port, ad.DC, ContextOptions.SimpleBind | ContextOptions.ServerBind, ad.Username, ad.Password);
            UserPrincipal user = new UserPrincipal(pc);
            PrincipalSearcher ps = new PrincipalSearcher(user);
            int num = new Random().Next(1000, 9999);

            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 32; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);

            }
            foreach (UserPrincipal result in ps.FindAll())
            {
                if (result != null && result.DisplayName != null)
                {
                    users.Add(new UserModel
                    {
                        DisplayName = result.DisplayName,
                        SamAccountName = result.SamAccountName,
                        EmailAddress = result.EmailAddress,
                        UserPrincipalName = result.UserPrincipalName,
                        VoiceTelephoneNumber = result.VoiceTelephoneNumber,
                        Enabled = (bool)result.Enabled,
                        GivenName = result.GivenName,
                        Surname = result.Surname,
                        seed =sb.ToString(),
                        
                    });;

                    return users;

                }
                else
                {
                    return null;
                }


            }
            return null;
        }



    }
}



