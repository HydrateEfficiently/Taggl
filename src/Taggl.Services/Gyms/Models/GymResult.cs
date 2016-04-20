using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Services.Identity.Models;

namespace Taggl.Services.Gyms.Models {
    public class GymResult
    {
        private static MappingEngine __mappingEngine;

        static GymResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<Gym, GymResult>();
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string NameNormalized { get; set; }
        
        public bool IsSearchable { get; set; }
        
        public DateTime Created { get; set; }
        
        public string CreatedById { get; set; }
        
        public UserResult CreatedBy { get; set; }
        
        public DateTime Updated { get; set; }
        
        public string UpdatedById { get; set; }
        
        public UserResult UpdatedBy { get; set; }
        
        public DateTime? Deleted { get; set; }
        
        public string DeletedById { get; set; }
        
        public UserResult DeletedBy { get; set; }

        public GymResult(Gym gym)
        {
            __mappingEngine.Map(gym, this);
        }
    }
}

