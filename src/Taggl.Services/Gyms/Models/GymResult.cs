using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;

namespace Taggl.Services.Gyms.Models {
    public partial class GymResult
    {
        private static void MappingsHook(IMappingExpression<Gym, GymResult> mappingExpression)
        {
        }
    }
}

