using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands.Handlers;

internal sealed class AddPostCommandHandler : ICommandHandler<AddPostCommand> {
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public AddPostCommandHandler(IPostRepository postRepository, IUserRepository userRepository) {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(AddPostCommand command) {
        var date = DateTime.UtcNow;
        var user = await _userRepository.GetAsync(command.UserId);
        
        if (user == null) {
            throw new UserNotFoudException(command.UserId);
        }

        var post = new Post(command.Title, command.Content, date, date, command.UserId, user);

        await _postRepository.AddAsync(post);
    }
}