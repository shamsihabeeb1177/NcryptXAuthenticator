using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NcryptXAuthenticator.APIclasses;
using NcryptXAuthenticator.Pages.UserPortal.config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Classes
{
    public class StoreAdConnectionContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source = localhost\SQLEXPRESS;Initial Catalog=ADConfigDB; Integrated Security=true");
            

        }
        public DbSet<AdDataModel> Settings { get; set; }
        public DbSet<UserModel> UsersMFA { get; set; }
        public DbSet<smsConnectorModel> smsConfig { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<radiusConfig> RadiusClients { get; set; }
    }




}
