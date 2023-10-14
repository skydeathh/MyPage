using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands;
internal class AddPostCommand(string Title, string Content, int UserId) : ICommand {
}