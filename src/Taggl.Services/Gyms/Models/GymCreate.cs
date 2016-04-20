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
    public class GymCreate
    {
        private static MappingEngine __mappingEngine;

        static GymCreate()
        {
            var searchableNameFormatter = ServiceLocator.Current.GetRequiredService<ISearchableNameFormatter>();
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<GymCreate, Gym>()
                .ForMemberResolveUsing(dest => dest.Name, src => searchableNameFormatter.FormatName(src.Name))
                .ForMemberResolveUsing(dest => dest.NameNormalized, src => searchableNameFormatter.NormalizeName(src.Name));
            __mappingEngine = mappingEngine;
        }

        public string Name { get; set; }

        public Gym Map()
        {
            return __mappingEngine.Map<GymCreate, Gym>(this);
        }
    }
}
