using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Initializer.Initializers;

namespace Taggl.Initializer
{
    public static class InitializerRepository
    {
        private static readonly List<Type> __initializers = new List<Type>();

        public static void AddInitializer<TInitializer>(
            this IServiceCollection services)
            where TInitializer : IDataInitializer
        {
            Type initializerType = typeof(TInitializer);
            services.AddTransient(initializerType);
            __initializers.Add(initializerType);
        }

        public static IEnumerable<Type> GetInitializers()
        {
            return __initializers.ConvertAll(t => t);
        }
    }
}
