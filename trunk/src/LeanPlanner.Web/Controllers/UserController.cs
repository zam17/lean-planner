using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using LeanPlanner.Data;
using LeanPlanner.Domain.Commands;
using LeanPlanner.Domain.Entities;
using LeanPlanner.Web.Infrastructure.Avatar;
using LeanPlanner.Web.ViewModels;
using LeanPlanner.Web.ViewModels.User;

namespace LeanPlanner.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository _repository;
        private readonly IAvatarGenerator _avatarGenerator;

        public UserController(IRepository repository, IAvatarGenerator avatarGenerator)
        {
            _repository = repository;
            _avatarGenerator = avatarGenerator;
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

                        var command = Mapper.Map<string,EnsureUserCommand>(response.ClaimedIdentifier.OriginalString);
                        command.Execute();

                        FormsAuthentication.RedirectFromLoginPage(
                            response.ClaimedIdentifier.OriginalString, false);
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

        [ChildActionOnly]
        public ActionResult StatusWidget()
        {
            var user = _repository.All<User>().Single(x => x.OpenIdIdentifier == this.User.Identity.Name);

            var viewModel = new UserStatusViewModel();
            viewModel.DisplayName = user.DisplayName;
            viewModel.AvatarUrl = _avatarGenerator.GenerateUrl(user.OpenIdIdentifier);

            return PartialView(viewModel);
        }
    }
}
