﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class SportsUnitWork : ISportsUnitWork
    {
        private SportsProContext context { get; set; }
        public SportsUnitWork(SportsProContext ctx)
        {
            context = ctx;
        }

        private Repository<Customer> customerData;
        public Repository<Customer> Customers
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

        private Repository<Country> countryData;
        public Repository<Country> Countries
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

        private Repository<Incident> incidentData;
        public Repository<Incident> Incidents
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

        private Repository<Product> productData;
        public Repository<Product> Products
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

        private Repository<Technician> technicianData;
        public Repository<Technician> Technicians
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

        private Repository<User> userData;
        public Repository<User> Users
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

        public void save()
        {
            context.SaveChanges();
        }
    }
}
