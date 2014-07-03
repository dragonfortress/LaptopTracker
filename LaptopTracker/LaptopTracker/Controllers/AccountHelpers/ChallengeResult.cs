using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace LaptopTracker.Controllers
{
    /// <summary>
    /// Challenge based Security
    /// </summary>
    public class ChallengeResult : HttpUnauthorizedResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengeResult"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengeResult"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="userId">The user identifier.</param>
        public ChallengeResult(string provider, string redirectUri, string userId)
        {
            LogOnProvider = provider;
            RedirectUri = redirectUri;
            UserId = userId;
        }

        private string LogOnProvider { get; set; }
        private string RedirectUri { get; set; }
        private string UserId { get; set; }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            //validate context
            if (context != null)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[AccountController.XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LogOnProvider); 
            }
        }
    }
}