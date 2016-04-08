using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Utility;
using Taggl.Initializer.Services.DataImportServices;
using Taggl.Services.Administrator;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Models;

namespace Taggl.Initializer.Initializers.Identity
{
    public class AdministratorsInitializer : IDataInitializer
    {
        private readonly JsonDataImportService _jsonDataImportService;
        private readonly IRegistrationService _registrationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdministrationService _administrationService;

        public AdministratorsInitializer(
            JsonDataImportService jsonDataImportService,
            IRegistrationService registrationService,
            UserManager<ApplicationUser> userManager,
            IAdministrationService administrationService)
        {
            _jsonDataImportService = jsonDataImportService;
            _registrationService = registrationService;
            _userManager = userManager;
            _administrationService = administrationService;
        }

        public void Run()
        {
            _jsonDataImportService.Deserialize<IEnumerable<RegistrationRequest>>("administrators")
                .ForEach(r =>
                {
                    var user = _registrationService.RegisterAsync(r).Result;
                    var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                    _registrationService.ConfirmEmailAsync(user.Id, token);
                    _administrationService.ApproveUserAsync(user.Id);
                    _userManager.AddToRoleAsync(user, ApplicationRoles.Administrator);
                });
        }
    }
}
