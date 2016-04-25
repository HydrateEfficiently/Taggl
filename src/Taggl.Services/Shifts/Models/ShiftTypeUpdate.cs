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
        private static void MappingsHook(IMappingExpression<ShiftTypeUpdate, ShiftType> mappingExpression)
        {
        }
    }
}
