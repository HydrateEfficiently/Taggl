using AutoMapper;
using AutoMapper.Mappers;
using Taggl.Framework.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Utility;

namespace Taggl.Services.Identity.Models
{
    public class UserResult
    {
        private static MappingEngine __mappingEngine;

        static UserResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<ApplicationUser, UserResult>();
            __mappingEngine = mappingEngine;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserResult(ApplicationUser user)
        {
            __mappingEngine.Map(user, this);
        }
    }
}
