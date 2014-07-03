using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LaptopTracker.Data.Models;
using LaptopTracker.Data.Models.EntityFramework;
using LaptopTracker.Utilities;


namespace LaptopTracker.Models
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        //Employee Id
        /// <summary>
        /// Gets or sets the eid.
        /// </summary>
        /// <value>
        /// The eid.
        /// </value>
        public int EID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        [Required]
        public String EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        [Required]
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the manager identifier.
        /// </summary>
        /// <value>
        /// The manager identifier.
        /// </value>
        public int ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        /// <value>
        /// The manager.
        /// </value>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Gets or sets the laptops owned.
        /// </summary>
        /// <value>
        /// The laptops owned.
        /// </value>
        protected virtual List<Laptop> LaptopsOwned { get; set; }

        /// <summary>
        /// The count
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Gets the laptop count.
        /// </summary>
        /// <value>
        /// The laptop count.
        /// </value>
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
}