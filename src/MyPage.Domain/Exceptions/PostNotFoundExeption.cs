using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Domain.Exceptions;

internal class PostNotFoundExeption : MyPageException {
    public PostNotFoundExeption(int postId) 
        : base(message: $"Post with {postId} not found.") {
    }
}