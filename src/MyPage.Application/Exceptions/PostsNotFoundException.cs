using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Application.Exceptions;

internal class PostsNotFoundException : MyPageException {
    public PostsNotFoundException()
        : base(message: $"This user has no posts yet") {
    }
}