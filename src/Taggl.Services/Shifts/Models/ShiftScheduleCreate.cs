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
    public partial class ShiftScheduleCreate
    {
        private static void MappingsHook(IMappingExpression<ShiftScheduleCreate, ShiftSchedule> mappingExpression)
        {
            mappingExpression
                .ForMemberResolveUsing(dest => dest.Duration, src => new TimeSpan(0, src.DurationMinutes, 0));
        }

        public string GymName { get; set; }

        public string ShiftTypeName { get; set; }

        public int DurationMinutes { get; set; }
    }
}
