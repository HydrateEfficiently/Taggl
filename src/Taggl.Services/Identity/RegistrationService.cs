using Microsoft.AspNet.Identity;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Services;
using Taggl.Services.Identity.Exceptions;
using Taggl.Services.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Taggl.Framework.Utility;
using Taggl.Framework.Models.Professionals;

namespace Taggl.Services.Identity
{
    public interface IRegistrationService
    {
        Task<ApplicationUser> RegisterAsync(RegistrationRequest request);

        Task SendConfirmationEmailAsync(string userId);

        Task ConfirmEmailAsync(string userId, string code);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUrlResolver _urlResolver;
        private readonly IEmailService _emailService;
        private readonly IIdentityResolver _identityResolver;

        public RegistrationService(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IUrlResolver urlResolver,
            IEmailService emailService,
            IIdentityResolver identityResolver)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _urlResolver = urlResolver;
            _emailService = emailService;
            _identityResolver = identityResolver;
        }

        public async Task<ApplicationUser> RegisterAsync(RegistrationRequest request)
        {
            var user = request.ToApplicationUser();

            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                throw new IdentityErrorException(createResult);
            }

            await SendConfirmationEmail(user);

            return user;
        }

        public async Task ConfirmEmailAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new ArgumentNullException(nameof(userId), nameof(code));
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException($"Could not find user with id {userId}");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new EmailConfirmationFailedException();
            }

            var userRelationships = new ApplicationUserRelationships()
            {
                UserId = user.Id,
                Status = new ApplicationUserStatus(),
                Professional = new Professional()
            };
            _dbContext.UserRelationships.Add(userRelationships);
            _dbContext.UserStatuses.Add(userRelationships.Status);
            _dbContext.Professionals.Add(userRelationships.Professional);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SendConfirmationEmailAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await SendConfirmationEmail(user);
        }

        #region Helpers

        private async Task SendConfirmationEmail(ApplicationUser user)
        {
            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string emailConfirmationUrl = _urlResolver.ResolveConfirmationEmailUrl(user.Id, emailConfirmationToken);
            await _emailService.SendEmailAsync(
                user.Email,
                "Confirm your account with OutSpoken",
                $"Please confirm your account by clicking this link: <a href='{emailConfirmationUrl}'>link</a>");
        }

        #endregion
    }
}
