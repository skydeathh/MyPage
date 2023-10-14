using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Application.Exceptions;

internal class PostNotFoundException : MyPageException {
    public PostNotFoundException(int id)
        : base(message: $"Post with ID '{id}' not found") {
    }
}