using LaptopTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LaptopTracker.Data.Models.EntityFramework
{
    /// <summary>
    /// Manages connection with EntityFramework and creates objects based on Model
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Gets or sets the managers.
        /// </summary>
        /// <value>
        /// The managers.
        /// </value>
        public System.Data.Entity.DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public System.Data.Entity.DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the laptops.
        /// </summary>
        /// <value>
        /// The laptops.
        /// </value>
        public System.Data.Entity.DbSet<Laptop> Laptops { get; set; }
    }
}