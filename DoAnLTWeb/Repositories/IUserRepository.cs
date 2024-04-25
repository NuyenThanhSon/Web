using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> FindByUsernameAsync(string username);
        Task<User> FindByEmailAsync(string email);
        Task UpdatePasswordAsync(string username, string newPassword);

    }
}
