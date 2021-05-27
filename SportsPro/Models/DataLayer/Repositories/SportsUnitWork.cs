using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;

namespace SportsPro.Models
{
    public class SportsUnitWork : ISportsUnitWork
    {
        //Initialize contexts
        private SportsProContext context { get; set; }
        public SportsUnitWork(SportsProContext ctx)
        {
            context = ctx;
        }

        // All get a repository (if it exists). Otherwise create a new one
        private IRepository<Customer> customerData;
        public IRepository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                {
                    customerData = new Repository<Customer>(context);
                }
                return customerData;
            }
        }

        private IRepository<Country> countryData;
        public IRepository<Country> Countries
        {
            get
            {
                if (countryData == null)
                {
                    countryData = new Repository<Country>(context);
                }
                return countryData;
            }
        }

        private IRepository<Incident> incidentData;
        public IRepository<Incident> Incidents
        {
            get
            {
                if (incidentData == null)
                {
                    incidentData = new Repository<Incident>(context);
                }
                return incidentData;
            }
        }

        private IRepository<Product> productData;
        public IRepository<Product> Products
        {
            get
            {
                if (productData == null)
                {
                    productData = new Repository<Product>(context);
                }
                return productData;
            }
        }

        private IRepository<Technician> technicianData;
        public IRepository<Technician> Technicians
        {
            get
            {
                if (technicianData == null)
                {
                    technicianData = new Repository<Technician>(context);
                }
                return technicianData;
            }
        }

        private IRepository<User> userData;
        public IRepository<User> Users
        {
            get
            {
                if (userData == null)
                {
                    userData = new Repository<User>(context);
                }
                return userData;
            }
        }
        private IRepository<CustomerProduct> customerproductData;
        public IRepository<CustomerProduct> CustomerProducts
        {
            get
            {
                if (customerproductData == null)
                {
                    customerproductData = new Repository<CustomerProduct>(context);
                }
                return customerproductData;
            }
        }

        // Save the changes in the context
        public void save()
        {
            context.SaveChanges();
        }
    }
}
