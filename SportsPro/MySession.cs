using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SportsPro.Models;

namespace SportsPro
{
    public class MySession
    {
        private const string CustomerKey = "customer";
        private ISession session { get; set; }
        public MySession(ISession sessison)
        {
            session = session;
        }
        public Customer GetCustomer() => session.GetObject<Customer>(CustomerKey) ?? new Customer();

        public void SetCustomer(Customer customer) => session.SetObject(CustomerKey, customer);


    }

}
