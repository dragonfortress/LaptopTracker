using System.ComponentModel.DataAnnotations;

namespace LaptopTracker.Models
{
    /// <summary>
    /// Forgot Password Data
    /// </summary>
    public class ForgotPasswordViewModel
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