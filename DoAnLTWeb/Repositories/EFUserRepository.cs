using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly CsdlwebContext _context;


        public EFUserRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByUsernameAsync(string username) 
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }


        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdatePasswordAsync(string username, string newPassword)
        {
            var user = await FindByUsernameAsync(username);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                await UpdateAsync(user);
            }
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
