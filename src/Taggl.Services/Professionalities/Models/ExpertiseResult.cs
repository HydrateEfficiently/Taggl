using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Professionalities;

namespace Taggl.Services.Professionalities.Models
{
    public class ExpertiseResult
    {
        private static MappingEngine __mappingEngine;

        static ExpertiseResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ProfessionalExpertise, ExpertiseResult>();
            __mappingEngine = mappingEngine;
        }

        public Guid Id { get; set; }

        public Guid JobTagId { get; set; }

        public string JobTagName { get; set; }

        public string JobTagNameNormalized { get; set; }

        public ExpertiseResult(ProfessionalExpertise exepertise)
        {
            __mappingEngine.Map(exepertise, this);
        }
    }
}
