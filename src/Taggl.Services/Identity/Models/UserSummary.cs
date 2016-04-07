using AutoMapper;
using AutoMapper.Mappers;
using Taggl.Framework.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Services.Identity.Models
{
    public class UserSummary
    {
        private static MappingEngine __mappingEngine;

        static UserSummary()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ApplicationUser, UserSummary>();
            __mappingEngine = mappingEngine;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public UserSummary(ApplicationUser user)
        {
            __mappingEngine.Map(user, this);
        }
    }
}
