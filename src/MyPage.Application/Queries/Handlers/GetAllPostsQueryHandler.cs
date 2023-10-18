using Microsoft.EntityFrameworkCore;
using MyPage.Application.Exceptions;
using MyPage.Application.Queries;
using MyPage.Domain.Entities;
using MyPage.Infrastructure.EF.Contexts;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries.Handlers;

internal sealed class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, IEnumerable<Post>> {
    private readonly DbSet<Post> _posts;

    public GetAllPostsQueryHandler(ApplicationDbContext context) {
        _posts = context.Posts;
    }

    public async Task<IEnumerable<Post>> HandleAsync(GetAllPostsQuery query) {

        var posts = await _posts.ToListAsync();

        if (posts == null || !posts.Any()) {
            throw new PostsNotFoundException();
        }

        return posts;
    }
}