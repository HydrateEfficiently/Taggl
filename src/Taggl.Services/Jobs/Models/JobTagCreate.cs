using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;
using Taggl.Framework.Utility;
using Taggl.Services.Utility;

namespace Taggl.Services.Jobs.Models
{
    public class JobTagCreate
    {
        private static MappingEngine __mappingEngine;

        static JobTagCreate()
        {
            var jobTagFormatter = ServiceLocator.Current.GetRequiredService<IJobTagFormatter>();
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<JobTagCreate, JobTag>()
                .ForMemberResolveUsing(dest => dest.Name, src => jobTagFormatter.FormatName(src.Name))
                .ForMemberResolveUsing(dest => dest.NameNormalized, src => jobTagFormatter.NormalizeName(src.Name));
            __mappingEngine = mappingEngine;
        }

        public string Name { get; set; }

        public JobTag Map()
        {
            return __mappingEngine.Map<JobTagCreate, JobTag>(this);
        }
    }
}
