using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Services.Utility;

namespace Taggl.Services.Gyms.Models
{
    public partial class GymCreate
    {
        private static void MappingsHook(IMappingExpression<GymCreate, Gym> mappingExpression)
        {
            var searchableNameFormatter = ServiceLocator.Current.GetRequiredService<ISearchableNameFormatter>();
            mappingExpression
                .ForMemberResolveUsing(dest => dest.Name, src => searchableNameFormatter.FormatName(src.Name))
                .ForMemberResolveUsing(dest => dest.NameNormalized, src => searchableNameFormatter.NormalizeName(src.Name));
        }
    }
}
