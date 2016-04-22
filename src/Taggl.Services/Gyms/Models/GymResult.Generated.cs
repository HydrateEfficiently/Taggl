using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Services.Identity.Models;
using Taggl.Services.Identity.Mappings;

namespace Taggl.Services.Gyms.Models {
    public partial class GymResult
    {
        private static MappingEngine __mappingEngine;

        static GymResult()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            var mappingExpression = configuration.CreateMap<Gym, GymResult>();
            mappingExpression.ForUser(dest => dest.CreatedBy, src => src.CreatedBy);
            mappingExpression.ForUser(dest => dest.UpdatedBy, src => src.UpdatedBy);
            mappingExpression.ForUser(dest => dest.DeletedBy, src => src.DeletedBy);
            MappingsHook(mappingExpression);
            __mappingEngine = mappingEngine;
        }
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string NameNormalized { get; set; }
        
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