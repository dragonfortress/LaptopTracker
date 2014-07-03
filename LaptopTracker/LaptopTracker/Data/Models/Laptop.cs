using System;
using System.ComponentModel.DataAnnotations;
using LaptopTracker.Models;

namespace LaptopTracker.Data.Models
{
    /// <summary>
    /// Data Types for Laptops
    /// </summary>
    public class Laptop
    {
        /// <summary>
        /// Gets or sets the laptop identifier.
        /// </summary>
        /// <value>
        /// The laptop identifier.
        /// </value>
        public int LaptopId { get; set; }

        /// <summary>
        /// Gets or sets the lid.
        /// </summary>
        /// <value>
        /// The lid.
        /// </value>
        public int Lid { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Required]
        public DeviceType Type { get; set; } //may be extraneous

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public virtual Employee Owner { get; set; }
    }
} 