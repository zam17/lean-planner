using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanPlanner.Web.Infrastructure.Avatar
{
    public interface IAvatarGenerator
    {
        string GenerateUrl(string email);
    }
}
