using System;
using System.Collections.Generic;
namespace HrProject.Presentation.ViewModels
{
    public class VehicleLendListViewModel
    {
        public IEnumerable<VehicleLendListItem> VehicleLends { get; set; }
    }

    public class VehicleLendListItem
    {
        public string LenderUserName { get; set; }
        public string RecipientUserName { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
    }
}

