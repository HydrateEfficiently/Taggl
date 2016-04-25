using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Gyms.Models;

namespace Taggl.Services.Shifts.Models {
    public partial class ShiftScheduleCreate
    {
        private static MappingEngine __mappingEngine;

        static ShiftScheduleCreate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<ShiftScheduleCreate, ShiftSchedule>();
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }
        
        public Guid ShiftTypeId { get; set; }
        
        public ShiftTypeCreate ShiftType { get; set; }
        
        public Guid GymId { get; set; }
        
        public GymCreate Gym { get; set; }
        
        public DateTime FromDate { get; set; }

        public ShiftSchedule Map()
        {
            return __mappingEngine.Map<ShiftScheduleCreate, ShiftSchedule>(this);
        }
    }
}