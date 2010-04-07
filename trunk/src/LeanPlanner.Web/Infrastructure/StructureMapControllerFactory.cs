using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace LeanPlanner.Web.Infrastructure
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
