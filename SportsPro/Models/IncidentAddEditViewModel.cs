using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentAddEditViewModel
    {
        public List<Customer> customers { get; set; }
        public List<Product> products { get; set; }
        public List<Technician> technicians { get; set; }
        public string operation { get; set; }
        public Incident currentIncident { get; set; }
    }
}
