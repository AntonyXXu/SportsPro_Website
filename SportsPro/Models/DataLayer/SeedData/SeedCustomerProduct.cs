using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SportsPro.Models
{
    internal class SeedCustomerProduct : IEntityTypeConfiguration<CustomerProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.HasKey(cr => new
            {
                cr.ProductID,
                cr.CustomerID
            });

            builder.HasOne(cr => cr.Product)
                .WithMany(b => b.CustomerProducts)
                .HasForeignKey(cr => cr.ProductID);
            builder.HasOne(cr => cr.Customer)
                        .WithMany(a => a.CustomerProducts)
                        .HasForeignKey(cr => cr.CustomerID);

            builder.HasData(
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
    }
}
