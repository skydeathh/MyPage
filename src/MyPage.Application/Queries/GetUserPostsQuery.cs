using MyPage.Domain.Entities;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries;
public class GetUserPostsQuery : IQuery<IEnumerable<Post>> {
    public string Email { get; set; } 
}