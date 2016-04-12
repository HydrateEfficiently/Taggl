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
            configuration.CreateMap<PersonalInformationUpdate, PersonalInformation>();
            __mappingEngine = mappingEngine;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PersonalInformation Map(PersonalInformation personalInformation)
        {
            return __mappingEngine.Map(this, personalInformation);
        }
    }
}
