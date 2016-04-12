using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;

namespace Taggl.Services.Jobs.Models
{
    public class JobTagResult
    {

        private static MappingEngine __mappingEngine;

        static JobTagResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<JobTagResult, JobTag>();
            __mappingEngine = mappingEngine;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public int UsageCount { get; set; }

        public JobTagResult(JobTag jobTag)
        {
            __mappingEngine.Map(jobTag, this);
        }
    }
}
