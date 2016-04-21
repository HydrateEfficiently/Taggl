using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity.Models;

namespace Taggl.Services.Identity.Mappings
{
    public static class UserMappings
    {
        public static IMappingExpression<TSource, TDestination> ForUser<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> self,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, ApplicationUser> source)
        {
            return self.ForMember(
                destinationMember,
                options => options.MapFrom(src =>
                    source(src) == null ? null : new UserResult(source(src))
                ));
        }
    }
}
