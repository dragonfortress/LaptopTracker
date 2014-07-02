using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace LaptopTracker.Models
{
    public class Laptop
    {
        public int LaptopId { get; set; }

        public int Lid { get; set; }

        public String Name { get; set; }

        [Required]
        public DeviceType Kind { get; set; } //may be extraneous

        public string Description { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Owner { get; set; }
    }

    public enum DeviceType
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