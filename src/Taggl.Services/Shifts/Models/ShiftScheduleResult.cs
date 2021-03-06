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
using Taggl.Services.Utility;

namespace Taggl.Services.Shifts.Models {
    public partial class ShiftScheduleResult
    {
        private static void MappingsHook(IMappingExpression<ShiftSchedule, ShiftScheduleResult> mappingExpression)
        {
            mappingExpression
                .ForMemberResolveUsing(dest => dest.DurationMinutes, src => src.Duration.TotalMinutes);
        }

        public int DurationMinutes { get; set; }
    }
}

