using Microsoft.EntityFrameworkCore;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Infrastructure.EF.Contexts;

namespace MyPage.Infrastructure.EF.Repositories;

internal sealed class PostgresUserRepository : IMyPageRepository<User> {
    private readonly DbSet<User> _users;
    private readonly ApplicationDbContext _context;

    public PostgresUserRepository(ApplicationDbContext context) {
        _users = context.Users;
        _context = context;
    }

    public async Task AddAsync(User entity) {
        await _users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity) {
        _users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<User> GetAsync(long id) =>
        _users.SingleOrDefaultAsync(p => p.Id == id);

    public async Task UpdateAsync(User entity) {
        _users.Update(entity);
        await _context.SaveChangesAsync();
    }
}