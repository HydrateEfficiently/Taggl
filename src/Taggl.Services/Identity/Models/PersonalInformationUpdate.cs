using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Services.Identity.Models
{
    public class PersonalInformationUpdate
    {

        private static MappingEngine __mappingEngine;

        static PersonalInformationUpdate()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<PersonalInformationUpdate, ApplicationUser>();
            __mappingEngine = mappingEngine;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ApplicationUser Map(ApplicationUser user)
        {
            return __mappingEngine.Map(this, user);
        }
    }
}
