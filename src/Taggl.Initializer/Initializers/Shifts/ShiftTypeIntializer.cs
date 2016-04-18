using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Utility;
using Taggl.Initializer.Services.DataImportServices;
using Taggl.Services.Shifts;
using Taggl.Services.Shifts.Models;

namespace Taggl.Initializer.Initializers.Shifts
{
    public class ShiftTypeInitializer : IDataInitializer
    {
        private readonly JsonDataImportService _jsonDataImportService;
        private readonly IShiftTypeService _shiftTypeService;

        public ShiftTypeInitializer(
            JsonDataImportService jsonDataImportService,
            IShiftTypeService shiftTypeService)
        {
            _jsonDataImportService = jsonDataImportService;
            _shiftTypeService = shiftTypeService;
        }

        public void Run()
        {
            _jsonDataImportService.Deserialize<IEnumerable<string>>("shift-types")
                .Select(n => new ShiftTypeCreate() { Name = n })
                .ForEach(s =>
                {
                    //_shiftTypeService.CreateAsync(s).Wait();
                });
        }
    }
}
