using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentAddEditViewModel
    {
        public IEnumerable<Customer> customers { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Technician> technicians { get; set; }
        public string operation { get; set; }
        public Incident currentIncident { get; set; }
    }
}
