using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Application.Exceptions;

internal class NotUsersPostException : MyPageException {
    public NotUsersPostException(int userId, int postId)
        : base(message: $"Post with ID '{postId}' cant be deleted by user '{userId}' ") {
    }
}