using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Services.Gyms.Models;

namespace Taggl.Services.Gyms.Mappings
{
    public static class GymMappings
    {
        public static IMappingExpression<TSource, TDestination> ForGym<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> self,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, Gym> source)
        {
            return self.ForMember(
                destinationMember,
                options => options.MapFrom(src =>
                    source(src) == null ? null : new GymResult(source(src))
                ));
        }

        public static IMappingExpression<TSource, TDestination> ToGymEntity<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> self,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, GymCreate> source)
        {
            return self.ForMember(
                destinationMember,
                options => options.MapFrom(src =>
                    source(src) == null ? null : source(src).Map()
                ));
        }
    }
}
