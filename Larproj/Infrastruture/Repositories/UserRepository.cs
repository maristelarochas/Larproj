using System.Security.Authentication;
using Larproj.Domain.Entities;
using Larproj.Infrastruture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Larproj.Infrastruture.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<User?> GetByEmail(string email);
    Task Update(User user);
    Task Delete(User user);
}

public class UserRepository(DataContext dataContext) : IUserRepository
{
    public async Task Add(User user)
    {
        dataContext.Users.AddAsync(user);
        await dataContext.SaveChangesAsync();
    }
    public async Task<User?> GetByEmail(string email)
    {
        var user = await dataContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }
    public async Task Update(User user)
    {
        dataContext.Users.Update(user);
        await dataContext.SaveChangesAsync();
    }
    public async Task Delete(User user)
    {
        dataContext.Users.Remove(user);
        await dataContext.SaveChangesAsync();
    }
}