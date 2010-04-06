using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using LeanPlanner.Data;
using LeanPlanner.Domain.Entities;
using LeanPlanner.Web.ViewModels;

namespace LeanPlanner.Web.Controllers
{
    public class UserController : Controller
    {
        private IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult LogOn()
        {
            var openid = new OpenIdRelyingParty();
            var response = openid.GetResponse();

            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var user = EnsureUser(response.ClaimedIdentifier, response.GetExtension<ClaimsResponse>());
                        FormsAuthentication.RedirectFromLoginPage(
                            user.OpenIdIdentifier, false);
                        break;
                    case AuthenticationStatus.Canceled:
                        ModelState.AddModelError("OpenIdIdentifier",
                            "Login was cancelled at the provider");
                        break;
                    case AuthenticationStatus.Failed:
                        ModelState.AddModelError("OpenIdIdentifier",
                            "Login failed using the provided OpenID identifier");
                        break;
                }
            }

            return View();
        }

        private User EnsureUser(Identifier claimedIdentifier, ClaimsResponse getExtension)
        {
            
        }

        [HttpPost]
        public ActionResult LogOn(LogOnInputModel model)
        {
            if (!Identifier.IsValid(model.OpenIdIdentifier))
            {
                ModelState.AddModelError("OpenIdIdentifier", "Invalid identifier");
                return View(model);
            }
            else
            {
                var openid = new OpenIdRelyingParty();
                var request = openid.CreateRequest(
                    Identifier.Parse(model.OpenIdIdentifier));

                request.AddExtension(new ClaimsRequest 
                {
                    Email = DemandLevel.Request,
                    FullName = DemandLevel.Request
                });

                return request.RedirectingResponse.AsActionResult();
            }
        }
    }
}
