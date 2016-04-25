using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Utility;
using Taggl.Services.Utility;

namespace Taggl.Services.Shifts.Models
{
    public partial class ShiftTypeCreate
    {
        private const int NumberOfColors = 10;
        private static readonly Random RandomColorPicker = new Random();

        private static void MappingsHook(IMappingExpression<ShiftTypeCreate, ShiftType> mappingExpression)
        {
            var shiftTypeFormatter = ServiceLocator.Current.GetRequiredService<ISearchableNameFormatter>();
            mappingExpression
                .ForMemberResolveUsing(dest => dest.Name, src => shiftTypeFormatter.FormatName(src.Name))
                .ForMemberResolveUsing(dest => dest.NameNormalized, src => shiftTypeFormatter.NormalizeName(src.Name))
                .ForMemberResolveUsing(dest => dest.ColorSwitch, src => GetColor(src));
        }

        private static int GetColor(ShiftTypeCreate create)
        {
            if (create.ColorSwitch > 0 && create.ColorSwitch <= NumberOfColors)
            {
                return create.ColorSwitch;
            }
            return RandomColorPicker.Next(NumberOfColors);
        }
    }
}
