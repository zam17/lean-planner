using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanPlanner.Data;
using LeanPlanner.Domain.Entities;

namespace LeanPlanner.Domain.Commands
{
    public class EnsureUserCommand : Command
    {
        public EnsureUserCommand(IRepository repository) : base(repository)
        {
        }

        protected override void DoWork()
        {
            var user = Repository.All<User>().SingleOrDefault(u => u.OpenIdIdentifier == OpenIdIdentifier);

            if (user == null)
            {
                user = new User(OpenIdIdentifier);
                Repository.Save(user);
            }
        }

        public string OpenIdIdentifier { get; set; }
    }
}
