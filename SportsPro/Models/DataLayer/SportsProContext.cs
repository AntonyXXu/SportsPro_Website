using System;
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

            // Call seed data
            modelBuilder.ApplyConfiguration(new SeedProduct());
            modelBuilder.ApplyConfiguration(new SeedTechnician());
            modelBuilder.ApplyConfiguration(new SeedCountry());
            modelBuilder.ApplyConfiguration(new SeedCustomer());
            modelBuilder.ApplyConfiguration(new SeedIncident());
            modelBuilder.ApplyConfiguration(new SeedCustomerProduct());


        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
            serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //        Name = "Team Manager 1.0",
            //        YearlyPrice = 4.99M,
            //        ReleaseDate = DateTime.Parse("2017-05-01 00:00:00.000")
            //    },
            //    new Product
            //    {
            //        ProductID = 6,
            //        ProductCode = "TRNY10",
            //        Name = "Tournament Master 1.0",
            //        YearlyPrice = 4.99M,
            //        ReleaseDate = DateTime.Parse("2015-12-01 00:00:00.000")
            //    },
            //    new Product
            //    {
            //        ProductID = 7,
            //        ProductCode = "TRNY20",
            //        Name = "Tournament Master 2.0",
            //        YearlyPrice = 5.99M,
            //        ReleaseDate = DateTime.Parse("2018-02-15 00:00:00.000")
            //    }
            //);

            string username = "admin";
            string password = "P@ssw0rd";
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