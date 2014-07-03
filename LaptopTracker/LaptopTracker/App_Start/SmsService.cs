﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace LaptopTracker
{
    /// <summary>
    /// For handling SMS messages
    /// </summary>
    public class SmsService : IIdentityMessageService
    {
        /// <summary>
        /// This method should send the message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}