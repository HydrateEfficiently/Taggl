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
            configuration.CreateMap<ApplicationUser, UserResult>()
                .ForMemberResolveUsing(
                    dest => dest.PersonalInformation,
                    src => new PersonalInformationResult(src.PersonalInformation));
            __mappingEngine = mappingEngine;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public PersonalInformationResult PersonalInformation { get; set; }

        public UserResult(ApplicationUser user)
        {
            __mappingEngine.Map(user, this);
        }
    }
}
