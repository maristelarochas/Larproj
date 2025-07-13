using System.Security.Authentication;
using Larproj.Domain.Entities;
using Larproj.Infrastruture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Larproj.Infrastruture.Repositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User?> GetUserByEmail(string email);
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
        var user = await dataContext.Users.FirstOrDefaultAsync(user => user.UserEmail == email);
        return user;
    }
    public async Task UpdateUser(User user)
    {
        var userUpdate = await dataContext.Users.FirstOrDefaultAsync();
    }
    public async Task DeleteUser(User user)
    {
        dataContext.Users.Remove(user);
        await dataContext.SaveChangesAsync();
    }
}