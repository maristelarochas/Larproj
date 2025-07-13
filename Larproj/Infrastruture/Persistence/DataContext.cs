using Larproj.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Larproj.Infrastruture.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}

