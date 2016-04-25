using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;

namespace Taggl.Services.Shifts.Models {
    public partial class ShiftTypeCreate
    {
        private static MappingEngine __mappingEngine;

        static ShiftTypeCreate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<ShiftTypeCreate, ShiftType>();
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int ColorSwitch { get; set; }

        public ShiftType Map()
        {
            return __mappingEngine.Map<ShiftTypeCreate, ShiftType>(this);
        }
    }
}