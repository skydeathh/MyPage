using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands;

public record DeletePostCommand(int Id, int UserId) : ICommand;