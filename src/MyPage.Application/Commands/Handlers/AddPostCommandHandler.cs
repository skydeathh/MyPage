using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands.Handlers;

internal sealed class AddPostCommandHandler : ICommandHandler<AddPostCommand> {
    private readonly IPostRepository _repository;

    public AddPostCommandHandler(IPostRepository repository) {
        _repository = repository;
    }

    public async Task HandleAsync(AddPostCommand command) {
        var date = DateTime.Now;

        var post = new Post(command.Title, command.Content, date, date, command.UserId);

        await _repository.DeleteAsync(post);
    }
}