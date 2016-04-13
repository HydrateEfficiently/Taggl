using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Professionalities;
using Taggl.Services.Jobs.Models;
using Taggl.Services.Utility;

namespace Taggl.Services.Professionalities.Models
{
    public class ProfessionalityResult
    {
        private static MappingEngine __mappingEngine;

        static ProfessionalityResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<Professionality, ProfessionalityResult>()
                .ForMemberResolveUsing(dest => dest.Expertise, src => src.Expertise.Select(e => new ExpertiseResult(e)));
            __mappingEngine = mappingEngine;
        }

        public string Id { get; set; }

        public IEnumerable<ExpertiseResult> Expertise { get; set; }
            = Enumerable.Empty<ExpertiseResult>();

        public ProfessionalityResult(Professionality professionality)
        {
            __mappingEngine.Map(professionality, this);
        }
    }
}
