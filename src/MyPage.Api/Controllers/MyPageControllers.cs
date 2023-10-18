using Microsoft.AspNetCore.Mvc;
using MyPage.Application.Commands;
using MyPage.Application.DTO;
using MyPage.Application.Queries;
using MyPage.Domain.Repositories;
using MyPage.Shared.Abstractions.Commands;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Api.Controllers;

[ApiController]
[Route("MyPage")]
public class MyPageControllers : ControllerBase {
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public MyPageControllers(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }
    [HttpPost("login")]
    public async Task<ActionResult<AuthentificationResponse>> Login(AuthentificateUser query) {
        var result = await _queryDispatcher.QueryAsync(query);

        result.Token = "autorizationtoken";
        return Ok(result);
    }

    [HttpPost("registeration")]
    public async Task<IActionResult> Registration(RegisterUserCommand command) {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    [HttpPost("addpost")]
    public async Task<IActionResult> AddPostForUser(AddPostCommand command) {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    [HttpDelete("deletepost/{postId}")]
    public async Task<IActionResult> DeletePostForUser(DeletePostCommand command) {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    [HttpGet("users/{userId}/posts")]
    public async Task<IActionResult> GetPostsByUserId(int userId) {
        try {
            var posts = await _postRepository.GetPostsByUserId(userId);

            return Ok(posts);
        } catch (Exception ex) {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}