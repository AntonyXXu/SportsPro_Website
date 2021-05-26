using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public interface ISportsUnitWork
    {
        IRepository<Customer> Customers {get;}
        IRepository<Incident> Incidents { get; }
        IRepository<Product> Products { get; }
        IRepository<Country> Countries { get; }
        IRepository<Technician> Technicians { get; }
        IRepository<User> Users { get; }
        IRepository<CustomerProduct> CustomerProducts { get; }

        void save();


    }
}
