using Ums.Application.Interfaces.Repositories;
using Ums.Infrastructure.Persistence.Contexts;
using Ums.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Ums.Domain.Entities;

namespace Ums.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> users;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            users = dbContext.Set<User>();
        }

        public async Task<User> GetUserByEmailAsync(string email) 
            => await users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<bool> IsEmailExistAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null;
        }
    }
}