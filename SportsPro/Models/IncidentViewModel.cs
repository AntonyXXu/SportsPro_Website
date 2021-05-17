using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentViewModel
    {
        public string Filter { get; set; }
        public List<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = value;
            }
        }


        private List<Incident> incidents;
    }
}
