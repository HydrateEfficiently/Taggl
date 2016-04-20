using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Gyms.Mappings;
using Taggl.Services.Gyms.Models;

namespace Taggl.Services.Shifts.Models
{
    public class ShiftScheduleCreate
    {
        private static MappingEngine __mappingEngine;

        static ShiftScheduleCreate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ShiftScheduleCreate, ShiftSchedule>();
            __mappingEngine = mappingEngine;
        }
        
        public ShiftTypeCreate ShiftType { get; set; }
        
        public GymCreate Gym { get; set; }

        public DateTime FromDate { get; set; }

        public TimeSpan Duration { get; set; }

        public ShiftSchedule Map()
        {
            return __mappingEngine.Map<ShiftScheduleCreate, ShiftSchedule>(this);
        }
    }
}
