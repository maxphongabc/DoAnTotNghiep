using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class ProjectFactory : IDesignTimeDbContextFactory<ProjectDPContext>
    {
        public ProjectDPContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("ProjectDPContext");

            var optionsBuilder = new DbContextOptionsBuilder<ProjectDPContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectDPContext(optionsBuilder.Options);
        }
    }
}
