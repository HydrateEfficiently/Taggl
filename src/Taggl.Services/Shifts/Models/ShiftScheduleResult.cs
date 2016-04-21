using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Gyms.Mappings;
using Taggl.Services.Gyms.Models;
using Taggl.Services.Identity.Mappings;
using Taggl.Services.Identity.Models;
using Taggl.Services.Shifts.Mappings;

namespace Taggl.Services.Shifts.Models {
    public class ShiftScheduleResult
    {
        private static MappingEngine __mappingEngine;

        static ShiftScheduleResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ShiftSchedule, ShiftScheduleResult>()
                .ForShiftType(dest => dest.ShiftType, src => src.ShiftType)
                .ForGym(dest => dest.Gym, src => src.Gym)
                .ForUser(dest => dest.CreatedBy, src => src.CreatedBy)
                .ForUser(dest => dest.UpdatedBy, src => src.UpdatedBy)
                .ForUser(dest => dest.DeletedBy, src => src.DeletedBy);
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public Guid ShiftTypeId { get; set; }
        
        public ShiftTypeResult ShiftType { get; set; }
        
        public Guid GymId { get; set; }
        
        public GymResult Gym { get; set; }
        
        public DateTime FromDate { get; set; }
        
        public TimeSpan Duration { get; set; }
        
        public DateTime Created { get; set; }
        
        public string CreatedById { get; set; }
        
        public UserResult CreatedBy { get; set; }
        
        public DateTime Updated { get; set; }
        
        public string UpdatedById { get; set; }
        
        public UserResult UpdatedBy { get; set; }
        
        public DateTime? Deleted { get; set; }
        
        public string DeletedById { get; set; }
        
        public UserResult DeletedBy { get; set; }

        public ShiftScheduleResult(ShiftSchedule shiftSchedule)
        {
            __mappingEngine.Map(shiftSchedule, this);
        }
    }
}

