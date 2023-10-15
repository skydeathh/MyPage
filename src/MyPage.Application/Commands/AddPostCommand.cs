using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands;

public record AddPostCommand(string Title, string Content, int UserId) : ICommand;