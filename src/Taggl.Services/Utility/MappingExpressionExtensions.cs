using AutoMapper;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Taggl.Services.Utility
{
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDestination> ForMemberResolveUsing<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpr,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, object> resolver)
        {
            return mappingExpr.ForMember(destinationMember, opts => opts.ResolveUsing(resolver));
        }

        public static IMappingExpression<TSource, TDestination> ForMemberIgnore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpr,
            Expression<Func<TDestination, object>> destinationMember)
        {
            return mappingExpr.ForMember(destinationMember, opts => opts.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> ForUserMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> self,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, ApplicationUser> source)
        {
            return self.ForMember(
                destinationMember,
                options => options.MapFrom(src =>
                    source(src) == null ? null : new UserSummary(source(src))
                ));
        }
    }
}
