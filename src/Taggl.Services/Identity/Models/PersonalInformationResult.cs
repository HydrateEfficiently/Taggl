using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Services.Identity.Models
{
    public class PersonalInformationResult
    {
        private static MappingEngine __mappingEngine;

        static PersonalInformationResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<PersonalInformation, PersonalInformationResult>();
            __mappingEngine = mappingEngine;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PersonalInformationResult(PersonalInformation personalInformation)
        {
            __mappingEngine.Map(personalInformation, this);
        }
    }
}
