using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Gyms.Mappings;
using Taggl.Services.Gyms.Models;
using Taggl.Services.Utility;

namespace Taggl.Services.Shifts.Models
{
    public class ShiftScheduleCreate
    {
        private static MappingEngine __mappingEngine;

        static ShiftScheduleCreate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ShiftScheduleCreate, ShiftSchedule>()
                .ForMemberResolveUsing(dest => dest.Duration, src => new TimeSpan(0, src.DurationMinutes, 0));
            __mappingEngine = mappingEngine;
        }

        public Guid ShiftTypeId { get; set; }
        
        public string ShiftTypeName { get; set; }

        public Guid GymId { get; set; }

        public string GymName { get; set; }

        public DateTime FromDate { get; set; }

        public int DurationMinutes { get; set; }

        public ShiftSchedule Map()
        {
            return __mappingEngine.Map<ShiftScheduleCreate, ShiftSchedule>(this);
        }
    }
}
