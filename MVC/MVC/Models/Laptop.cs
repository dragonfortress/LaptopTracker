using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Laptop
    {
        public int LaptopId { get; set; }

        public int LID { get; set; }

        public String Name { get; set; }

        [Required]
        public DeviceTypes Type { get; set; } //may be extraneous

        public string Description { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Owner { get; set; }
    }

    public enum DeviceTypes
    {
        Monitor,
        Computer,
        Cellphone,
        Wearable,
        Adapter,
        DockingStation,
        PowerCable
    }
}