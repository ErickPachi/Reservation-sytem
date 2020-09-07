using BeanSceneDipAssT2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Domain;
using Microsoft.AspNetCore.Identity;

namespace BeanSceneDipAssT2.DataAccess
{
    public class BeanSceneDBContext : IdentityDbContext<AppUser>
    {
        public BeanSceneDBContext(DbContextOptions<BeanSceneDBContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table_Reservation> Table_Reservations { get; set; }
        public DbSet<Sitting> Sittings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}