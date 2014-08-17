using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System;
using versity.data.DataAccess.EntityFramework;
using versity.data.Migrations;

[assembly: OwinStartupAttribute(typeof(versity.Startup))]
namespace versity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VersityDbContext, Configuration>());
        }
    }
}
