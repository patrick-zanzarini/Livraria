﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LivrariaContext>
    {
        public DesignTimeDbContextFactory()
        {
        }

        public LivrariaContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<LivrariaContext>();
            var connectionString = configuration.GetConnectionString("DefaultDatabase");
                builder.UseSqlServer(connectionString);
            return new LivrariaContext(builder.Options);
        }
    }
}
