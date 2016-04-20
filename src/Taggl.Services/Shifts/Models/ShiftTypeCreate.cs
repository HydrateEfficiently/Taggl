using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Utility;
using Taggl.Services.Utility;

namespace Taggl.Services.Shifts.Models
{
    public class ShiftTypeCreate
    {
        private static MappingEngine __mappingEngine;

        static ShiftTypeCreate()
        {
            var shiftTypeFormatter = ServiceLocator.Current.GetRequiredService<ISearchableNameFormatter>();
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ShiftTypeCreate, ShiftType>()
                .ForMemberResolveUsing(dest => dest.Name, src => shiftTypeFormatter.FormatName(src.Name))
                .ForMemberResolveUsing(dest => dest.NameNormalized, src => shiftTypeFormatter.NormalizeName(src.Name));
            __mappingEngine = mappingEngine;
        }

        public string Name { get; set; }

        public ShiftType Map()
        {
            return __mappingEngine.Map<ShiftTypeCreate, ShiftType>(this);
        }
    }
}
