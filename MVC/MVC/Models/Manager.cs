using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        public int EmployeeId { get; set; }     //WorkerId

        //Worker Id
        public int EID { get; set; }

        [Required]
        public String ManagerName { get; set; }

        public String EmailAddress { get; set; }

        [Required]
        public Roles Role { get; set; }

        public virtual List<Laptop> LaptopsOwned { get; set; }
    }

}