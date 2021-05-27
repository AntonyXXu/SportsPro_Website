using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SportsPro.Models.DataLayer.SeedData
{
    internal class SeedIncident : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            // Each incident must have one customer
            builder.HasOne("SportsPro.Models.Customer", "Customer")
                .WithMany()
                .HasForeignKey("CustomerID")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Each incident must have one product
            builder.HasOne("SportsPro.Models.Product", "Product")
                .WithMany()
                .HasForeignKey("ProductID")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Each incident must have one Technician
            builder.HasOne("SportsPro.Models.Technician", "Technician")
                .WithMany()
                .HasForeignKey("TechnicianID");


            // Initialize data for incidents
            builder.HasData(
                  new Incident
                  {
                      IncidentID = 1,
                      CustomerID = 1010,
                      ProductID = 1,
                      TechnicianID = 11,
                      Title = "Could not install",
                      Description = "Media appears to be bad.",
                      DateOpened = DateTime.Parse("2020-01-08"),
                      DateClosed = DateTime.Parse("2020-01-10")
                  },
                new Incident
                {
                    IncidentID = 2,
                    CustomerID = 1002,
                    ProductID = 4,
                    TechnicianID = 14,
                    Title = "Error importing data",
                    Description = "Received error message 415 while trying to import data from previous version.",
                    DateOpened = DateTime.Parse("2020-01-09"),
                    DateClosed = null
                },
                new Incident
                {
                    IncidentID = 3,
                    CustomerID = 1015,
                    ProductID = 6,
                    TechnicianID = 15,
                    Title = "Could not install",
                    Description = "Setup failed with code 104.",
                    DateOpened = DateTime.Parse("2020-01-08"),
                    DateClosed = DateTime.Parse("2020-01-10")
                },
                new Incident
                {
                    IncidentID = 4,
                    CustomerID = 1010,
                    ProductID = 3,
                    TechnicianID = null,
                    Title = "Error launching program",
                    Description = "Program fails with error code 510, unable to open database.",
                    DateOpened = DateTime.Parse("2020-01-10"),
                    DateClosed = null
                }
            );
        }
    }
}
