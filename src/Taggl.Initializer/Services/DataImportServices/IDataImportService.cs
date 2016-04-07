using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Initializer.Services.DataImportServices
{
    public interface IDataImportService
    {
        T Deserialize<T>(string fileName);
    }
}
