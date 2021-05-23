using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public interface ISportsUnitWork
    {
        Repository<Customer> Customers {get;}
        Repository<Incident> Incidents { get; }
        Repository<Product> Products { get; }
        Repository<Country> Countries { get; }
        Repository<Technician> Technicians { get; }
        Repository<User> Users { get; }

        void save();


    }
}
