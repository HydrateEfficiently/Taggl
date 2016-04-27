using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity.Models;
using Taggl.Services.Identity.Queries;

namespace Taggl.Services.Identity
{
    public interface IUserService
    {
        Task<UserResult> GetAsync(string id);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserResult> GetAsync(string id)
        {
            return new UserResult(
                await _dbContext.UserRelationships.GetUserAsync(id));
        }
    }
}
