using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity.Models;

namespace Taggl.Services.Identity
{
    public interface IAccountService
    {
        Task<UserResult> UpdatePersonalInformationAsync(PersonalInformationUpdate update);
    }

    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountService(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserResult> UpdatePersonalInformationAsync(PersonalInformationUpdate update)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == update.Id);
            update.Map(user);
            await _dbContext.SaveChangesAsync();
            return new UserResult(user);
        }
    }
}
