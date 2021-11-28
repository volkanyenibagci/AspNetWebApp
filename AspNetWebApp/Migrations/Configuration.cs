
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AspNetWebApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AspNetWebApp.Models.Siniflar.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}