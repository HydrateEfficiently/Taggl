using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;

namespace Taggl.Services.Shifts.Models
{
    public class ShiftTypeResult
    {
        private static MappingEngine __mappingEngine;

        static ShiftTypeResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ShiftType, ShiftTypeResult>();
            __mappingEngine = mappingEngine;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameNormalized { get; set; }

        public ShiftTypeResult(ShiftType shiftType)
        {
            __mappingEngine.Map(shiftType, this);
        }
    }
}
