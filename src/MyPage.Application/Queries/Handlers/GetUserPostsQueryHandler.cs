using Microsoft.EntityFrameworkCore;
using MyPage.Application.DTO;
using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Infrastructure.EF.Contexts;
using MyPage.Shared.Abstractions.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyPage.Application.Queries.Handlers;

internal sealed class GetUserPostsQueryHandler : IQueryHandler<GetUserPostsQuery, IEnumerable<Post>> {
    private readonly DbSet<Post> _posts;

    public GetUserPostsQueryHandler(ApplicationDbContext context) {
        _posts = context.Posts;
    }

    public async Task<IEnumerable<Post>> HandleAsync(GetUserPostsQuery query) {
        var posts = await _posts
            .Where(p => p.User.Email == query.Email).ToListAsync();

        if (posts == null || !posts.Any()) {
            throw new PostsNotFoundException();
        }

        return posts;
    }
}