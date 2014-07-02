﻿using System;
using System.Threading.Tasks;
using LaptopTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace LaptopTracker
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

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

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
