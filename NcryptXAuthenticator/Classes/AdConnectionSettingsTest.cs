using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.AccountManagement;

namespace NcryptXAuthenticator.Classes
{
    public class AdConnectionSettingsTest
    {

        public AdConnectionSettingsTest()
        {

        }

        public string ConnectionCheck(AdDataModel ad)
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, ad.Server + ":" + ad.Port, ad.DC, ContextOptions.SimpleBind | ContextOptions.ServerBind, ad.Username, ad.Password);
            if (pc.ValidateCredentials(ad.Username, ad.Password))
            {
                return "Connection Successful";
            }
            else
            {
                return "Connection Failed";
            }
        }

        public PrincipalContext adContext(AdDataModel ad)
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, ad.Server + ":" + ad.Port, ad.DC, ContextOptions.SimpleBind | ContextOptions.ServerBind, ad.Username, ad.Password);
            return pc;
        }



    }
}
