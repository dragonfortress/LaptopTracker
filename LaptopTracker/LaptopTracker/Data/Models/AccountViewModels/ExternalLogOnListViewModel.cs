using System;

namespace LaptopTracker.Models
{
    /// <summary>
    /// Logon Data
    /// </summary>
    public class ExternalLogOnListViewModel
    {
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public Uri ReturnUrl { get; set; }
    }
}