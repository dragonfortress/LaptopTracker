using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace LaptopTracker.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        //Database Id
        public int EmployeeId { get; set; }

        //Suppress warning for spelling. This is spelled correctly. I could have spelled this one: "EID and the other one EmployeeTableId"
        public int EID { get; set; }

        [Required]
        public String ManagerName { get; set; }

        public String EmailAddress { get; set; }

        [Required]
        public Role Role { get; set; }

        protected virtual List<Laptop> LaptopsOwned { get; set; }
    }

}