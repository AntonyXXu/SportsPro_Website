﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using SportsPro.Models.DataLayer.SeedData;

namespace SportsPro.Models
{
    public class SportsProContext : IdentityDbContext<User>
    {
        public SportsProContext(DbContextOptions<SportsProContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new SeedProduct());
            modelBuilder.ApplyConfiguration(new SeedTechnician());
            modelBuilder.ApplyConfiguration(new SeedCountry());
            modelBuilder.ApplyConfiguration(new SeedCustomer());
            modelBuilder.ApplyConfiguration(new SeedIncident());

            modelBuilder.Entity<CustomerProduct>().HasKey(cr => new { cr.ProductID, cr.CustomerID });

            modelBuilder.Entity<CustomerProduct>().HasOne(cr => cr.Product)
                .WithMany(b => b.CustomerProducts)
                .HasForeignKey(cr => cr.ProductID);
            modelBuilder.Entity<CustomerProduct>().HasOne(cr => cr.Customer)
                .WithMany(a => a.CustomerProducts)
                .HasForeignKey(cr => cr.CustomerID);

            modelBuilder.Entity<CustomerProduct>().HasData(
                new CustomerProduct
                {
                    ProductID = 4,
                    CustomerID = 1002
                },
                new CustomerProduct
                {
                    ProductID = 3,
                    CustomerID = 1010
                }
            );
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
            serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        public static async Task CreateTechnicianRole(IServiceProvider serviceProvider)
        {

            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string roleName = "Technician";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

        }


    
    }
}