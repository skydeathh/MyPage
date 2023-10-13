using Microsoft.EntityFrameworkCore;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Infrastructure.EF.Contexts;

namespace MyPage.Infrastructure.EF.Repositories;
internal sealed class PostgresPostRepository : IMyPageRepository<Post> {
    private readonly DbSet<Post> _posts;
    private readonly ApplicationDbContext _context;

    public PostgresPostRepository(ApplicationDbContext context) {
        _posts = context.Posts;
        _context = context;
    }

    public async Task AddAsync(Post entity) {
        await _posts.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Post entity) {
        _posts.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<Post> GetAsync(long id) =>
        _posts.SingleOrDefaultAsync(p => p.Id == id);
    
    public async Task UpdateAsync(Post entity) {
        _posts.Update(entity);
        await _context.SaveChangesAsync();
    }
}