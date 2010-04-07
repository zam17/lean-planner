using LeanPlanner.Data;
using StructureMap.Configuration.DSL;

namespace LeanPlanner.Web.Infrastructure
{
    public class LeanPlannerRegistry : Registry
    {
        public LeanPlannerRegistry()
        {
            ForSingletonOf<SessionSource>().Use(new SessionSource());
            For<IRepository>().Use(ctx=>ctx.GetInstance<SessionSource>().CreateSession());
        }
    }
}
