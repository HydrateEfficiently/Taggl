using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Identity.Models;
using Taggl.Services.Identity.Mappings;

namespace Taggl.Services.Shifts.Models {
    public partial class ShiftTypeResult
    {
        private static MappingEngine __mappingEngine;

        static ShiftTypeResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<ShiftType, ShiftTypeResult>();
            mappingExpression.ForUser(dest => dest.CreatedBy, src => src.CreatedBy);
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string NameNormalized { get; set; }
        
        public bool IsSearchable { get; set; }
        
        public int ColorSwitch { get; set; }
        
        public DateTime Created { get; set; }
        
        public string CreatedById { get; set; }
        
        public UserResult CreatedBy { get; set; }

        public ShiftTypeResult(ShiftType shiftType)
        {
            __mappingEngine.Map(shiftType, this);
        }
    }
}