using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;

namespace Taggl.Services.Shifts.Models {
    public partial class ShiftTypeUpdate
    {
        private static MappingEngine __mappingEngine;

        static ShiftTypeUpdate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<ShiftTypeUpdate, ShiftType>();
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public bool IsSearchable { get; set; }
        
        public int ColorSwitch { get; set; }

        public ShiftType Map()
        {
            return __mappingEngine.Map<ShiftTypeUpdate, ShiftType>(this);
        }
    }
}