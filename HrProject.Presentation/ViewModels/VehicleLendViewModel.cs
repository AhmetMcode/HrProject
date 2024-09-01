using System;
using System.Collections.Generic;
using HrProject.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrProject.Presentation.ViewModels
{
    public class VehicleLendViewModel
    {
        public int VehicleId { get; set; }

        public string? ApplicationUserId { get; set; } // User receiving the vehicle
        public int? PersonId { get; set; } // Person receiving the vehicle


        public DateTime LendDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; } // Optional return date
        public string? Notes { get; set; } // Optional notes

        public IEnumerable<SelectListItem> Vehicles { get; set; }
        public IEnumerable<SelectListItem> ApplicationUsers { get; set; }
        public IEnumerable<SelectListItem> Persons { get; set; }
    }
}
