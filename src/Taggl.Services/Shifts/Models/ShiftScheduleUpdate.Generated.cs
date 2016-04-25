using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;

namespace Taggl.Services.Shifts.Models {
    public partial class ShiftScheduleUpdate
    {
        private static MappingEngine __mappingEngine;

        static ShiftScheduleUpdate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<ShiftScheduleUpdate, ShiftSchedule>();
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public Guid ShiftTypeId { get; set; }
        
        //public ShiftTypeUpdate ShiftType { get; set; }
        
        public Guid GymId { get; set; }
        
        //public GymUpdate Gym { get; set; }
        
        public DateTime FromDate { get; set; }
        
        public TimeSpan Duration { get; set; }

        public ShiftSchedule Map()
        {
            return __mappingEngine.Map<ShiftScheduleUpdate, ShiftSchedule>(this);
        }
    }
}