using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models.ViewModels
{
    public class TechniciansViewModel
    {
        public List <Technician> Technicians { get; set; }

        [Required(ErrorMessage = "Please select a technician")]
        public int TechnicianID { get; set; }
    }
}
