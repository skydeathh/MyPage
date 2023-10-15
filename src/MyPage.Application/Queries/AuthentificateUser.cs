using MyPage.Application.DTO;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries;

public class AuthentificateUser : IQuery<AuthentificationResponse> {
    public string Email { get; set; }
    public string Password { get; set;}
}