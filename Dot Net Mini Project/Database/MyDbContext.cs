using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace Dot_Net_Mini_Project
{
    /*You must have a class that inherits from EF core class DbContext. This class holds the info. and config.
     * for accessing your database*/
    class MyDbContext : DbContext
    {
        /* overriding the OnConfiguring method.*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = VISHALMIL-VD\\SQL2017; Database = imsProject; user id=sa; password=cybage@123456;");
        }

        /* creating properties of all model classes of type DbSet*/
        public DbSet<User> users { get; set; }
        public DbSet<Iphone> iphones { get; set; }
        public DbSet<Ipad> ipads { get; set; }
        public DbSet<Iwatch> iwatches { get; set; }
        public DbSet<Airpod> airpods { get; set; }
       
    }
}
