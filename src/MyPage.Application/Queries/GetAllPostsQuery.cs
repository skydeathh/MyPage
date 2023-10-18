using MyPage.Domain.Entities;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries;

internal class GetAllPostsQuery : IQuery<IEnumerable<Post>> {
}

