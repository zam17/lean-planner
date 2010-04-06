using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanPlanner.Data;
using LeanPlanner.Domain.Entities;

namespace LeanPlanner.Domain.Commands
{
    public class EnsureUserCommand : Command<User>
    {
        public EnsureUserCommand(IRepository repository) : base(repository)
        {
        }

        protected override User DoWork()
        {
            var user = Repository.All<User>().SingleOrDefault(u => u.OpenIdIdentifier == OpenIdIdentifierOriginalString);

            if (user == null)
            {
                user = new User(OpenIdIdentifierOriginalString);
                Repository.Save(user);
            }

            return user;
        }

        public string OpenIdIdentifierOriginalString { get; set; }
    }
}
