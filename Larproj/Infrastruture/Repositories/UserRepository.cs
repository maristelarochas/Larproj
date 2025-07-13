using Larproj.Domain.Entities;
using Larproj.Infrastruture.Persistence;

namespace Larproj.Infrastruture.Repositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User?> GetUserByEmail(string email);
    Task SaveChanges(User user);
    Task DeleteUser(User user);
}

public class UserRepository(DataContext dataContext) : IUserRepository
{
    public async Task AddUser(User user)
    {
        await dataContext.Users.AddAsync(user);
        await dataContext.SaveChangesAsync();
    }
    public async Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
    public async Task SaveChanges(User user)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteUser(User user)
    {
        throw new NotImplementedException(); 
    }
}