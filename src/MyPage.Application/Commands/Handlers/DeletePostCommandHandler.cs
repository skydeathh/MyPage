using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands.Handlers;

internal sealed class DeletePostCommandHandler : ICommandHandler<DeletePostCommand> {
    private readonly IPostRepository _repository;

    public DeletePostCommandHandler(IPostRepository repository) {
        _repository = repository;
    }

    public async Task HandleAsync(DeletePostCommand command) {
        var post = await _repository.GetAsync(command.Id);

        if (post is null) {
            throw new PostNotFoundException(command.Id);
        }

        if (post.UserId != command.UserId) {
            throw new NotUsersPostException(command.UserId, command.Id);
        }

        await _repository.DeleteAsync(post);
    }
}