using MyPage.Application.DTO;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries;

public class AuthentificateUser : IQuery<AuthentificationResponse> {
    public AuthentificationRequest AuthRequest { get; set; }
}