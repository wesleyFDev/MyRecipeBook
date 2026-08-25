using Microsoft.EntityFrameworkCore;
using MyRecipeBook.domain.Entities;
using MyRecipeBook.domain.Repositories.User;

namespace MyRecipeBook.infrastructure.DataAccess.Repositories
{
    internal sealed class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;
        public UserRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {

         return await _dbContext.Users.AnyAsync(user => user.Email == email && user.IsActive);

        }
    }
}
