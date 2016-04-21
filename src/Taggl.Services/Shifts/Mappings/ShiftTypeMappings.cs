using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Shifts.Models;

namespace Taggl.Services.Shifts.Mappings
{
    public static class ShiftTypeMappings
    {
        public static IMappingExpression<TSource, TDestination> ForShiftType<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> self,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, ShiftType> source)
        {
            return self.ForMember(
                destinationMember,
                options => options.MapFrom(src =>
                    source(src) == null ? null : new ShiftTypeResult(source(src))
                ));
        }
    }
}
