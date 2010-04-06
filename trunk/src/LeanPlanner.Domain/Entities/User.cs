using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeanPlanner.Domain.Entities
{
    public class User 
    {
        public User(string openIdIdentifier)
        {
            OpenIdIdentifier = openIdIdentifier;
        }

        public string OpenIdIdentifier { get; private set; }
    }
}
