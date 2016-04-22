using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;

namespace Taggl.Services.Gyms.Models
{
    public partial class GymCreate
    {
        private static MappingEngine __mappingEngine;

        static GymCreate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<GymCreate, Gym>();
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }

        public string Name { get; set; }

        public Gym Map()
        {
            return __mappingEngine.Map<GymCreate, Gym>(this);
        }
    }
}
