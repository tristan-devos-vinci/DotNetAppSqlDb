using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [DbConfigurationType(typeof(AppServiceConfiguration))]
    public class MyDatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyDatabaseContext() : base("name=MyDbConnection")
        {
        }

        public System.Data.Entity.DbSet<DotNetAppSqlDb.Models.Todo> Todoes { get; set; }
    }
    public class AppServiceConfiguration : MicrosoftSqlDbConfiguration
    {
        public AppServiceConfiguration()
        {
            SetProviderFactory("System.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            SetProviderServices("System.Data.SqlClient", MicrosoftSqlProviderServices.Instance);
            SetExecutionStrategy("System.Data.SqlClient", () => new MicrosoftSqlAzureExecutionStrategy());
        }
    }
}
