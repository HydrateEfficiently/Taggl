﻿using AutoMapper;
using AutoMapper.Mappers;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        private static MappingEngine __mappingEngine;

        static LoginViewModel()
        {
            var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var mappingEngine = new MappingEngine(configuration);
            configuration.CreateMap<LoginViewModel, LoginRequest>();
            __mappingEngine = mappingEngine;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public LoginRequest Map()
        {
            return __mappingEngine.Map<LoginViewModel, LoginRequest>(this);
        }
    }
}
