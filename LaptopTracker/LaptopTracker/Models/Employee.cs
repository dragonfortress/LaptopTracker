using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LaptopTracker.Utilities;


namespace LaptopTracker.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        //Employee Id
        public int CompanyId { get; set; }

        [Required]
        public String EmployeeName { get; set; }

        [Required]
        public Role Role { get; set; }

        public String EmailAddress { get; set; }

        public int ManagerId { get; set; }

        public virtual Manager Manager { get; set; }

        protected virtual List<Laptop> LaptopsOwned { get; set; }

        private int count = 0;

        public int LaptopCount
        {
            get
            {

                using (var db = new ApplicationDbContext())
                {
                    count = db.Laptops.Where(a => a.EmployeeId != null).Count(a => a.EmployeeId == EmployeeId);
                    if (count > 1)
                    {
                        string managerEmail = db.Managers.Where(a => a.ManagerId != null).Where(a => a.ManagerId == ManagerId).FirstOrDefault().EmailAddress;
                        SendEmail.SendMail(EmailAddress, managerEmail);
                    }
                    return count; 
                }
                
            }
        }
    }

    public enum Role
    {
        ItAdmin,
        Employee,
        Manager
    }
}