using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    internal class getAdConnectionSettings
    {
        public StoreAdConnectionContext _dbContext;

       
        public getAdConnectionSettings(StoreAdConnectionContext context)
        {
            _dbContext = context;

        }

        public AdDataModel getConnectionDetails(string conname)
        {
            
            AdDataModel adDataModel = new AdDataModel();

            var queriedobj = _dbContext.Settings.Where(op => op.ConnectionName == conname).FirstOrDefault();

            adDataModel.Server = queriedobj.Server;
            adDataModel.Port = queriedobj.Port;
            adDataModel.DC = queriedobj.DC;
            adDataModel.Username = queriedobj.Username;
            adDataModel.Password = queriedobj.Password;
            adDataModel.ConnectionName = queriedobj.ConnectionName;
            return adDataModel;

        }





    }
}
