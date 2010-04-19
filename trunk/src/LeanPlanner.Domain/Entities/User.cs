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
            DisplayName = "Unknown";
        }

        public string OpenIdIdentifier { get; private set; }

        public string DisplayName { get; set; }
    }
}
