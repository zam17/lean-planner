using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LeanPlanner.Domain.Commands;
using StructureMap;

namespace LeanPlanner.Web.Infrastructure
{
    public static class AutoMapperBootstrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<string, EnsureUserCommand>()
                .ForMember(x => x.OpenIdIdentifier, opt => opt.MapFrom(src => src))
                .ConstructUsing(x => ObjectFactory.GetInstance<EnsureUserCommand>());
        }
    }
}
