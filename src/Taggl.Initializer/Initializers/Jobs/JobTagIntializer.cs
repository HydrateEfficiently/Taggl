using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Utility;
using Taggl.Initializer.Services.DataImportServices;
using Taggl.Services.Jobs;
using Taggl.Services.Jobs.Models;

namespace Taggl.Initializer.Initializers.Jobs
{
    public class JobTagIntializer : IDataInitializer
    {
        private readonly JsonDataImportService _jsonDataImportService;
        private readonly IJobTagService _jobTagService;

        public JobTagIntializer(
            JsonDataImportService jsonDataImportService,
            IJobTagService jobTagService)
        {
            _jsonDataImportService = jsonDataImportService;
            _jobTagService = jobTagService;
        }

        public void Run()
        {
            _jsonDataImportService.Deserialize<IEnumerable<string>>("job-tags")
                .Select(n => new JobTagCreate() { Name = n })
                .ForEach(j =>
                {
                    _jobTagService.CreateAsync(j).Wait();
                });
        }
    }
}
