using System.ComponentModel.DataAnnotations;

namespace LaptopTracker.Models
{
    /// <summary>
    /// Logon Confirmation
    /// </summary>
    public class ExternalLogOnConfirmationViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}