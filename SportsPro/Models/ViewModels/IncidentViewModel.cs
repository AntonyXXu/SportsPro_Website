using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentViewModel
    {
        public string[] FilterList = { "All", "Unassigned", "Open", "Closed" };

        public string Filter { get; set; }
        public IEnumerable<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = value;
            }
        }

        private IEnumerable<Incident> incidents;
    }
}
