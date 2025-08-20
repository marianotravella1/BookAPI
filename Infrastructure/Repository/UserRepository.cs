using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookAPIContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            return !await _dbSet.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> IsEmailAvailableAsync(string email)
        {
            return !await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}
