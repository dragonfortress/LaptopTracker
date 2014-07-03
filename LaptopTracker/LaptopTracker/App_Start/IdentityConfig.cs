﻿using System;
using System.Threading.Tasks;
using LaptopTracker.Data.Models.EntityFramework;
using LaptopTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace LaptopTracker
{
    /// <summary>
    /// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        /// <summary>
        /// Creates the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>());
            using (userStore)
            {
                using (var manager = new ApplicationUserManager(userStore))
                {

                    // Configure validation logic for usernames
                    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                    {
                        AllowOnlyAlphanumericUserNames = false,
                        RequireUniqueEmail = true
                    };
                    // Configure validation logic for passwords
                    manager.PasswordValidator = new PasswordValidator
                    {
                        RequiredLength = 6,
                        RequireNonLetterOrDigit = true,
                        RequireDigit = true,
                        RequireLowercase = true,
                        RequireUppercase = true,
                    };
                    // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                    // You can write your own provider and plug in here.
                    manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
                    {
                        MessageFormat = "Your security code is: {0}"
                    });
                    manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
                    {
                        Subject = "Security Code",
                        BodyFormat = "Your security code is: {0}"
                    });
                    manager.EmailService = new EmailService();
                    manager.SmsService = new SmsService();
                    if (options != null)
                    {
                        var dataProtectionProvider = options.DataProtectionProvider;
                        if (dataProtectionProvider != null)
                        {
                            manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                        }
                    }
                    return manager;
                }  
            }

        }
    }
}
