using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LaptopTracker.Data.Models;


namespace LaptopTracker.Models
{
    /// <summary>
    /// Manager Data that is consumed by Entity Framework
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Gets or sets the manager identifier.
        /// </summary>
        /// <value>
        /// The manager identifier.
        /// </value>
        public int ManagerId { get; set; }

        /// <summary>
        /// Database Id
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// This is the CompanyId
        /// Gets or sets the eid.
        /// </summary>
        /// <value>
        /// The eid.
        /// </value>
        public int EID { get; set; }

        /// <summary>
        /// Gets or sets the name of the manager.
        /// </summary>
        /// <value>
        /// The name of the manager.
        /// </value>
        [Required]
        public String ManagerName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        [Required]
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the laptops owned.
        /// </summary>
        /// <value>
        /// The laptops owned.
        /// </value>
        protected virtual List<Laptop> LaptopsOwned { get; set; }
    }

}